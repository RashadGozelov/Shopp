using Final_Projectt.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = _context.Bios.FirstOrDefault();
            return View(await Task.FromResult(footer));
        }
    }
}
