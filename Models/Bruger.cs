using System.ComponentModel.DataAnnotations.Schema;

namespace EZLotteri.Models
{
    [Table("Bruger", Schema = "dbo")]
    public class Bruger
    {
        public int BrugerID { get; set; }
    }
}
