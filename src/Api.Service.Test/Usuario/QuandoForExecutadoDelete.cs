using System;
using System.Threading.Tasks;
using Moq;
using src.Api.Domain.Interfaces.Services.User;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método DELETE.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            //Given
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            //When
            var deletado = await _service.Delete(IdUsuario);

            //Then
            Assert.True(deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());

            Assert.False(deletado);
        }
    }
}
