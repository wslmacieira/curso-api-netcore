using System;
using System.Threading.Tasks;
using application.Controllers;
using Domain.Dtos.Cep;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarGet
{
    public class RetornoNotFound
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel Realizar o Get")]
        public async Task E_Possivel_Invocar_a_controller_Get()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));
            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
