using System.Threading.Tasks;
using Moq;
using src.Api.Domain.Interfaces.Services.User;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;


        [Fact(DisplayName = "É Possivel executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            //Given
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            //When
            var result = await _service.Get(IdUsuario);

            //Then
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);
        }
    }
}
