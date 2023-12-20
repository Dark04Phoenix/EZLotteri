using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EZLotteri.Models;
using System.Collections.Generic;
using System.Linq;

namespace EZLotteri.Pages
{
    public class OpretBarnModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public OpretBarnModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Barn Barn { get; set; }

        public List<B�rneGruppe> B�rneGrupper { get; set; }

        public IActionResult OnGet()
        {
            HentB�rneGrupper();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                GenererBarnID();
                TildelB�rnegruppeID();
                GemNytBarn();
                return RedirectToPage("/B�rneGrupper");
            }

            HentB�rneGrupper();
            return Page();
        }

        private void HentB�rneGrupper()
        {
            B�rneGrupper = _dbContext.B�rnegruppe.ToList();
        }

        private void GenererBarnID()
        {
            // Find det h�jeste eksisterende BarnID
            int h�jesteBarnID = _dbContext.Barn.Max(b => b.BarnID);

            // Tildel det n�ste unikke BarnID
            Barn.BarnID = h�jesteBarnID + 1;
        }

        private void TildelB�rnegruppeID()
        {
            // Tildel den valgte B�rnegruppeID til det nye barn
            if (ModelState.TryGetValue("Barn.B�rnegruppeID", out var entry))
            {
                var b�rnegruppeIdValue = entry.AttemptedValue;

                if (int.TryParse(b�rnegruppeIdValue, out int b�rnegruppeIdParsed))
                {
                    Barn.B�rnegruppeID = b�rnegruppeIdParsed;
                }
            }
        }

        private void GemNytBarn()
        {
            // Gem det nye barn i databasen
            _dbContext.Barn.Add(Barn);
            _dbContext.SaveChanges();
        }
    }
}