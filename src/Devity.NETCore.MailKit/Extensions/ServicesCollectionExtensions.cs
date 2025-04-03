using System;
using Devity.NETCore.MailKit.Infrastructure;
using Devity.NETCore.MailKit.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Devity.NETCore.MailKit.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddMailKit(
            this IServiceCollection serviceCollection,
            Action<MailKitOptionsBuilder> optionsAction
        )
        {
            Check.Argument.IsNotNull(
                serviceCollection,
                nameof(serviceCollection),
                "IServiceCollection is not dependency injection"
            );
            Check.Argument.IsNotNull(optionsAction, nameof(optionsAction));

            optionsAction.Invoke(new MailKitOptionsBuilder(serviceCollection));

            return serviceCollection;
        }
    }
}
