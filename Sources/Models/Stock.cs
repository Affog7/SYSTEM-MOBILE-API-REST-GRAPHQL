using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class Stock
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

