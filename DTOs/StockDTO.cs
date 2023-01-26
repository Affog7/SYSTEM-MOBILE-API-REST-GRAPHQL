using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
	public class StockDTO
	{
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}

