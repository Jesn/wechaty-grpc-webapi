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
        public async Task<ActionResult> Get()
        {
            var result=await _wechatyContactService.Get();
            return Ok(result);
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

        /// <summary>
        /// 设置别名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Alias(string id,string alias)
        {
            var result = await _wechatyContactService.Alias(id,alias);
            return Ok(result);
        }


        /// <summary>
        /// 获取头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Avatar(string id)
        {
            var result=await _wechatyContactService.Avatar(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Phone(string contactId)
        {
            var result=await _wechatyContactService.Phone(contactId);
            return Ok(result);
        }

        /// <summary>
        /// 设置备注
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="corporationRemark"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> CorporationRemark(string contactId,string corporationRemark)
        {
            await _wechatyContactService.CorporationRemark(contactId, corporationRemark);
            return Ok();
        }


        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Description(string contactId,string description)
        {
            await _wechatyContactService.Description(contactId, description);
            return Ok();
        }




}
}
