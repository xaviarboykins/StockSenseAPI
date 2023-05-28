using System.Text.Json.Serialization;

namespace StockSense.Model
{
    public class SupplierDto : Supplier
    {
        [JsonIgnore]
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
