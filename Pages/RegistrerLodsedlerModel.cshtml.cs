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

        public SelectList B�rn { get; set; }

        public void OnGet(int gruppeId)
        {
            HentB�rnForGruppe(gruppeId);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                RegistrerLodsedler();
                return RedirectToPage("/B�rneGrupperPageModel"); // Redirect til oversigten over b�rnegrupper
            }

            HentB�rnForGruppe(_dbContext.B�rnegruppe.FirstOrDefault(b => b.B�rnegruppeID == BarnID)?.B�rnegruppeID ?? 0);
            return Page();
        }

        private void HentB�rnForGruppe(int gruppeId)
        {
            var b�rn = _dbContext.B�rn
                .Where(b => b.B�rnegruppe.B�rnegruppeID == gruppeId)
                .Include(b => b.B�rnegruppe) // Inkluder B�rnegruppe for at undg� null-reference
                .ToList();

            B�rn = new SelectList(b�rn, nameof(Barn.BarnID), nameof(Barn.Navn));
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