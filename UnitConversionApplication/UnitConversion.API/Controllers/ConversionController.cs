using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using UnitConversion.Models.DTO;
using UnitConversion.Services.Interfaces;
using UnitConversion.Services.Services;
using UnitConversion.Models.Validation;


namespace UnitConversion.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionController : ControllerBase
    {

        private readonly ILogger<ConversionController> _logger;

        private readonly IConversionService _conversionService;

        public ConversionController(ILogger<ConversionController> logger, IConversionService conversionService)
        {
            _logger = logger;
            _conversionService = conversionService;
        }

        [HttpPost(Name = "Conversion")]
        public ActionResult<ConversionDTO> Post(ConversionDTO conversion)
        {
            try
            {
                if (conversion.IsValidate() == false)
                    return BadRequest();

                var conversionObject = _conversionService.Conversion(conversion);

                return Ok(conversionObject);
            }
            catch (Exception ex)
            {
                _logger.LogError("Conversion API: {}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while conversion ");
            }
        }

        [HttpGet(Name = "GetConversionHistory")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_conversionService.GetConversionHistory().ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError("GetConversionHistory API: {}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving conversion history from the database");
            }
        }

    }
}
