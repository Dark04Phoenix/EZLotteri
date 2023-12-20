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

        public List<BørneGruppe> BørneGrupper { get; set; }

        public IActionResult OnGet()
        {
            HentBørneGrupper();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                GenererBarnID();
                TildelBørnegruppeID();
                GemNytBarn();
                return RedirectToPage("/BørneGrupper");
            }

            HentBørneGrupper();
            return Page();
        }

        private void HentBørneGrupper()
        {
            BørneGrupper = _dbContext.Børnegruppe.ToList();
        }

        private void GenererBarnID()
        {
            // Find det højeste eksisterende BarnID
            int højesteBarnID = _dbContext.Barn.Max(b => b.BarnID);

            // Tildel det næste unikke BarnID
            Barn.BarnID = højesteBarnID + 1;
        }

        private void TildelBørnegruppeID()
        {
            // Tildel den valgte BørnegruppeID til det nye barn
            if (ModelState.TryGetValue("Barn.BørnegruppeID", out var entry))
            {
                var børnegruppeIdValue = entry.AttemptedValue;

                if (int.TryParse(børnegruppeIdValue, out int børnegruppeIdParsed))
                {
                    Barn.BørnegruppeID = børnegruppeIdParsed;
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