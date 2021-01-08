using System;
using System.Threading.Tasks;
using application.Controllers;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarDelete
{
    public class RetornoBadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel Realizar o Delete")]
        public async Task E_Possivel_Invocar_a_controller_Delete()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato invalido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
