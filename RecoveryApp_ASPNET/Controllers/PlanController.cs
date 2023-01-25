using Microsoft.AspNetCore.Mvc;
using RecoveryApp_ASPNET.Models.PlanModel;
using RecoveryApp_ASPNET.Services;

namespace RecoveryApp_ASPNET.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly IAppService _appService;

        public PlanController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            var plans = await _appService.GetPlansAsync();
            if (plans == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status200OK, plans);
        }

        [HttpPost]
        public async Task<IActionResult> SavePlan(Plan plan)
        {
            var dbPlan = await _appService.AddPlanAsync(plan);
            if (dbPlan == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"error , plan {plan} not saved");
            }
            return CreatedAtAction("GetPlans", new { id = plan.Id }, plan);
        }

    }
}
