namespace Wechaty.Grpc.Application
{
    public class WechatyContactService : WechatyPuppetService, IWechatyContactService
    {
        /// <summary>
        /// 获取联系人id
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> Get()
        {
            var response = await _client.ContactListAsync(new github.wechaty.grpc.puppet.ContactListRequest() { });
            return response.Ids.ToList();
        }

        public async Task<object> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("参数不能为空");
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

        public async Task<string> Alias(string id, string alias)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id不能为空");
            }

            var response = await _client.ContactAliasAsync(new github.wechaty.grpc.puppet.ContactAliasRequest() { Id = id, Alias = alias });

            return response.Alias;
        }

        public async Task<string> Avatar(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception();
            }

            var response = await _client.ContactAvatarAsync(new github.wechaty.grpc.puppet.ContactAvatarRequest() { Id = id });

            return response.FileBox;
        }

        public async Task<string> Phone(string contactId)
        {
            if (string.IsNullOrWhiteSpace(contactId))
            {
                throw new Exception("参数不能为空");
            }
            var result = await _client.ContactPhoneAsync(new github.wechaty.grpc.puppet.ContactPhoneRequest() { ContactId = contactId });

            return result.Phones.ToString();
        }

        /// <summary>
        /// 设置备注
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="corporationRemark"></param>
        /// <returns></returns>
        public async Task CorporationRemark(string contactId,string corporationRemark)
        {
            if (string.IsNullOrWhiteSpace(contactId))
            {
                throw new Exception("Id不能为空");
            }
            await _client.ContactCorporationRemarkAsync(new github.wechaty.grpc.puppet.ContactCorporationRemarkRequest()
            { ContactId = contactId, CorporationRemark = "" });
            
        }

        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task Description(string contactId,string description)
        {
            if (string.IsNullOrWhiteSpace(contactId))
            {
                throw new Exception("Id不能为空");
            }

            await _client.ContactDescriptionAsync(new github.wechaty.grpc.puppet.ContactDescriptionRequest()
            {
                ContactId = contactId,
                Description=description
            });
        }
    }
}
