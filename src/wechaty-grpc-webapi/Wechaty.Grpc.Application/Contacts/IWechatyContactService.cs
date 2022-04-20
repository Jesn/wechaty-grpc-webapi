using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechaty.Grpc.Application
{
    public interface IWechatyContactService
    {
        /// <summary>
        /// 获取联系人Id集合
        /// </summary>
        /// <returns></returns>
        Task<List<string>> Get();

        Task<object> Get(string id);

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <returns></returns>
        Task<string> SelfQrCode();

        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task SelfName(string name);

        /// <summary>
        /// 设置签名
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        Task Signature(string signature);

        /// <summary>
        /// 设置别名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        Task<string> Alias(string id, string alias);

        /// <summary>
        /// 获取头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> Avatar(string id);

        Task<string> Phone(string contactId);

        /// <summary>
        /// 设置备注
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task CorporationRemark(string contactId,string corporationRemark);

        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        Task Description(string contactId,string description);
    }
}
