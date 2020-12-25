using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Moq;
using src.Api.Domain.Interfaces.Services.User;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGetAll : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método GETALL.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            //Given
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUserDto);
            _service = _serviceMock.Object;

            //When
            var result = await _service.GetAll();

            //Then
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            //Given
            var _listResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            //When
            var _resultEmpty = await _service.GetAll();

            //Given
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
