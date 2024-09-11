namespace CRUDModal1.Models.Dto
{
    public class AddCustomerDto
    {
        public required string CustomerName { get; set; }
        public required string CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
