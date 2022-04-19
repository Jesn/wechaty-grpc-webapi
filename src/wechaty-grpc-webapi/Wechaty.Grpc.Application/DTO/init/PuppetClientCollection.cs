using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wechaty.Puppet;

namespace Wechaty.Grpc.Application.DTO
{
    public class PuppetClientCollection
    {
        public string GateWayUrl { get; set; }
        public string Token { get; set; }
        public PuppetClient WechatyGateWayPuppetClient { get; set; }
    }
}
