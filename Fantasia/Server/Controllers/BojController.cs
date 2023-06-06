using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Fantasia.Shared;
//using Fantasia.Server.Services.BojService;
using Microsoft.AspNetCore.Authorization;
using Stripe;
using Azure;
using Fantasia.Server.Services.BojService;

namespace Fantasia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BojController : ControllerBase
    {
        private readonly IBojService _bojService;

        public BojController(IBojService bojService)
        {
            _bojService = bojService;
        }

        [HttpPost("vytvor")]
        public async Task<ActionResult<ServiceResponse<Boj>>> VytvorBoj(VytvorBoj vytvorBoj)
        {
            var response = await _bojService.VytvorBoj(vytvorBoj);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getboj")]
        public async Task<ActionResult<ServiceResponse<Boj>>> GetBoj(int IdPostava)
        {
            var response = await _bojService.GetBoj(IdPostava);
            //if (!response.Success)
            //{
            //    return BadRequest(response);
            //}
            return Ok(response);
        }

        [HttpPut(), Authorize]
        public async Task<ActionResult<ServiceResponse<Boj>>> UpdateBoj(Boj boj)
        {
            var result = await _bojService.UpdateBoj(boj);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete(), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBoj(int Id)
        {
            var result = await _bojService.DeleteBoj(Id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
