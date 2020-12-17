using Api.Data.Context;
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

      serviceCollection.AddDbContext<Mycontext>(
        options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=daniela23")
        );
    }
  }
}
