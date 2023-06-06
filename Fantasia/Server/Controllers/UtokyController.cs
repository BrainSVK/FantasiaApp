using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Fantasia.Shared;
using Fantasia.Server.Services.UtokyService;
using Fantasia.Server.Data;
using Fantasia.Server.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Stripe;

namespace Fantasia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtokyController : ControllerBase
    {
        private readonly IUtokyService _utokyService;
        public UtokyController(IUtokyService utokyService)
        {
            _utokyService = utokyService;
        }

        [HttpGet("getfyzutok"),Authorize]
        public async Task<ActionResult<ServiceResponse<FyzUtoky>>> GetFyzUtok(int Id)
        {
            var result = await _utokyService.GetFyzUtokByPostavaId(Id);
            return Ok(result);
        }

        [HttpGet("getmagutok")]
        public async Task<ActionResult<ServiceResponse<MagUtoky>>> GetMagUtok(int Id)
        {
            var result = await _utokyService.GetMagUtokByPostavaId(Id);
            return Ok(result);
        }

        [HttpGet("getvieutok")]
        public async Task<ActionResult<ServiceResponse<VieUtoky>>> GetVieUtok(int Id)
        {
            var result = await _utokyService.GetVieUtokByPostavaId(Id);
            return Ok(result);
        }



    }
}
