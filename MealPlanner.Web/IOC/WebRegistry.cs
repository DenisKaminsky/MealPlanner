using AutoMapper.Extensions.ExpressionMapping;
using MealPlanner.Web.IOC.MapperProfiles;
using MealPlanner.Web.Services;

namespace MealPlanner.Web.IOC
{
    public static class WebRegistry
    {
        /// <summary>
        ///     Register services for the data layer.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void RegisterServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            //configure AutoMapper (it will register all profiles in the assembly)
            services.AddAutoMapper(x => x
                .AddExpressionMapping()
                .AddProfile<WebMapperProfile>()
            );

            //register all services
            services.Scan(scan => scan
                .FromAssemblyOf<BaseService>()
                .AddClasses(classes => classes.AssignableTo<BaseService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
        }
    }
}
