using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EZLotteri.Models;

namespace EZLotteri.Pages
{
    public class BørneGrupperPageModel : PageModel
    {
        private readonly AppDbContext _dbContext;
        private readonly LederService _lederService;

        public BørneGrupperPageModel(AppDbContext dbContext, LederService lederService)
        {
            _dbContext = dbContext;
            _lederService = lederService;
        }

        public List<BørneGruppe> Børnegrupper { get; private set; }
        public List<Barn> Børn { get; private set; }
        public int ValgtGruppeId { get; set; }

        public void OnGet(int gruppeId)
        {
            HentBørnegrupper();
            if (gruppeId > 0)
            {
                ValgtGruppeId = gruppeId;
                HentBørnForGruppe();
            }
        }

        public void OnGetDetails(int gruppeId, int barnId)
        {
            HentBørnegrupper();
            if (gruppeId > 0)
            {
                ValgtGruppeId = gruppeId;
                HentBørnForGruppe();

                if (barnId > 0)
                {
                    HentBarnDetaljer(barnId);
                }
            }
        }

        private void HentBørnegrupper()
        {
            Børnegrupper = _lederService.HentAlleBørnegrupperMedRelationer();
        }

        private void HentBørnForGruppe()
        {
            Børn = _lederService.HentBørnForGruppe(ValgtGruppeId);
        }

        private void HentBarnDetaljer(int barnId)
        {
            var valgtBarn = _lederService.HentBarnDetaljer(barnId);
        }
    }
}