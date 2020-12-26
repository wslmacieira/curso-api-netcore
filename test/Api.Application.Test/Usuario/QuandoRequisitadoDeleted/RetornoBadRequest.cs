using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Interfaces.Services.User;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarDeleted
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possivel Realizar o Deleted")]
        public async Task E_Possivel_Invocar_a_Controller_Deleted()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
