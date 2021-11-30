using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using SBCRM.Queries.Container;
using System;

namespace SBCRM.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}