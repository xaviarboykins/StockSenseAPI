using System.Text.Json.Serialization;

namespace StockSense.Model
{
    public class CategoryDto : Category
    {
        [JsonIgnore]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}

