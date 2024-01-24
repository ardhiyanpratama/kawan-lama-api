using OrderService.Application.Core.IRepositories;
using OrderService.Data;
using CustomLibrary.Adapter;
using CustomLibrary.Exceptions;
using CustomLibrary.Helper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.ViewModel;
using CustomLibrary.ViewModels;
using CustomLibrary.Helper.Api;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace OrderService.Controllers
{
	[ApiVersion("1.0")]
	[ApiController]
    [Route("v1/[controller]")]
    public class SalesOrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly ILoggerAdapter<SalesOrderController> _logger;

        public SalesOrderController(ApplicationDbContext context
            ,ILogger<SalesOrderController> logger
            ,ISalesOrderRepository salesOrderRepository)
        {
            _context = context;
			_salesOrderRepository = salesOrderRepository;
            _logger = new LoggerAdapter<SalesOrderController>(logger);
        }

        [HttpPost]
        public async Task<ActionResult> Post(
        [FromBody] SalesOrderWriteDto input,
            CancellationToken cancellationToken)
        {
            var result = await _salesOrderRepository.SubmitSalesOrder(input);

            if (result.IsError)
            {
                throw new AppException(ResponseMessageExtensions.Database.WriteFailed);
            }

            return this.OkResponse(ResponseMessageExtensions.Database.WriteSuccess);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedItemsViewModel<SalesOrderViewModel>>> GetListSalesOrder(
			[FromQuery] PaginationFilter filter,
		    [FromQuery] string? productcode,
		    [FromQuery] string? customername,
			CancellationToken cancellationToken)
        {
			var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
			var listQuery = _context.SalesOrders
                .Include(x => x.Customer)
                .Include(x => x.ProductSparepart)
                .AsNoTracking()
				.OrderByDescending(x => x.CreatedAt)
                .AsQueryable();

			if (!string.IsNullOrWhiteSpace(productcode))
			{
				listQuery = listQuery.Where(e => e.ProductSparepart.ProductCode.ToLower().Contains(productcode.ToLower()) || e.ProductSparepart.ProductCode.ToLower() == productcode.ToLower());
			}

			if (!string.IsNullOrWhiteSpace(customername))
			{
				listQuery = listQuery.Where(e => e.Customer.Name.ToLower().Contains(customername.ToLower()) || e.Customer.Name.ToLower() == customername.ToLower());
			}

			var totalItems = await listQuery.CountAsync(cancellationToken);
			var listing = await listQuery
				.OrderByDescending(e => e.CreatedAt)
				.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
				.Take(validFilter.PageSize)
				.AsNoTracking()
				.ToListAsync(cancellationToken);

			if (listing.Count == 0)
			{
				return Ok(new PaginatedItemsViewModel<SalesOrderViewModel>(validFilter.PageNumber, validFilter.PageSize, totalItems, new List<SalesOrderViewModel>()));
			}

			var result = listing.Adapt<List<SalesOrderViewModel>>();

			var viewModel = new PaginatedItemsViewModel<SalesOrderViewModel>(validFilter.PageNumber, validFilter.PageSize, totalItems, result);

			return Ok(viewModel);
		}

		[HttpGet("validation/{id}")]
		public async Task<IActionResult> GetValidationCustomerCompany([FromRoute] string id)
		{
			var validation = await _salesOrderRepository.CustomerCompanyValidation(id);

			if (!validation)
			{
				throw new AppException(ResponseMessageExtensions.Customer.NotValidForCompany);
			}

			return this.OkResponse(ResponseMessageExtensions.Customer.ValidForCustomerCompany);
		}
	}
}
