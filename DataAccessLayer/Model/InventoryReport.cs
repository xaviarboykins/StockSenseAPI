namespace StockSense.Model
{
    public class InventoryReport
    {
        public string ReportName { get; set; }
        public DateTime Date { get; set; }
        public List<StockSummaryItem> StockSummaryItems { get; set; }
        public decimal TotalValue { get; set; }
    }
    public class StockSummaryItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public decimal StockValue { get; set; }
    }
}
