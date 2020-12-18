using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Repository;
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

            serviceCollection.AddDbContext<Mycontext>(
              options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=gostack")
              );
        }
    }
}
