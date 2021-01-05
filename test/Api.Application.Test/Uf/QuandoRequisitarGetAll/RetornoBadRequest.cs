using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using application.Controllers;
using Domain.Dtos.Uf;
using Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Uf.QuandoRequisitarGetAll
{
    public class RetornoBadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É Possivel Realizar o GetAll")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IUfService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UfDto>
                {
                    new UfDto
                    {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    Sigla = "SP"
                    },
                     new UfDto
                    {
                    Id = Guid.NewGuid(),
                    Nome = "Amazonas",
                    Sigla = "AM"
                    }
                }
            );

            _controller = new UfsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
