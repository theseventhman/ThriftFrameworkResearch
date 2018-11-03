using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServerApplication.ashx
{
    /// <summary>
    /// ReceivePostRequest 的摘要说明
    /// </summary>
    public class ReceivePostRequest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string values = string.Empty;
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                 values = reader.ReadToEnd();
            }
            context.Response.Write(values);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}