using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JsonSerilizerASP.Data;
using JsonSerilizerASP.Models;

namespace JsonSerilizerASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View(_context.Properties);
        }

        [HttpPost]
        public IActionResult Post(PropertyData property)
        {
            _context.Update(property);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
