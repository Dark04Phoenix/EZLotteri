using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZLotteri.Models;
using System.Collections.Generic;
using System.Linq;

namespace EZLotteri.Pages
{
    public class RegistrerLodsedlerModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public RegistrerLodsedlerModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public int BarnID { get; set; }

        [BindProperty]
        public int AntalLodsedler { get; set; }

        public List<Barn> B�rn { get; set; }

        public void OnGet()
        {
            HentAlleB�rn();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                RegistrerLodsedler();
                return RedirectToPage("/RegistrerLodsedler"); // Redirect til samme side
            }

            HentAlleB�rn();
            return Page();
        }

        private void HentAlleB�rn()
        {
            B�rn = _dbContext.B�rn.ToList();
        }

        private void RegistrerLodsedler()
        {
            var barn = _dbContext.B�rn.Find(BarnID);

            if (barn != null)
            {
                // Kontroller for at undg� at overskride det oprindelige antal lodsedler (5)
                barn.AntalModtagneLodsedler = AntalLodsedler <= 5 ? AntalLodsedler : 5;

                _dbContext.SaveChanges();
            }
        }
    }
}