using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Domain.Interfaces.Services.Cep;
using Domain.Interfaces.Services.Municipio;
using Domain.Interfaces.Services.Uf;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using src.Api.Domain.Interfaces.Services.User;
using src.Api.Service.Services;

namespace src.Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
            serviceCollection.AddTransient<ICepService, CepService>();

        }
    }
}
