using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSerilizerASP.Models;

namespace JsonSerilizerASP.Utils
{
    public class PropertyConverter : JsonConverter
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not implemented yet");
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var propertyList = new List<PropertyData>();
            
            var jsonObject = JObject.Load(reader);
            var properties = jsonObject.Property("properties").Value.ToObject<JArray>();

            foreach (var jToken in properties)
            {
                var property = (JObject)jToken;
                
                var monthlyRent = property.GetValue("financial").ToObject<JObject>()?.GetValue("monthlyRent")?.ToObject<decimal>() ?? 0;
                var listPrice = property.GetValue("financial").ToObject<JObject>()?.GetValue("listPrice")?.ToObject<decimal>() ?? 0;
                var yearBuilt = property.GetValue("physical").ToObject<JObject>()?.GetValue("yearBuilt")?.ToObject<int>() ?? 0;

                var propertyObject = new PropertyData
                {
                    
                    MonthlyRent = monthlyRent,
                    Address = $"{property.Property("address").Value?.ToObject<JObject>().Property("address1").ToObject<string>()}," +
                              $" {property.Property("address").Value?.ToObject<JObject>().Property("address2").ToObject<string>()}," +
                              $" {property.Property("address").Value?.ToObject<JObject>().Property("zip").ToObject<string>()}," +
                              $" {property.Property("address").Value?.ToObject<JObject>().Property("city").ToObject<string>()}," +
                              $" {property.Property("address").Value?.ToObject<JObject>().Property("state").ToObject<string>()}," +
                              $" {property.Property("address").Value?.ToObject<JObject>().Property("country").ToObject<string>()}",
                    ListPrice = listPrice,
                    YearBuilt = yearBuilt
                };
                
                propertyList.Add(propertyObject);
            }

            return propertyList;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
