using System.ComponentModel.DataAnnotations;

namespace CRUDModal1.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

    }
}
