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

        public List<Barn> Børn { get; set; }

        public void OnGet()
        {
            HentAlleBørn();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                RegistrerLodsedler();
                return RedirectToPage("/RegistrerLodsedler"); // Redirect til samme side
            }

            HentAlleBørn();
            return Page();
        }

        private void HentAlleBørn()
        {
            Børn = _dbContext.Børn.ToList();
        }

        private void RegistrerLodsedler()
        {
            var barn = _dbContext.Børn.Find(BarnID);

            if (barn != null)
            {
                // Kontroller for at undgå at overskride det oprindelige antal lodsedler (5)
                barn.AntalModtagneLodsedler = AntalLodsedler <= 5 ? AntalLodsedler : 5;

                _dbContext.SaveChanges();
            }
        }
    }
}