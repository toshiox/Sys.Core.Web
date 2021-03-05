using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.DependencyResolution.Dependency
{
    public interface IDependencyRegister
    {
        void ConfigureDependencies(IServiceCollection serviceCollection);
    }
}
