using EZLotteri.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EZLotteri.Pages
{
    public class LodsedlerAdministrationModelModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public LodsedlerAdministrationModelModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public int BørneGruppeId { get; set; }

        [BindProperty]
        public int AntalUdstedteLodsedler { get; set; }

        [BindProperty]
        public int AntalReturneredeLodsedler { get; set; }

        public List<BørneGruppe> BørneGrupper { get; set; }

        public void OnGet()
        {
            HentBørneGrupper();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                GemLodsedler();
                return RedirectToPage("/BørneGrupper");
            }

            HentBørneGrupper();
            return Page();
        }

        private void HentBørneGrupper()
        {
            BørneGrupper = _dbContext.Børnegruppe.ToList();
        }

        private void GemLodsedler()
        {
            var børneGruppe = _dbContext.Børnegruppe.Find(BørneGruppeId);

            if (børneGruppe != null)
            {
                børneGruppe.AntalUdstedteLodsedler += AntalUdstedteLodsedler;
                børneGruppe.AntalReturneredeLodsedler += AntalReturneredeLodsedler;

                _dbContext.SaveChanges();
            }
        }
    }
}

