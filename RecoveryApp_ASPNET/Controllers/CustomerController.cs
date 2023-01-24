using Microsoft.AspNetCore.Mvc;
using RecoveryApp_ASPNET.Services;

namespace RecoveryApp_ASPNET.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IAppService _appService;

        public CustomerController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _appService.GetCustomersListAsync();
            if(customers == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, customers);
        }
    }
}
