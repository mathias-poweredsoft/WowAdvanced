using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WA.Module.Core
{
    public interface IModule
    {
        void ConfigureModuleServices(IServiceCollection services);
    }
}
