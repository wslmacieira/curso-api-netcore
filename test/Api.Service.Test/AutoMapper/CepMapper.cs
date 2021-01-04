using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Dtos.Cep;
using Domain.Entities;
using Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos de Cep")]
        public void E_Possivel_Mapear_os_Modelos_Cep()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listEntity = new List<CepEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 2)
                        }
                    }
                };
                listEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<CepEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Logradouro, model.Logradouro);
            Assert.Equal(entity.Numero, model.Numero);
            Assert.Equal(entity.Cep, model.Cep);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var cepDto = Mapper.Map<CepDto>(entity);
            Assert.Equal(cepDto.Id, entity.Id);
            Assert.Equal(cepDto.Logradouro, entity.Logradouro);
            Assert.Equal(cepDto.Numero, entity.Numero);
            Assert.Equal(cepDto.Cep, entity.Cep);

            var cepDtoCompleto = Mapper.Map<CepDto>(listEntity.FirstOrDefault());
            Assert.Equal(cepDtoCompleto.Id, listEntity.FirstOrDefault().Id);
            Assert.Equal(cepDtoCompleto.Cep, listEntity.FirstOrDefault().Cep);
            Assert.Equal(cepDtoCompleto.Logradouro, listEntity.FirstOrDefault().Logradouro);
            Assert.Equal(cepDtoCompleto.Numero, listEntity.FirstOrDefault().Numero);
            Assert.NotNull(cepDtoCompleto.Municipio);
            Assert.NotNull(cepDtoCompleto.Municipio.Uf);

            var listDto = Mapper.Map<List<CepDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Cep, listEntity[i].Cep);
                Assert.Equal(listDto[i].Logradouro, listEntity[i].Logradouro);
                Assert.Equal(listDto[i].Numero, listEntity[i].Numero);
            }

            var cepDtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(cepDtoCreateResult.Id, entity.Id);
            Assert.Equal(cepDtoCreateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoCreateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoCreateResult.CreateAt, entity.CreateAt);

            var cepDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(cepDtoUpdateResult.Id, entity.Id);
            Assert.Equal(cepDtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto => Model
            var cepModel = Mapper.Map<CepModel>(cepDto);
            Assert.Equal(cepModel.Id, entity.Id);
            Assert.Equal(cepModel.Cep, entity.Cep);
            Assert.Equal(cepModel.Logradouro, entity.Logradouro);
            Assert.Equal("S/N", entity.Numero);

            var cepDtoCreate = Mapper.Map<CepDtoCreate>(cepModel);
            Assert.Equal(cepDtoCreate.Cep, cepModel.Cep);
            Assert.Equal(cepDtoCreate.Logradouro, cepModel.Logradouro);
            Assert.Equal(cepDtoCreate.Numero, cepModel.Numero);

            var cepDtoUpdate = Mapper.Map<CepDtoUpdate>(cepModel);
            Assert.Equal(cepDtoUpdate.Id, cepModel.Id);
            Assert.Equal(cepDtoUpdate.Cep, cepModel.Cep);
            Assert.Equal(cepDtoUpdate.Logradouro, cepModel.Logradouro);
            Assert.Equal(cepDtoUpdate.Numero, cepModel.Numero);
        }
    }
}
