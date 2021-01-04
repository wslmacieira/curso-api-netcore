using System;
using System.Collections.Generic;
using Domain.Dtos.Cep;
using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;

namespace Api.Service.Test.Cep
{
    public class CepTestes
    {
        public static string Cep { get; set; }
        public static string Logradouro { get; set; }
        public static string Numero { get; set; }
        public static string CepAlterado { get; set; }
        public static string LogradouroAlterado { get; set; }
        public static string NumeroAlterado { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static Guid IdCep { get; set; }

        public List<CepDto> listaDto = new List<CepDto>();
        public CepDto cepDto;
        public CepDtoCreate cepDtoCreate;
        public CepDtoCreateResult cepDtoCreateResult;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoUpdateResult cepDtoUpdateResult;

        public CepTestes()
        {
            IdMunicipio = Guid.NewGuid();
            IdCep = Guid.NewGuid();
            Cep = Faker.RandomNumber.Next(1, 99999).ToString();
            Numero = Faker.RandomNumber.Next(1, 1000).ToString();
            Logradouro = Faker.Address.StreetName();
            CepAlterado = Faker.RandomNumber.Next(1, 99999).ToString();
            NumeroAlterado = Faker.RandomNumber.Next(1, 1000).ToString();
            LogradouroAlterado = Faker.Address.StreetName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CepDto
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 99999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 1000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = IdMunicipio,
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 2)
                        }
                    }
                };
                listaDto.Add(dto);
            }

            cepDto = new CepDto
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = IdMunicipio,
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 2)
                    }
                }
            };

            cepDtoCreate = new CepDtoCreate
            {
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio,
            };

            cepDtoCreateResult = new CepDtoCreateResult
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio,
                CreateAt = DateTime.UtcNow
            };

            cepDtoUpdate = new CepDtoUpdate
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio,
            };

            cepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
