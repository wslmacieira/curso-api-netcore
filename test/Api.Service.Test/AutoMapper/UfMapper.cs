using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Dtos.Uf;
using Domain.Entities;
using Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos de Uf")]
        public void E_Possivel_Mappear_os_Metodos()
        {
            var model = new UfModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1, 2),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<UfEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<UfEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Sigla, model.Sigla);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Dto
            var userDto = Mapper.Map<UfDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Nome, entity.Nome);
            Assert.Equal(userDto.Sigla, entity.Sigla);

            var listDto = Mapper.Map<List<UfDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Nome, listEntity[i].Nome);
                Assert.Equal(listDto[i].Sigla, listEntity[i].Sigla);
            }
        }
    }
}
