﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientWebApplication.common;

namespace ClientWebApplication
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendPostBtn_Click(object sender, EventArgs e)
        {
            string uriString = "http://localhost:2749/ashx/ReceivePostRequest.ashx";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uriString);
            request.Method = WebRequestMethods.Http.Post;
            int testParam = 3;
            string strParam = testParam.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(strParam);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes,0,bytes.Length);
            stream.Close();

            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
                string htmlText = sr.ReadToEnd();
                responseStream.Close();
                postResponseText.InnerText = htmlText;
            }
        }

        protected void usingThriftSendPostBtn_Click(object sender, EventArgs e)
        {
        
            string parameter1 = "test";
            string parameter2 = "test2";
            string result = TestSendHttpResearch(parameter1, parameter2);
            postResponseText.InnerText = result;
            

        }
    }
}