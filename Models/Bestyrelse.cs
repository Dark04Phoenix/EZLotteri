using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EZLotteri.Models
{
    [NotMapped]
    public class Bestyrelse
    {
        [Key]
        public int BestyrelseID { get; set; }
        public string Navn { get; set; }

        [ForeignKey("Bruger")]
        public int BrugerID { get; set; }
        public virtual Bruger Bruger { get; set; }
    }
}