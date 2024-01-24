using CustomLibrary.Helper;
using OrderService.Data.Enum;

namespace OrderService.Data.Domain
{
	public class SalesOrder:EntityBase
	{
        public Guid CustomerId { get; set; }
        public Guid ProductSparepartId { get; set; }
        public SalesType? SalesType { get; set; }
        public decimal? OrderQuantity { get; set; }
        public decimal? TotalOrderPayment { get; set; }
		public DateTimeOffset OrderedAt { get; set; }
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }

		public virtual ProductSparepart? ProductSparepart { get; set; }
		public virtual Customer? Customer { get; set; }
	}
}
