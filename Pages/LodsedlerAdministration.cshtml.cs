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
        public int B�rneGruppeId { get; set; }

        [BindProperty]
        public int AntalUdstedteLodsedler { get; set; }

        [BindProperty]
        public int AntalReturneredeLodsedler { get; set; }

        public List<B�rneGruppe> B�rneGrupper { get; set; }

        public void OnGet()
        {
            HentB�rneGrupper();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                GemLodsedler();
                return RedirectToPage("/B�rneGrupper");
            }

            HentB�rneGrupper();
            return Page();
        }

        private void HentB�rneGrupper()
        {
            B�rneGrupper = _dbContext.B�rnegruppe.ToList();
        }

        private void GemLodsedler()
        {
            var b�rneGruppe = _dbContext.B�rnegruppe.Find(B�rneGruppeId);

            if (b�rneGruppe != null)
            {
                b�rneGruppe.AntalUdstedteLodsedler += AntalUdstedteLodsedler;
                b�rneGruppe.AntalReturneredeLodsedler += AntalReturneredeLodsedler;

                _dbContext.SaveChanges();
            }
        }
    }
}

