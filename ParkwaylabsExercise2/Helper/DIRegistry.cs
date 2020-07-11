using Microsoft.Extensions.DependencyInjection;
using ParkwaylabsExercise2.BusinessLogic;
using ParkwaylabsExercise2.BusinessLogic.Interfaces;
using ParkwaylabsExercise2.Repository;
using ParkwaylabsExercise2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Helper
{
    public static class DIRegistry
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services

                .AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<Developer_TechLeadManager>()
                .AddTransient<IDeveloper_TechnologyRepository, Developer_TechnologyRepository>()
                .AddTransient<IDeveloper_TechLeadRepository, Developer_TechLeadRepository>()
                .AddTransient<IDeveloper_TechnologyManager, Developer_TechnologyManager>()
                .AddTransient<TechLead_TechnologyManager>()
                .AddTransient<TechLead_TechnologyRepository>();
                

            return services;
        }
    }
}
