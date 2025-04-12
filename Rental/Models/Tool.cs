using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceRent { get; set; }
        public bool IsAvailable { get; set; }
    }
}
