using CustomLibrary.Helper;

namespace OrderService.Data.Domain
{
	public class MarketingArea : EntityBase
	{
        public MarketingArea()
        {
            Stores = new HashSet<Store>();
        }

        public string AreaCode { get; set; }
        public string? AreaDescription { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
