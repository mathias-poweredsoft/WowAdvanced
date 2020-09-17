using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WA.Module.Core;

namespace WA.Module
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
            where TModule : class, IModule, new()
        {
            services.AddTransient<IModule, TModule>();
            var module = new TModule();
            module.ConfigureModuleServices(services);
            return services;
        }
    }
}
