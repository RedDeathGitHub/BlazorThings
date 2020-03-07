using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Utility.HttpClients;
using Microsoft.AspNetCore.Components.Authorization;
using Module = Autofac.Module;

namespace BlazorRevealed.Client.Infrastructure
{
    public class ClientModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<State>().SingleInstance();
            builder.RegisterType<ApiClient>().SingleInstance();
            builder.RegisterType<RootInitializer>().SingleInstance();
            builder.RegisterType<ApiAuthenticationStateProvider>().As<AuthenticationStateProvider>().SingleInstance();
        }
    }
}