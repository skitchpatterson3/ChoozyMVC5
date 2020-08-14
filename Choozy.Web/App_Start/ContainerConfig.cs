﻿using Autofac;
using Autofac.Integration.Mvc;
using Choozy.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Choozy.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryPersonData>()
                .As<IPersonData>()
                .SingleInstance();
            //builder.RegisterType<SqlPersonData>()
            //    .As<IPersonData>()
            //    .InstancePerRequest();
            //builder.RegisterType<ChoozyDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}