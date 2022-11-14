namespace OnlineShop.WebApi.Angular.Models.DTOs
{
    public class UserWorkAddressDto
    {
        public Guid UserId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public int? PostalCode { get; set; }
    }
}
