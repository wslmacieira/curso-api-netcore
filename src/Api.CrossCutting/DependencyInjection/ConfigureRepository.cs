using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Repository;
using Data.Implementations;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using src.Api.Data.Repository;
using src.Api.Domain.Interfaces;

namespace src.Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=CursoApiNetcore;Integrated Security=true")
                );
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }


        }
    }
}
