using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EZLotteri.Models;
using System.Collections.Generic;

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

        private void GemNytBarn()
        {
            // Gem det nye barn i databasen
            _dbContext.Barn.Add(Barn);
            _dbContext.SaveChanges();
        }
    }
}