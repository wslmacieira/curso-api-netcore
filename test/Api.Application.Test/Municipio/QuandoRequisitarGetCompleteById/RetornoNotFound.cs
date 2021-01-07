using System;
using System.Threading.Tasks;
using application.Controllers;
using Domain.Dtos.Municipio;
using Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetCompleteById
{
    public class RetornoNotFound
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o GetCompleteById")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompleteById()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
