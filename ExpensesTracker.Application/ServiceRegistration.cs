using ExpensesTracker.Application.Services.Auth;
using ExpensesTracker.Application.Services.JWT;
using ExpensesTracker.Application.Services.PasswordHash;
using ExpensesTracker.Application.Services.Transactions;
using ExpensesTracker.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IPasswordHashService, PasswordHashService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<TokenService>();

            return services;
        }
    }
}
