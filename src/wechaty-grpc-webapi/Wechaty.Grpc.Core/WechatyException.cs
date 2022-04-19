using System.Runtime.Serialization;

namespace Wechaty.Grpc.Core
{
    public class WechatyException:Exception
    {
        public WechatyException()
        {
        
        }

        public WechatyException(string message)
            : base(message)
        {
        
        }

        public WechatyException(string message, Exception innerException)
            : base(message, innerException)
        {
        
        }

        public WechatyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
        
        }

    }
}
