using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
    public class TesteLogin : BaseIntegration
    {
        [Fact]
        public async Task TesteDoLogin()
        {
            await AdicionarToken();
        }
    }
}
