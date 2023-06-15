using Microsoft.AspNetCore.Mvc;
using Fantasia.Server.Services.UtokyService;
using Microsoft.AspNetCore.Authorization;


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
