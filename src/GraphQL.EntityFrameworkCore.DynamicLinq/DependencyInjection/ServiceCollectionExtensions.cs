﻿using GraphQL.EntityFrameworkCore.DynamicLinq.Builders;
using GraphQL.EntityFrameworkCore.DynamicLinq.Resolvers;
using GraphQL.EntityFrameworkCore.DynamicLinq.Validation;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace GraphQL.EntityFrameworkCore.DynamicLinq.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up Azure services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required for GraphQL EntityFrameworkCore DynamicLinq.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        [PublicAPI]
        public static void AddGraphQLEntityFrameworkCoreDynamicLinq([NotNull] this IServiceCollection services)
        {
            Guard.NotNull(services, nameof(services));

            services.AddOptions();

            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPropertyPathResolver, DefaultPropertyPathResolver>();
            services.AddScoped<IQueryArgumentInfoListBuilder, QueryArgumentInfoListBuilder>();
        }
    }
}
