using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse_sw2.Data;
using GraniteHouse_sw2.Models;
using GraniteHouse_sw2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse_sw2.Areas.Admin.Controllers
{

    [Authorize(Roles = SD.SuperAdminEndUser)]
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


        // GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]// security mechanism -> in each req of HttpPost it checks if the token is 
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            if (id != productTypes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid) // checks all the required conditions in our model " ProductTypes "
            {
                _db.Update(productTypes); //figures everything by itself and updates the data automatically

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        // GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }


            return View(productType);
        }

        //POST Delete Action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]// security mechanism -> in each req of HttpPost it checks if the token is 
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productType = await _db.ProductTypes.FindAsync(id);
            _db.ProductTypes.Remove(productType);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}