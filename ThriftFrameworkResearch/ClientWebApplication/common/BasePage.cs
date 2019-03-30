using System;
using System.Configuration;
using System.Linq.Expressions;
using ClientWebApplication.proto;
using ClientWebApplication.Proxy;
using Thrift.Protocol;
using Thrift.Transport;

namespace ClientWebApplication.common
{
    public class BasePage : System.Web.UI.Page
    {
        public static string SmsService = ConfigurationManager.AppSettings["ServerThrift"];
        public TTransport Transport;
        public IThriftClientApi ThriftClientApi { get; set; }

        public string TestSendHttpResearch(string param1, string param2)
        {
            InitilizeTransportObject();
            return ThriftClientApi.TestSendHttpSearch(Transport, param1, param2);
        }

        private void InitilizeTransportObject()
        {
            Transport = new THttpClient(new Uri(SmsService));
        }
    }
} 