using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitConversion.Models.DTO;
using UnitConversion.Services.Interfaces;


namespace UnitConversion.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {

        private readonly ILogger<UnitController> _logger;

        private readonly IUnitService _unitService;

        public UnitController(ILogger<UnitController> logger, IUnitService unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        [HttpGet(Name = "GetUnitsByType")]
        public ActionResult Get(int type)
        {
            try
            {
                return Ok(_unitService.GetUnitsByType(type).ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError("GetUnitsByType API: {}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error retrieving units from the database");
            }
        }

    }
}
