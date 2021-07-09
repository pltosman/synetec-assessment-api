using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Extentions;
using SynetecAssessmentApi.Shared.Utilities.Results.Concrete;
using SyntecAssessmentApi.Services.Abstract;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : ControllerBase
    {
        private readonly IBonusPoolService _bonusPoolService;

        private readonly ILogger<BonusPoolController> _logger;

        public BonusPoolController(IBonusPoolService bonusPoolService, ILogger<BonusPoolController> logger)
        {
            _bonusPoolService = bonusPoolService;
            _logger = logger;
        }

        [HttpGet("getall")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAllEmployee  method called");
            var result = await _bonusPoolService.GetEmployeesAsync();

            return Ok(CommandResult.GetSuccess(result));
        }

        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
       
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            _logger.LogInformation("CalculateBonus  method called");

         var result=   await _bonusPoolService.CalculateAsync(
                (int)request.TotalBonusPoolAmount,
                (int)request.SelectedEmployeeId);
            return Ok(CommandResult.GetSuccess(result));
        }
    }


    
}
