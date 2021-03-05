using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DependencyResolution.Dependency
{
    public class DependencyRegister : IDependencyRegister
    {
        public void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            foreach (System.Type registry in GetTypesForSearchRegistries())
            {
                IEnumerable<System.Type> interfaces = ((System.Reflection.TypeInfo)registry).ImplementedInterfaces;
                if (interfaces.Any(i => i == typeof(IDependencyRegister)))
                {
                    IDependencyRegister dependecy = (IDependencyRegister)Activator.CreateInstance(registry);
                    dependecy.ConfigureDependencies(serviceCollection);
                }
            }
        }

        protected virtual IList<System.Type> GetTypesForSearchRegistries()
        {
            return null;
        }
    }
}
