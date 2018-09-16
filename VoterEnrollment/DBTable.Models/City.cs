using System.ComponentModel.DataAnnotations;

namespace DBTable.Models
{
    public  class City
    {
        [Key]
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}
