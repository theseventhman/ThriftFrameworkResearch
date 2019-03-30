using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Web;
using Castle.DynamicProxy;
using ClientWebApplication.common;
using ClientWebApplication.Interceptors;
using ClientWebApplication.Proxy;

namespace ClientWebApplication
{
    public class Global : HttpApplication,IContainerProviderAccessor
    {
        //Provider that holds the application container.
        private static IContainerProvider _containerProvider;

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterType<ThriftClientApi>().As<IThriftClientApi>().EnableInterfaceInterceptors();
            builder.RegisterType<BasePage>().PropertiesAutowired(); //进行属性注入，被注入的属性属于BasePage
            builder.Register(c => new ThriftApiTearDownInterceptor()).Named<IInterceptor>("teardown"); //注入Interceptor

            _containerProvider = new ContainerProvider(builder.Build());

        }
    }
}