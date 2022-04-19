using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechaty.Grpc.Application
{
    public class WechatyContactService : WechatyPuppetService, IWechatyContactService
    {
        public async Task<object> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception();
            }
            var response = await _client.ContactPayloadAsync(new github.wechaty.grpc.puppet.ContactPayloadRequest() { Id = id });
            return response;
        }

        /// <summary>
        /// 获取当前微信二维码
        /// </summary>
        /// <returns></returns>
        public async Task<string> SelfQrCode()
        {
            var response = await _client.ContactSelfQRCodeAsync(new github.wechaty.grpc.puppet.ContactSelfQRCodeRequest() { });
            return response.Qrcode;
        }

        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task SelfName(string name)
        {
            var response = await _client.ContactSelfNameAsync(new github.wechaty.grpc.puppet.ContactSelfNameRequest() { Name = name });

        }

        /// <summary>
        /// 设置签名
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public async Task Signature(string signature)
        {
            await _client.ContactSelfSignatureAsync(new github.wechaty.grpc.puppet.ContactSelfSignatureRequest() { Signature = signature });
        }


    }
}
