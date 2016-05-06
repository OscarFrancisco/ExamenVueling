using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infraestructure;
using Domain;
using Autofac.Integration.Wcf;
using System.Web.Routing;
using System.ServiceModel.Activation;

namespace ServiceWCF
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            RouteTable.Routes.Add(new ServiceRoute("ServiceArticle.svc", new AutofacServiceHostFactory(), typeof(ServiceArticle)));
            RouteTable.Routes.Add(new ServiceRoute("ServiceTicket.svc", new AutofacServiceHostFactory(), typeof(ServiceTicket)));
            var builder = new ContainerBuilder();
            
            builder.RegisterType<ServiceTicket>().As<IServiceTicket>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceArticle>().As<IServiceArticle>().InstancePerLifetimeScope();
            builder.RegisterType<AppShopContext>().As<IDbContext>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryArticle>().As<IRepositoryArticle>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryTicket>().As<IRepositoryTicket>().InstancePerLifetimeScope();
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }
    }
}