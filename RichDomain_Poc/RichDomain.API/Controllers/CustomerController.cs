using RichDomain.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using RichDomain.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using RichDomain.API.Business.ApplicationService.Interfaces.ServiceContracts;
using RichDomain.API.Business.Domain.Handlers.NotificationHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RichDomain.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerCommandService _customerCommandService;
    private readonly ICustomerQueryService _customerQueryService;

    public CustomerController(ICustomerCommandService customerCommandService,
                              ICustomerQueryService customerQueryService)
    {
        _customerCommandService = customerCommandService;
        _customerQueryService = customerQueryService;

    }

    [AllowAnonymous]
    [HttpPost("customer_register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> CreateCustomerAsync([FromBody] CustomerRegisterRequest dtoCustomer) =>
        await _customerCommandService.CustomerRegisterAsync(dtoCustomer);

    [AllowAnonymous]
    [HttpGet("get_customer_with_email_and_main_address")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<CustomerWithEmailAndCellPhoneResponse?> GetCustomerWithEmailAndMainAddressAsync([FromQuery] int customerId) =>
        await _customerQueryService.FindByCustomerIdAsync(customerId);

    [AllowAnonymous]
    [HttpGet("get_all_customers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<CustomerDataResponse>> GetAllCustomersAsync() =>
        await _customerQueryService.FindAllCustomerWithEmailAndMainTelephoneAsync();
}
