using System;
using System.Threading.Tasks;
using application.Controllers;
using Domain.Dtos.Cep;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarCreate
{
    public class RetornoCreated
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possivel Realizar o Created")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de logradouro",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Logradouro = "Teste de logradouro",
                Numero = ""
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);
        }
    }
}
