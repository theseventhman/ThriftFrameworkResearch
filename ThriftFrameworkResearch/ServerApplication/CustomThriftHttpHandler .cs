using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServerAPI;
using ServerAPI.proto;
using Thrift;
using Thrift.Transport;

namespace ServerApplication
{
    /// <summary>
    /// CustomThriftHttpHandler 的摘要说明
    /// </summary>
    public class CustomThriftHttpHandler : THttpHandler
    {

        //public void ProcessRequest(HttpContext context)
        //{
        //    context.Response.ContentType = "text/plain";
        //    context.Response.Write("Hello World");
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public CustomThriftHttpHandler() : base(CreateProcessor())
        {
        }

        private static TProcessor CreateProcessor()
        {
            return new ThriftResearchAPI.Processor(new ApiManager());
        }
    }
}