using System;
using Fixer.CQRS.Events.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace Fixer.CQRS.Events
{
    public static class Extensions
    {
        public static IFixerBuilder AddEventHandlers(this IFixerBuilder builder)
        {
            builder.Services.Scan(s =>
                s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return builder;
        }

        public static IFixerBuilder AddInMemoryEventDispatcher(this IFixerBuilder builder)
        {
            builder.Services.AddSingleton<IEventDispatcher, EventDispatcher>();
            return builder;
        }
    }
}
