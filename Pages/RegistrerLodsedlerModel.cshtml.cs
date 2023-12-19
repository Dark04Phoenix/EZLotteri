using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZLotteri.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

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

        [BindProperty, Range(0, 5)]
        public int AntalLodsedler { get; set; }

        public List<Barn> Børn { get; set; }

        public void OnGet()
        {
            HentAlleBørn();
        }

        public IActionResult OnPostRegister()
        {
            if (ModelState.IsValid)
            {
                RegistrerLodsedler(); 
                return RedirectToPage("/RegistrerLodsedler/Index");
            }

            HentAlleBørn();
            return Page();
        }

        private void RegistrerLodsedler()
        {
            throw new NotImplementedException();
        }

        private void HentAlleBørn()
        {
            Børn = _dbContext.Barn
                .Select(b => new Barn
                {
                    BarnID = b.BarnID,
                    Navn = b.Navn,
                    LederID = b.LederID,
                    AntalModtagneLodsedler = b.AntalModtagneLodsedler
                })
                .ToList();
        }
    }
}