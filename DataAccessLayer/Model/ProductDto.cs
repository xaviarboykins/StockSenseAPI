﻿using System.Text.Json.Serialization;

namespace StockSense.Model
{
    public class ProductDto : Product
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
