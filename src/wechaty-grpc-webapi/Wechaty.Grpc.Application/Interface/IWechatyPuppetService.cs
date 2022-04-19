using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wechaty.Grpc.Application.DTO;

namespace Wechaty.Grpc.Application
{
    public interface IWechatyPuppetService
    {
        void StartAsync(StartRequest request);
    }
}
