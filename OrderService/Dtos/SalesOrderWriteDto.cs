using OrderService.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Dtos
{
	public class SalesOrderWriteDto
	{
		public Guid CustomerId { get; set; }
		[Required]
		public Guid ProductSparepartId { get; set; }
		public SalesType? SalesType { get; set; }
		[Required]
		public decimal? OrderQuantity { get; set; }
		public decimal? TotalOrderPayment { get; set; }
		public DateTimeOffset OrderedAt { get; set; }
	}
}
