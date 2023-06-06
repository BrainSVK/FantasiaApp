using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Fantasia.Shared;
using Fantasia.Server.Services.PostavaService;
using Microsoft.AspNetCore.Authorization;
using Stripe;
using Azure;

namespace Fantasia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostavaController : ControllerBase
    {
        private readonly IPostavaService _postavaService;

        public PostavaController(IPostavaService postavaService)
        {
            _postavaService = postavaService;
        }

        [HttpGet("getpostava"), Authorize]
        public async Task<ActionResult<ServiceResponse<Postava>>> GetPostava()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _postavaService.GetPostavaById(int.Parse(userId));
            return Ok(response);
        }

        [HttpPut(), Authorize]
        public async Task<ActionResult<ServiceResponse<PostavaUpdate>>> UpdatePostava(PostavaUpdate postava)
        {
            var result = await _postavaService.UpdatePostava(postava);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
