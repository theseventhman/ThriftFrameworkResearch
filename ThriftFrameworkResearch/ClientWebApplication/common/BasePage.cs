using System;
using System.Configuration;
using System.Linq.Expressions;
using ClientWebApplication.proto;
using Thrift.Protocol;
using Thrift.Transport;

namespace ClientWebApplication.common
{
    public class BasePage : System.Web.UI.Page
    {
        public TTransport Transport;
        public TProtocol Protocol;
        public ThriftResearchAPI.Client ObjClient;
        public static string SmsService = ConfigurationManager.AppSettings["ServerThrift"];

        public ThriftResearchAPI.Client CreateNewThriftClientObject()
        {
            Transport = new THttpClient(new Uri(SmsService));
            Protocol = new TBinaryProtocol(Transport);
            ObjClient = new ThriftResearchAPI.Client(Protocol);
            Transport.Open();
            return ObjClient;
        }
    }
}