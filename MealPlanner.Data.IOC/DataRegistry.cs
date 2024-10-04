using AutoMapper.Extensions.ExpressionMapping;
using MealPlanner.Data.IOC.MapperProfiles;
using MealPlanner.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace MealPlanner.Data.IOC
{
    public static class DataRegistry
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
            //configure MongoDB
            services.AddMongoDatabase();

            //configure AutoMapper (it will register all profiles in the assembly)
            services.AddAutoMapper(x => x
                .AddExpressionMapping()
                .AddProfile<DataMapperProfile>()
            );

            //register all repositories
            services.Scan(scan => scan
                .FromAssemblyOf<BaseRepository>()
                .AddClasses(classes => classes.AssignableTo<BaseRepository>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        }

        public static void AddMongoDatabase(this IServiceCollection services)
        {
            //IMongoClient should be registered as singleton per Mongo documentation
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var connectionString = config["MongoDB:ConnectionString"];

                return new MongoClient(connectionString);
            });

            services.AddSingleton(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var client = sp.GetRequiredService<IMongoClient>();
                var databaseName = config["MongoDB:DatabaseName"];

                return client.GetDatabase(databaseName);
            });
        }
    }
}
