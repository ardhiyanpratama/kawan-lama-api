using OrderService.Dtos;
using OrderService.ViewModel;
using CustomLibrary.Helper;

namespace OrderService.Application.Core.IRepositories
{
    public interface ISalesOrderRepository
    {
        Task<ResponseBaseViewModel> SubmitSalesOrder(SalesOrderWriteDto salesOrderWriteDto);
        Task<bool> CustomerCompanyValidation(string customerId);
    }
}
