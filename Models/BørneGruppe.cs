using System.ComponentModel.DataAnnotations.Schema;

namespace EZLotteri.Models
{
    [Table("BørneGruppe", Schema = "dbo")]
    public class BørneGruppe
    {
        public int BørnegruppeID { get; set; }
        public string Navn { get; set; }
        public int LederID { get; set; }
        public int AntalUdstedteLodsedler { get; set; }
        public int AntalReturneredeLodsedler { get; set; }

        public virtual Leder Leder { get; set; }
        public virtual ICollection<Barn> Børn { get; set; }
    }
}
