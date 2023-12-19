using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZLotteri.Models
{
    
    public class LotteriBestyrer
    {
        [Key]
        public int LotteriBestyrerID { get; set; }
        public string Navn { get; set; }

        [ForeignKey("Bruger")]
        public int BrugerID { get; set; }
        public virtual Bruger Bruger { get; set; }
    }
}