using Microsoft.Extensions.DependencyInjection;
using PoweredSoft.Data.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;
using WA.Dal.Core;
using WA.Module.Core;

namespace WA.Dal
{
    public class DalModule : IModule
    {
        public void ConfigureModuleServices(IServiceCollection services)
        {
            services.AddPoweredSoftMongoDBDataServices();
            services.AddTransient(typeof(IQueryableProvider<>), typeof(WACollectionContextQueryableProvider<>));
        }
    }
}