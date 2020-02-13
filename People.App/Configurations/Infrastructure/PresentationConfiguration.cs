using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using People.Presentation.People;
using System;
using System.Linq;

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
                .AddQueryType(objectTypeDescriptor => objectTypeDescriptor.Name("Query"))
                .AddType<PeopleQueries>();

            var entityTypes = typeof(Presentation.AssemblyReference).Assembly
                .GetTypes()
                .Where(x =>
                    !x.IsAbstract && !x.IsInterface && x.BaseType != null &&
                    x.BaseType.IsGenericType && (
                        x.BaseType.GetGenericTypeDefinition() == typeof(ObjectType<>) ||
                        x.BaseType.GetGenericTypeDefinition() == typeof(EnumType<>)
                    ))
                .ToList();

            foreach (var type in entityTypes)
            {
                schemaBuilder.AddType(type);
            }

            return schemaBuilder.Create();
        }

        private static void WithSchemaOptions(ISchemaOptions options)
        {
            options.UseXmlDocumentation = true;
        }
    }
}
