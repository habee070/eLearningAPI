using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.API.Controllers.BaseController
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MultipleOrigins")]
    public class BaseApiController : ControllerBase
    {
        protected BadRequestObjectResult BadRequestWithErrorMessage(string message)
        {
            var description = new List<string> { message };
            return BadRequest(description);
        }

        protected BadRequestObjectResult BadRequestWithErrorMessages(List<string> messages)
        {
            return BadRequest(messages);
        }
    }
}
