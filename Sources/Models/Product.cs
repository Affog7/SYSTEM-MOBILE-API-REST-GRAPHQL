using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
  
    public int Quantity { get; set; }


    public int StockForeignKey
    {
        get; set;
    }

    [ForeignKey("StockForeignKey")]
    public Stock Stock { get; set; }
}


