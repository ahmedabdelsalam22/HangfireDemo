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
        public ActionResult TestImdeiatelyBackgroundJob()
        {
            BackgroundJob.Enqueue(()=> SendMSG("ahmed abd elsalam"));

            return Ok();    
        }
        [HttpGet("test_bk_job2")]
        public ActionResult TestScheduleBackgroundJob()
        {
            var time = DateTime.Now;
            Console.WriteLine(time);
            BackgroundJob.Schedule(() => SendMSG("ahmed abd elsalam") , TimeSpan.FromMinutes(1));

            return Ok();
        }
    }
}
