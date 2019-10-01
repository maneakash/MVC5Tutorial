using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebAPIFundamental.Service;

namespace WebAPIFundamental.App_Start
{
    public class ContainerRegister
    {
        public static IContainer Container;

        public static void RegisterAutofac(HttpConfiguration configuration)
        {
            Initialize(configuration, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerRequest();
            Container = builder.Build();

            return Container;


        }

    }
}