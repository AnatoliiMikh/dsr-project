using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSRNetSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("")]
        public string Get()
        {
            return "Hello!";
        }
    }
}
