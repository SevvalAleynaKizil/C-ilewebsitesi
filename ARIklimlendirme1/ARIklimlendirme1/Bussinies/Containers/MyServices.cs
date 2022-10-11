using Bussinies.Abstract;
using Bussinies.Concrete;
using Bussinies.FluentValidations;
using DataAccsess.Concrete;
using DataAccsess.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinies.Containers
{
    public static class MyServices
    {
        public static IServiceCollection MyServiceInstance(this IServiceCollection services)
        {
            services.AddDbContext<ARContext>();
            services.AddScoped<ICampaingsService, CampaingsService>();
            services.AddScoped<IInteractionsService, InteractionsService>();
            services.AddScoped<IReferanceService, ReferanceService>();
            services.AddScoped<IMinistrationService, MinistrationService>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddSingleton<IValidator<Campaings>, ValidationCampaings>();
            services.AddSingleton<IValidator<Interactions>, ValidationInteractions>();
            services.AddSingleton<IValidator<Ministration>, ValidationMinistration>();
            services.AddSingleton<IValidator<Users>, ValidationUsers>();



            return services;

        }
    }
}



