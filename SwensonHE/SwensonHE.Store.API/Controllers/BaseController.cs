using Microsoft.AspNetCore.Mvc;
using SwensonHE.Store.Ground.Enums;
using SwensonHE.Store.Service.Model;

namespace SwensonHE.Store.API.Controllers
{
    [Route("")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult GetErrorResult<T>(IServiceResult<T> result) where T : class
        {
            if (result == null)
            {
                return StatusCode(500);
            }
            if (result.Status == ValidationStatusEnum.NotFound)
            {
                return StatusCode(404);
            }
            if (result.Status == ValidationStatusEnum.Accepted)
            {
                return StatusCode(202, new { messages = result.Messages });
            }
            foreach (string message in result.Messages)
            {
                ModelState.AddModelError("errors", message);
            }
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
    }
}
