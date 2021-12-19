using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService service;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            service = helloWorldService;
        }

        /// <summary>
        /// Calls the Hello World-method from the service and returns it.
        /// </summary>
        /// <returns>Results from service</returns>
        [HttpGet]
        public MyClass Get()
        {
            return service.HelloWorld();
        }
    }
}