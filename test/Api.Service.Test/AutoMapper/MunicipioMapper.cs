using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Dtos.Municipio;
using Domain.Entities;
using Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelo de Municipio")]
        public void E_Possivel_Mapear_os_Modelos_Municipio()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 2)
                    }
                };
                listEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var municipioDto = Mapper.Map<MunicipioDto>(entity);
            Assert.Equal(municipioDto.Id, entity.Id);
            Assert.Equal(municipioDto.Nome, entity.Nome);
            Assert.Equal(municipioDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(municipioDto.UfId, entity.UfId);

            var municipioDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listEntity.FirstOrDefault());
            Assert.Equal(municipioDtoCompleto.Id, listEntity.FirstOrDefault().Id);
            Assert.Equal(municipioDtoCompleto.Nome, listEntity.FirstOrDefault().Nome);
            Assert.Equal(municipioDtoCompleto.CodIBGE, listEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(municipioDtoCompleto.UfId, listEntity.FirstOrDefault().UfId);
            Assert.NotNull(municipioDtoCompleto.Uf);

            var listDto = Mapper.Map<List<MunicipioDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listDto[i].Id);
                Assert.Equal(listDto[i].Nome, listDto[i].Nome);
                Assert.Equal(listDto[i].CodIBGE, listDto[i].CodIBGE);
                Assert.Equal(listDto[i].UfId, listDto[i].UfId);
            }

            var municipioDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(municipioDtoCreateResult.Id, entity.Id);
            Assert.Equal(municipioDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(municipioDtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(municipioDtoCreateResult.UfId, entity.UfId);
            Assert.Equal(municipioDtoCreateResult.CreateAt, entity.CreateAt);

            var municipioDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(municipioDtoUpdateResult.Id, entity.Id);
            Assert.Equal(municipioDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(municipioDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(municipioDtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(municipioDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto para Model
            var municipioModel = Mapper.Map<MunicipioModel>(municipioDto);
            Assert.Equal(municipioModel.Id, municipioDto.Id);
            Assert.Equal(municipioModel.Nome, municipioDto.Nome);
            Assert.Equal(municipioModel.CodIBGE, municipioDto.CodIBGE);
            Assert.Equal(municipioModel.UfId, municipioDto.UfId);

            var municipioDtoCreate = Mapper.Map<MunicipioDtoCreate>(municipioModel);
            Assert.Equal(municipioDtoCreate.Nome, municipioModel.Nome);
            Assert.Equal(municipioDtoCreate.CodIBGE, municipioModel.CodIBGE);
            Assert.Equal(municipioDtoCreate.UfId, municipioModel.UfId);

            var municipioDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(municipioModel);
            Assert.Equal(municipioDtoUpdate.Id, municipioModel.Id);
            Assert.Equal(municipioDtoUpdate.Nome, municipioModel.Nome);
            Assert.Equal(municipioDtoUpdate.CodIBGE, municipioModel.CodIBGE);
            Assert.Equal(municipioDtoUpdate.UfId, municipioModel.UfId);
        }
    }
}
