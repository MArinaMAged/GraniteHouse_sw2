using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse_sw2.Data;
using GraniteHouse_sw2.Models.ViewModel;
using GraniteHouse_sw2.Utility;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse_sw2.Controllers

{
    [Area ("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;
    

        [BindProperty  ]
        public ProductViewModel ProductsVM { get; set; }
        public ProductsController(ApplicationDbContext db,HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            ProductsVM = new ProductViewModel()
            {
                ProductTypes = _db.ProductTypes.ToList(),
                SpecialTags = _db.SpecialTags.ToList(),
                Products = new Models.Products()
            };
        } 
        public async Task< IActionResult> Index()
        {
            var Products = _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags);

            return View(await Products.ToListAsync());
        }
        // get: Products Create

        public IActionResult Create()
        {
            return View(ProductsVM);
        }
        //Post : Products Create
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]

        public async Task <IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ProductsVM);
            }
            _db.Products.Add(ProductsVM.Products);
            await _db.SaveChangesAsync();


            //image being saved

            string WebRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var productsFromDb = _db.Products.Find(ProductsVM.Products.Id);

            if ( files.Count!=0 )
            {
                //image has been uploaded
                var uploads = Path.Combine(WebRootPath, SD.ImageFolder);
                var extention = Path.GetExtension(files[0].FileName);
                using (var filestram = new FileStream (Path.Combine ( uploads,ProductsVM.Products.Id+extention),FileMode.Create ))

                {
                    files[0].CopyTo(filestram);
                }

                productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extention;



            }

            else
            {
                var uploads = Path.Combine(WebRootPath, SD.ImageFolder + @"\" + SD.DefaultProductImage);
                System.IO.File.Copy(uploads, WebRootPath + @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png");
                productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png";
                  
                 
             }
            await _db.SaveChangesAsync();
            return ReadirectToAction(nameof(Index));


        }

        private IActionResult ReadirectToAction(string v)
        {
            throw new NotImplementedException();
        }
    }
}