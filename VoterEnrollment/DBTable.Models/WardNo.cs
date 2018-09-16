using System.ComponentModel.DataAnnotations;

namespace DBTable.Models
{
    public class WardNo
    {
        [Key]
        public int WardNumberId { get; set; }
        public int ConstituencyId { get; set; }
        public string WardNumber { get; set; }
    }
}
