using Coursework.Application.Services;
using Coursework.Core.Abstractions;
using Coursework.Core.Models;
using Coursework.WebAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coursework.WebAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PechController : ControllerBase
    {
        private readonly IPechService _pechService;
        public PechController(IPechService pechService)
        {
            _pechService = pechService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PechResponse>>> GetPech()
        {
            var pech = await _pechService.GetAllPech();

            var response = pech.Select(b => new PechResponse(b.Id, b.tPech, b.diametr, b.tNach, b.kTeplo, b.p, b.tPov, b.kPer, Pech.CalculateVremNagr(b.tPech, b.diametr, b.tNach, b.kTeplo, 712, b.p, b.tPov, b.kPer)));

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePech([FromBody] PechRequest request)
        {
            var (pech, error) = Pech.Create(
                Guid.NewGuid(),
                request.tPech,
                request.diametr,
                request.tNach,
                request.kTeplo,
                request.kTeplo,
                request.p,
                request.tPov,
                request.kPer);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var pechId = await _pechService.CreatePech(pech);

            return Ok(pechId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdatePech(Guid id, [FromBody] PechRequest request)
        {
            var bookId = await _pechService.UpdatePech(id, request.tPech,
                request.diametr,
                request.tNach,
                request.kTeplo,
                request.p,
                request.tPov,
                request.kPer);
            return Ok(bookId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeletePech(Guid id)
        {
            return Ok(await _pechService.DeletePech(id));
        }
    }
}
