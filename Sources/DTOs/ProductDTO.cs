using System.ComponentModel.DataAnnotations;

namespace DTOs;
public class ProductDTO
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
}

