using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerAPI.proto;

namespace ServerAPI
{
    public class ApiManager : ThriftResearchAPI.Iface
    {
        public string TestSendHttpResearch(string parameter1, string parameter2)
        {
            return parameter1 + parameter2;
        }
    }
}
