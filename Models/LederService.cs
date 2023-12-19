using EZLotteri.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class LederService
{
    private readonly AppDbContext _ezlotteri;

    public LederService(AppDbContext dbContext)
    {
        _ezlotteri = dbContext;
    }

    public List<BørneGruppe> HentAlleBørnegrupperMedRelationer()
    {
        return _ezlotteri.Set<BørneGruppe>()
            .Include(b => b.Leder)
            .Include(b => b.Børn)
            .ToList();
    }

    public List<Barn> HentBørnForGruppe(int gruppeId)
    {
        return _ezlotteri.Set<BørneGruppe>()
            .Where(bg => bg.BørnegruppeID == gruppeId)
            .SelectMany(bg => bg.Børn)
            .ToList();
    }
    public Barn HentBarnDetaljer(int barnId)
    {
        return _ezlotteri.Set<Barn>()
            .Where(b => b.BarnID == barnId)
            .Include(b => b.Børnegruppe)  // Inkluder Børnegruppe-navigationsegenskaben
            .FirstOrDefault();
    }


}