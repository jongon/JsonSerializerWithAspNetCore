using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace JsonSerilizerASP.Models
{
    public class PropertyData
    {
        public PropertyData()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Address { get; set; }

        public int YearBuilt { get; set; }

        public decimal ListPrice { get; set; }

        public decimal MonthlyRent { get; set; }

        [NotMapped]
        public decimal GrossYield
        {
            get
            {
                try
                {
                    return MonthlyRent * 12 / ListPrice;

                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
    }
}
