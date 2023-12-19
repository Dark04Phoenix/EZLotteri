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

        private void GemNytBarn()
        {
            // Gem det nye barn i databasen
            _dbContext.Barn.Add(Barn);
            _dbContext.SaveChanges();
        }
    }
}