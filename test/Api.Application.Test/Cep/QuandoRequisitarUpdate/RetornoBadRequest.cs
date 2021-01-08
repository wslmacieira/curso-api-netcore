using System;
using System.Threading.Tasks;
using application.Controllers;
using Domain.Dtos.Cep;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class RetornoBadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possivel Realizar o Update")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de logradouro",
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um campo obrigatorio");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoUpdate = new CepDtoUpdate
            {
                Logradouro = "Teste de logradouro",
                Numero = ""
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
