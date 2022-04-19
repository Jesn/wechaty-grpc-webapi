using Microsoft.AspNetCore.Mvc;
using Wechaty.Grpc.Application;
using Wechaty.Grpc.Application.DTO;

namespace Wechaty.Grpc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WechatyController : ControllerBase
    {
        private readonly IWechatyPuppetService _wechatyPuppetService;
        public WechatyController(IWechatyPuppetService wechatyPuppetService)
        {
            _wechatyPuppetService = wechatyPuppetService;
        }

        [HttpPost]
        public async Task<ActionResult> Start(StartRequest input)
        {
            input.Token = "insecure_4ad64522-e86d-4a18-afc9-986a9e2078ef";
            input.GateWayUrl = "https://117.68.176.236:9001";


            _wechatyPuppetService.StartAsync(input);
            return Ok();
        }

    }
}
