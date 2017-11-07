using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonSerilizerASP.Models;
using JsonSerilizerASP.Utils;

namespace JsonSerilizerASP.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        
        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
            Init();
        }

        private void Init()
        {
            var properties = CustomHttpClient.GetAsync().Result;

            if (!_context.Database.EnsureCreated())
            {
                return;
            }
            
            _context.Properties.AddRange(properties);
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
