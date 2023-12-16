using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZLotteri.Models;
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

        public SelectList Børn { get; set; }

        public void OnGet(int gruppeId)
        {
            HentBørnForGruppe(gruppeId);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                RegistrerLodsedler();
                return RedirectToPage("/BørneGrupperPageModel"); // Redirect til oversigten over børnegrupper
            }

            HentBørnForGruppe(_dbContext.Børnegruppe.FirstOrDefault(b => b.BørnegruppeID == BarnID)?.BørnegruppeID ?? 0);
            return Page();
        }

        private void HentBørnForGruppe(int gruppeId)
        {
            var børn = _dbContext.Børn
                .Where(b => b.Børnegruppe.BørnegruppeID == gruppeId)
                .Include(b => b.Børnegruppe) // Inkluder Børnegruppe for at undgå null-reference
                .ToList();

            Børn = new SelectList(børn, nameof(Barn.BarnID), nameof(Barn.Navn));
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