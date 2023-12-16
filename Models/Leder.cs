using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZLotteri.Models
{
    [Table("Leder", Schema = "dbo")]
    public class Leder
    {
        public int LederID { get; set; }
        public string Navn { get; set; }
        public int BrugerID { get; set; }

        public virtual Bruger Bruger { get; set; }
        public virtual ICollection<BørneGruppe> Børnegruppe { get; set; }
    }
}
