using Final_Projectt.DAL;
using Final_Projectt.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                Image = (await _context.Bios.FirstAsync()).Image,
                basketProduct = new List<Models.BasketProduct>(),
                Categories = await _context.Categorys.Include(m => m.MarkaCategorys).Select(m => new CategoryViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Markas = m.MarkaCategorys.Select(n => new SubCategoryViewModel
                    {
                        Id = n.MarkaId,
                        Name = n.Marka.Name
                    })
                }).ToListAsync()
            };
            return View(headerModel);

            //var header = _context.Bios.FirstOrDefault();
            //return View(await Task.FromResult(header));
        }
    }
}
