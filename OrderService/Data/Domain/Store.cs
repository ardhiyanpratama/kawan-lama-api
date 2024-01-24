using CustomLibrary.Helper;

namespace OrderService.Data.Domain
{
	public class Store : EntityBase
	{
        public Store()
        {
			ProductSpareparts = new HashSet<ProductSparepart>();
        }

        public Guid MarketingAreaId { get; set; }
        public string? MarketingAreaCode { get; set; }
		public string StoreCode { get; set; }
		public string? StoreDescription { get; set; }
		public string? Address { get; set; }
		public string? Phone { get; set; }
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }

        public virtual MarketingArea? MarketingArea { get; set; }
		public virtual ICollection<ProductSparepart> ProductSpareparts { get; set; }
	}
}
