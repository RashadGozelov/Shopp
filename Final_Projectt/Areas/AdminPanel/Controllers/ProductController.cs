using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Extentions;
using Final_Projectt.Models;
using Final_Projectt.Utilities;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Final_Projectt.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = Utility.AdminRole)]
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public ProductController(AppDbContext context,IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var product = _context.Products.Include(p => p.ProductImages).OrderByDescending(p=>p.Date).ToList();
            return View(product);
        }

    
        public IActionResult Create()
        {
            var product = _context.Products.Include(x => x.ProductImages)
                                           .Include(c => c.MarkaCategory.Category)
                                           .Include(m => m.MarkaCategory.Marka).ToList();
            ProductViewModel productViewModel = new ProductViewModel
            {
                Products = product,
                ProductImages = _context.ProductImages,
                Categories = _context.Categorys,
                Markas = _context.Markas
            };
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product,ProductImage productImage,MarkaCategory markaCategory)
        {

            if (ModelState.IsValid)
            {
                return View();
            }

            var id = 0;
            if (! _context.MarkaCategorys.Any(x => x.CategoryId == markaCategory.CategoryId && x.MarkaId == markaCategory.MarkaId))
            {
               
                var newMarkaCategory = new MarkaCategory
                {
                    CategoryId = markaCategory.CategoryId,
                    MarkaId = markaCategory.MarkaId
                };

                await _context.MarkaCategorys.AddAsync(newMarkaCategory);
                await _context.SaveChangesAsync();
                id = newMarkaCategory.Id;
            }
            else
            {
                id = _context.MarkaCategorys.FirstOrDefault(x => x.CategoryId == markaCategory.CategoryId && x.MarkaId == markaCategory.MarkaId).Id;
            }
       
            await _context.Products.AddAsync(new Product
            {
                Name = product.Name,
                MarkaCategoryId = id,
                Price = product.Price,
                Count = product.Count,
                Discount = product.Discount,
                Date = DateTime.Now,
                Description = product.Description
            });
            await _context.SaveChangesAsync();

            var productId = _context.Products.LastOrDefault();
            foreach (var item in productImage.Photo)
            {
                if (!item.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin");
                    return View();
                }

                if (!item.ImageSizeCheck(2))
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü 2Mb-dan artıq ola bilməz");
                    return View();
                }

                string filename = await item.CopyImages(_env.WebRootPath, "product");
                productImage.Image = filename;
                await _context.ProductImages.AddAsync(new ProductImage
                {
                    ProductId = productId.Id,
                    Image = productImage.Image
                });
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            var productDb = await _context.Products.Include(p => p.ProductImages)
                                         .Include(a=>a.MarkaCategory.Category)
                                         .Include(c=>c.MarkaCategory)
                                         .Include(b=>b.MarkaCategory.Marka)
                                         .FirstOrDefaultAsync(p => p.Id == id);
            if (productDb == null) return NotFound();

            ProductViewModel productModel = new ProductViewModel
            {
                Product = productDb,
                ProductImages = _context.ProductImages.Where(p => p.ProductId == id),
                MarkaCategories = _context.MarkaCategorys,
                Categories = _context.Categorys,
                Markas = _context.Markas

            };
            return View(productModel);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var productDb = await _context.Products.Include(p => p.ProductImages)
                                         .Include(p => p.MarkaCategory)
                                         .Include(p => p.MarkaCategory.Marka)
                                         .Include(p => p.MarkaCategory.Category).FirstOrDefaultAsync(p => p.Id == id);

            if (productDb == null) return NotFound();

            ProductViewModel productModel = new ProductViewModel
            {
                Product = productDb,
                ProductImages = _context.ProductImages.Where(p => p.ProductId == id),
                MarkaCategories = _context.MarkaCategorys,
                Categories = _context.Categorys,
                Markas = _context.Markas

            };

            return View(productModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product, ProductImage productImage)
        {

            if (id == null) return NotFound();
            var productDb = await _context.Products.Include(p => p.ProductImages)
                                          .Include(p => p.MarkaCategory)
                                          .FirstOrDefaultAsync(p => p.Id == id);


            if (productDb == null) return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {
                return View(productDb);
            }
            if (productImage.PhotoUpd != null)
            {
                foreach (var item in productImage.PhotoUpd)
                {

                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Bu şəkil formatında deyil");
                        return View();
                    }

                    if (item.ImageSizeCheck(2))
                    {
                        ModelState.AddModelError("Photo", "Şəkilin ölçüsü 2Mb-dan çox olmamalıdır");
                        return View();
                    }

                    string filename = await item.CopyImages(_env.WebRootPath, "product");
                    Utility.DeleteImgFromFolder(_env.WebRootPath, productImage.Image);

                    productImage.Image = filename;

                }
            }

            productDb.Name = product.Name;
            productDb.Description = product.Description;
            productDb.Price = product.Price;
            productDb.Discount = product.Discount;
            productDb.Date = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var productDb = await _context.Products.Include(p => p.ProductImages)
                                         .Include(p => p.MarkaCategory)
                                         .Include(p=>p.MarkaCategory.Category)
                                         .Include(p=>p.MarkaCategory.Marka)
                                         .FirstOrDefaultAsync(p => p.Id == id);
            if (productDb == null) return NotFound();

            ProductViewModel productModel = new ProductViewModel
            {
                Product = productDb,
                ProductImages = _context.ProductImages.Where(p => p.ProductId == id),
                MarkaCategories = _context.MarkaCategorys,
                Categories = _context.Categorys,
                Markas = _context.Markas

            };
            return View(productModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            ProductImage productImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.ProductId == id);
            if (productImage != null)
            {
                Utility.DeleteImgFromFolder(_env.WebRootPath, productImage.Image);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
