using CustomLibrary.Helper;

namespace OrderService.Data.Domain
{
	public class ProductSparepart:EntityBase
	{
        public ProductSparepart()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        public Guid StoreId { get; set; }
        public string? StoreCode { get; set; }
		public string ProductCode { get; set; }
		public string? ProductDescription { get; set; }
		public string? ProductType { get; set; }
		public string? ProductBrand { get; set; }
		public string? UOM { get; set; }
		public decimal? COGS { get; set; }
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }

		public virtual Store? Stores { get; set; }
		public virtual ICollection<SalesOrder> SalesOrders { get; set; }
	}
}
