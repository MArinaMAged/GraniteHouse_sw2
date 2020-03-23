using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse_sw2.Models;
using GraniteHouse_sw2.Data;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse_sw2.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController (ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task <IActionResult> Index()

        {
            var ProductList = await _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).ToListAsync();

            return View(ProductList);
        }

        public async Task <IActionResult> Details(int id )
        {
            var product = await _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).Where(m=>m.Id==id).FirstOrDefaultAsync();
            return View(product);
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
