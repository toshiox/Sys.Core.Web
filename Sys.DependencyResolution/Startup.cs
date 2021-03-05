using System;
using System.Collections.Generic;

namespace Sys.DependencyResolution
{
    public class Startup : Dependency.DependencyRegister
    {
        protected override IList<Type> GetTypesForSearchRegistries()
        {
            return new List<Type>()
            {
                typeof(Services.InversionOfControl),
                typeof(Database.InversionOfControl)
            };
        }
    }
}
