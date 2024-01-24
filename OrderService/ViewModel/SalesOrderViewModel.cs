using OrderService.Data.Enum;

namespace OrderService.ViewModel
{
	public class SalesOrderViewModel
	{
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
		public string? CustomerName { get; set; }
		public CustomerType? CustomerType { get; set; }
		public Guid ProductSparepartId { get; set; }
		public string? ProductCode { get; set; }
		public string? ProductDescription { get; set; }
		public string? ProductType { get; set; }
		public string? UOM { get; set; }
		public SalesType? SalesType { get; set; }
		public decimal? OrderQuantity { get; set; }
		public decimal? TotalOrderPayment { get; set; }
		public DateTimeOffset OrderedAt { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
		public string? UpdatedBy { get; set; }
	}
}
