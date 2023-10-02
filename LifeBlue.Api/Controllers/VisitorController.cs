using System.Net.Mime;
using LifeBlue.Core.Interfaces;
using LifeBlue.Core.Models;
using LifeBlue.Dal.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeBlue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVistorInfoService _vistorInfoService;

        public VisitorController(IVistorInfoService vistorInfoService)
        {
            _vistorInfoService = vistorInfoService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitorInformation))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVisitorInformation(int id)
        {
            var visitorInfo = await _vistorInfoService.GetVisitorInformationAsync(id);

            return visitorInfo == null ? NotFound(visitorInfo) : Ok(visitorInfo);
        }

        [HttpPost("Save")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save([FromBody] VisitorRequest request)
        {
            var result = await _vistorInfoService.SaveVisitorInformation(request);

            return result.VisitorInformation.Id < 1 ? BadRequest(result) :
                CreatedAtAction(nameof(GetVisitorInformation), new {id = result.VisitorInformation.Id}, result);
        }

    }
}
