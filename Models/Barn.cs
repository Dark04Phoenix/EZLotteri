using System.ComponentModel.DataAnnotations.Schema;

namespace EZLotteri.Models
{
    [Table("Barn", Schema = "dbo")]
    public class Barn
    {
        public int BarnID { get; set; }
        public string Navn { get; set; }
        public int LederID { get; set; }
        public int AntalModtagneLodsedler { get; set; }
        public int AntalSolgteMobilePay { get; set; }
        public int AntalSolgteKontanter { get; set; }

        public virtual Leder Leder { get; set; }
        public virtual BørneGruppe Børnegruppe { get; set; }
    }
}
