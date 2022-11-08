using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace OnlineShop.WebApi.Angular.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(70)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        [ValidateNever]
        public Brand Brand { get; set; }
        [ValidateNever]
        public IEnumerable<CategoryProduct> CategoryProducts { get; set; }
    }
}
