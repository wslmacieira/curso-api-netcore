using System;
using System.Threading.Tasks;
using Domain.Interfaces.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoDelete : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(IdMunicipio)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var delete = await _service.Delete(IdMunicipio);
            Assert.True(delete);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            delete = await _service.Delete(Guid.NewGuid());
            Assert.False(delete);

        }
    }
}
