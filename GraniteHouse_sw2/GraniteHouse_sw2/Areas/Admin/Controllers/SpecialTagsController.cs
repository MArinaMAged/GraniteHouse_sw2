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
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }



        // GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid) 
            {
                _db.Add(specialTags);
                
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        //Get Edit Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }

        //Post Edit Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialTags specialTags)
        {
            if (id != specialTags.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(specialTags);
        }


        //Get Details Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }


        //Get Delete Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }

        //Post Delete Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var specialTags = await _db.SpecialTags.FindAsync(id);
            _db.SpecialTags.Remove(specialTags);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}