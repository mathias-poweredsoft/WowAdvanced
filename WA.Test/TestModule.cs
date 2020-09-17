using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WA.Module.Core;
using WA.Test.Core;
using WA.Test.Core.Models;
using WA.Test.Validators;

namespace WA.Test
{
    public class TestModule : IModule
    {
        public void ConfigureModuleServices(IServiceCollection services)
        {
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IValidator<AddTestModel>, AddTestValidator>();
        }
    }
}
