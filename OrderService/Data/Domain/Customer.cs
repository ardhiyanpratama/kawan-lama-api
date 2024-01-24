using CustomLibrary.Helper;
using OrderService.Data.Enum;

namespace OrderService.Data.Domain
{
	public class Customer:EntityBase
	{
        public Customer()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }
        public string? Name { get; set; }
		public string? Address { get; set; }
		public string? Phone { get; set; }
		public CustomerType? CustomerType { get; set; }
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }

		public virtual ICollection<SalesOrder> SalesOrders { get; set; }
	}
}
