using System;
using System.Configuration;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ClientWebApplication.Interceptors;
using ClientWebApplication.proto;
using Thrift.Protocol;
using Thrift.Transport;

namespace ClientWebApplication.Proxy
{
    [Intercept("teardown")]
    public class ThriftClientApi : IThriftClientApi
    {
        
        public TProtocol Protocol;
        public ThriftResearchAPI.Client ObjClient;
        public static string SmsService = ConfigurationManager.AppSettings["ServerThrift"];
        public ThriftResearchAPI.Client GetThriftClientObject(TTransport Transport)
        {
          
            Protocol = new TBinaryProtocol(Transport);
            ObjClient = new ThriftResearchAPI.Client(Protocol);
            Transport.Open();
            return ObjClient;
        }

        public string TestSendHttpSearch(TTransport Transport, string param1, string param2)
        {
            ObjClient = GetThriftClientObject(Transport);
            string result = ObjClient.TestSendHttpResearch(param1, param2);
            return result;

        }

       
    }
}