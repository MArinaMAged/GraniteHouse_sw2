using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse_sw2.Data;
using GraniteHouse_sw2.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse_sw2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        // GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]// security mechanism -> in each req of HttpPost it checks if the token is 
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid) // checks all the required conditions in our model " ProductTypes "
            {
                _db.Add(productTypes);
                //await _db.AddAsync(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));// nameof is used to handle capital and small chars we can write it return RedirectToAction("Index");
            }
            return View(productTypes);
        }
    }
}