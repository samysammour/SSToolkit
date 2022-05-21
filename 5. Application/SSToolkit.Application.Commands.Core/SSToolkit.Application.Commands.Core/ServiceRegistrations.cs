namespace SSToolkit.Application.Commands.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using SSToolkit.Application.Commands.Core.Behaviors;

    public static partial class ServiceRegistrations
    {
        public static IServiceCollection AddMediatRExtensions(this IServiceCollection services, Assembly assembly)
        {
            return services.AddMediatRExtensions(new[] { assembly });
        }

        public static IServiceCollection AddMediatRExtensions(this IServiceCollection services, Assembly[] assemblies)
        {
            var scannedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a =>
                    !a.GetName().Name.StartsWith("Microsoft.", StringComparison.OrdinalIgnoreCase)
                    && !a.GetName().Name.StartsWith("System.", StringComparison.OrdinalIgnoreCase))
                .ToArray()
                .Union(assemblies).ToArray();

            services.AddMediatR(scannedAssemblies);
            return services;
        }

        public static IServiceCollection RegisterMediatRPipeLine(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
