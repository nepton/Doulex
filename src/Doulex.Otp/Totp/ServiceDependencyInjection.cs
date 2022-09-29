// namespace Doulex.Otp.Totp.Implements
// {
//     public static class ServiceDependencyInjection
//     {
//         public static IServiceCollection AddRfc6238ValidationCodeProvider(this IServiceCollection services, Action<TotpProviderOptions> configure = null)
//         {
//             var config = new TotpProviderOptions();
//             configure?.Invoke(config);
//
//             services.AddSingleton(config);
//             services.AddTransient<ITotpProvider, TotpProvider>();
//
//             return services;
//         }
//     }
// }
