using Castle.DynamicProxy;
using Thrift.Transport;

namespace ClientWebApplication.Interceptors
{
    public class ThriftApiTearDownInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            if (invocation.Method.Name.IndexOf("TestSendHttpSearch") >= 0)
            {
               
                TTransport transport = invocation.Arguments[0] as TTransport;
                transport.Close();

            }
        }
    }
}