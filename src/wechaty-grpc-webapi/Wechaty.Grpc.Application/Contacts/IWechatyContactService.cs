using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechaty.Grpc.Application
{
    public interface IWechatyContactService
    {

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
    }
}
