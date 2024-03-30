using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public void SendMSG(string name) 
        {
            Console.WriteLine("test send "+ name);
        }

        [HttpGet("test_bk_job")]
        public ActionResult TestBackgroundJob()
        {
            BackgroundJob.Enqueue(()=> SendMSG("ahmed abd elsalam"));

            return Ok();    
        }
    }
}
