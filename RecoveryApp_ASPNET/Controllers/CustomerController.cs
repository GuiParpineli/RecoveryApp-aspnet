using Microsoft.AspNetCore.Mvc;
using RecoveryApp_ASPNET.Interfaces;
using RecoveryApp_ASPNET.Models;
using RecoveryApp_ASPNET.Services;

namespace RecoveryApp_ASPNET.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _appService;

        public CustomerController(ICustomerRepository appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _appService.GetAllAsync();
            if (customers == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            Customer customer = await _appService.GetByIdAsync(id);
            if (customer == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"None Customers founded, id:{id}");
            }
            return StatusCode(StatusCodes.Status200OK, customer);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomer(Customer customer)
        {
            var dbCustomer = await _appService.AddAsync(customer);
            if (dbCustomer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Customer {customer} could not be added.");
            }
            return CreatedAtAction("GetCustomerById", new { id = customer.Id }, customer);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            Customer dBcustomer = await _appService.UpdateAsync(customer);
            if (dBcustomer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{customer.Name} not updated");
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _appService.GetByIdAsync(id);
            (bool status, string message) = await _appService.DeleteAsync(customer);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, customer);
        }


    }
}
