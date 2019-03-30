using ClientWebApplication.proto;
using Thrift.Transport;

namespace ClientWebApplication.Proxy
{
    public interface IThriftClientApi
    {
        string TestSendHttpSearch(TTransport Transport, string param1, string param2);
    }
}