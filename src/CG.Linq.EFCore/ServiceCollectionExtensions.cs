﻿using CG.Linq.EFCore.Repositories.Options;
using CG.Validations;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IServiceCollection"/>
    /// type.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method loads and registers EFCore specific repository options.
        /// </summary>
        /// <typeparam name="TOptions">The type of associated repository options.</typeparam>
        /// <param name="serviceCollection">The service collection to use for 
        /// the operation.</param>
        /// <param name="dataProtector">The data protector to use for the operation.</param>
        /// <param name="configuration">The configuration to use for the operation.</param>
        /// <param name="serviceLifetime">The service lifetime to use for the operation.</param>
        /// <returns>The value of the <paramref name="serviceCollection"/>
        /// parameter, for chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever one
        /// or more arguments are invalid, or missing.</exception>
        public static IServiceCollection AddEFCore<TOptions>(
            this IServiceCollection serviceCollection,
            IDataProtector dataProtector,
            IConfiguration configuration,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped
            ) where TOptions : EFCoreRepositoryOptions, new()
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection))
                .ThrowIfNull(dataProtector, nameof(dataProtector))
                .ThrowIfNull(configuration, nameof(configuration));

            // Register the repository options.
            serviceCollection.ConfigureOptions<TOptions>(
                dataProtector,
                configuration
                );

            // Return the service collection.
            return serviceCollection;
        }

        #endregion
    }
}
