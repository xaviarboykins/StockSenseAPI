using System.ComponentModel.DataAnnotations;

namespace StockSense.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
