using Microsoft.AspNetCore.Mvc;
using Wechaty.Grpc.Application;

namespace Wechaty.Grpc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContactController : ControllerBase
    {

        private readonly IWechatyContactService _wechatyContactService;

        public ContactController(IWechatyContactService wechatyContactService)
        {
            _wechatyContactService = wechatyContactService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            var result = await _wechatyContactService.Get(id);
            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult> SelfQrCode()
        {
            var result = await _wechatyContactService.SelfQrCode();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> SelfName(string name)
        {
            await _wechatyContactService.SelfName(name);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Signature(string signature)
        {
            await _wechatyContactService.Signature(signature);
            return Ok();
        }


    }
}
