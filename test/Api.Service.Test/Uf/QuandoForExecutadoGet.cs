using System;
using System.Threading.Tasks;
using Domain.Dtos.Uf;
using Domain.Interfaces.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class QuandoForExecutadoGet : UfTestes
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar Método Get.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(UfId)).ReturnsAsync(ufDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(UfId);
            Assert.NotNull(result);
            Assert.True(result.Id == UfId);
            Assert.Equal(Nome, result.Nome);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(UfId);
            Assert.Null(_record);
        }
    }
}
