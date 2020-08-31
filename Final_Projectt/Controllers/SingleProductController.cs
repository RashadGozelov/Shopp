using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Projectt.DAL;
using Final_Projectt.Models;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Projectt.Controllers
{
    public class SingleProductController : Controller
    {
        private AppDbContext _context;
        public SingleProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id, int? catid)
        {

            SingleProductViewmodel singleviewmodel = new SingleProductViewmodel
            {
                Products= _context.Products
                .Include(i => i.ProductImages)
                .Include(c => c.MarkaCategory)
                .Include(o => o.MarkaCategory.Category)
                .Where(pr => pr.MarkaCategory.Category.Id == catid)
                .Include(u => u.MarkaCategory.Marka),

                ProductImages = _context.ProductImages,
                Markas = _context.Markas.Include(o =>o.MarkaCategorys),
                MarkaCategorys = _context.MarkaCategorys.Include(b =>b.Products),

                SingleProduct = await _context.Products
                .Include(i => i.ProductImages)
                .Include(c => c.MarkaCategory)
                .Include(o => o.MarkaCategory.Category)
                .Include(u => u.MarkaCategory.Marka)
                .FirstOrDefaultAsync(c => c.Id == id),

                SingleCategory = await _context.Categorys
                .Include(a => a.MarkaCategorys)
                .FirstOrDefaultAsync(c => c.Id == catid)
            };

            return View(singleviewmodel);
        }
    }
}