namespace OnlineShop.WebApi.Angular.Models.DTOs
{
    public class UserHomeAddressDto
    {
        public Guid UserId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public int? PostalCode { get; set; }
    }
}
