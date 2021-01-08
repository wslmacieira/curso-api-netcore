using System;
using System.Threading.Tasks;
using application.Controllers;
using Domain.Dtos.Cep;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarGetByCep
{
    public class RetornoBadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel Realizar o GetByCep")]
        public async Task E_Possivel_Invocar_a_controller_GetByCep()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de Rua"
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get("23567290");
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
