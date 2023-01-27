using Microsoft.AspNetCore.Mvc;
using RecoveryApp_ASPNET.Interfaces;
using RecoveryApp_ASPNET.Models.PlanModel;
using RecoveryApp_ASPNET.Services;

namespace RecoveryApp_ASPNET.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly IPlanRepository _appService;

        public PlanController(IPlanRepository appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            var plans = await _appService.GetAllAsync();
            if (plans == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, plans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(Guid id)
        {
            Plan plan = await _appService.GetByIdAsync(id);
            if (plan == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"None plans founded with id: {id}");
            }
            return StatusCode(StatusCodes.Status200OK, plan);
        }

        [HttpPost]
        public async Task<IActionResult> SavePlan(Plan plan)
        {
            var dbPlan = await _appService.AddAsync(plan);
            if (dbPlan == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"error , plan {plan} not saved");
            }
            return CreatedAtAction("GetPlans", new { id = plan.Id }, plan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlan(Guid id, Plan plan)
        {
            if (id != plan.Id)
            {
                return BadRequest();
            }
            Plan dbPlan = await _appService.UpdateAsync(plan);
            if (dbPlan == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{plan.Code} not updated");
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlan(Guid id)
        {
            var plan = await _appService.GetByIdAsync(id);
            (bool status, string message) = await _appService.DeleteAsync(plan);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
            return StatusCode(StatusCodes.Status200OK, plan);
        }

    }
}
