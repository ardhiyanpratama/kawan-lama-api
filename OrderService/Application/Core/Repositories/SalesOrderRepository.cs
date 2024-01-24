using OrderService.Application.Core.IRepositories;
using OrderService.Data;
using OrderService.Data.Domain;
using OrderService.Dtos;
using OrderService.ViewModel;
using CustomLibrary.Helper;
using Microsoft.EntityFrameworkCore;
using static CustomLibrary.Helper.ResponseMessageExtensions;
using CustomLibrary.Services;

namespace OrderService.Application.Core.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

		public SalesOrderRepository(ApplicationDbContext applicationDbContext
			)
        {
            _applicationDbContext = applicationDbContext;
		}

		public async Task<bool> CustomerCompanyValidation(string customerId)
		{
			var checkExisting = await _applicationDbContext.Customers.AnyAsync(x => x.Id.ToString() == customerId && x.CustomerType == Data.Enum.CustomerType.Company);

			return checkExisting;
		}

		public async Task<ResponseBaseViewModel> SubmitSalesOrder(SalesOrderWriteDto salesOrderWriteDto)
		{
			var response = new ResponseBaseViewModel();
			await using var transaction = _applicationDbContext.Database.BeginTransaction();
			try
			{
				var salesOrder = new SalesOrder()
				{
					CustomerId = salesOrderWriteDto.CustomerId,
					OrderedAt = salesOrderWriteDto.OrderedAt,
					OrderQuantity = salesOrderWriteDto.OrderQuantity,
					ProductSparepartId = salesOrderWriteDto.ProductSparepartId,
					SalesType = salesOrderWriteDto.SalesType,
					TotalOrderPayment = salesOrderWriteDto.TotalOrderPayment,
					CreatedBy = "Admin"
				};

				await _applicationDbContext.SalesOrders.AddAsync(salesOrder);

				transaction.Commit();
				await _applicationDbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				response.IsError = true;
				response.ErrorMessage = ex.Message;
			}

			return response;
		}
    }
}
