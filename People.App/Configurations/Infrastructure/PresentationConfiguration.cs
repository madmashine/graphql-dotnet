using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace People.App.Configurations.Infrastructure
{
    internal static class PresentationConfiguration
    {
        internal static IServiceCollection AddPresentationLayer(this IServiceCollection services)
        {
            services.AddGraphQL(WithPeopleGraphQlSchema);

            return services;
        }

        private static ISchema WithPeopleGraphQlSchema(IServiceProvider serviceProvider)
        {
            var schemaBuilder = SchemaBuilder.New()
                .ModifyOptions(WithSchemaOptions)
                .AddServices(serviceProvider)
                .AddQueryType(objectTypeDescriptor => objectTypeDescriptor.Name("Query").Description("All possible querying methods"))
                .AddMutationType(objectTypeDescriptor => objectTypeDescriptor.Name("Mutation").Description("All possible mutation methods"));

            var types = new List<Type>();
            types.AddRange(FetchEntityTypes());
            types.AddRange(FetchResolverTypes());

            foreach (var type in types)
            {
                schemaBuilder.AddType(type);
            }

            return schemaBuilder.Create();
        }

        private static IEnumerable<Type> FetchEntityTypes()
        {
            return typeof(Presentation.AssemblyReference).Assembly
                .GetTypes()
                .Where(x =>
                    !x.IsAbstract && !x.IsInterface && x.BaseType != null &&
                    x.BaseType.IsGenericType && (
                        x.BaseType.GetGenericTypeDefinition() == typeof(ObjectType<>) ||
                        x.BaseType.GetGenericTypeDefinition() == typeof(EnumType<>)
                    ))
                .ToList();
        }
        
        private static IEnumerable<Type> FetchResolverTypes()
        {
            return typeof(Presentation.AssemblyReference).Assembly
                .GetTypes()
                .Where(x =>
                    !x.IsAbstract && !x.IsInterface && x.GetCustomAttribute(typeof(ExtendObjectTypeAttribute)) != null)
                .ToList();
        }

        private static void WithSchemaOptions(ISchemaOptions options)
        {
            options.UseXmlDocumentation = true;
        }
    }
}
