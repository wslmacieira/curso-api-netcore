using System;
using System.Collections.Generic;
using Domain.Dtos.Uf;

namespace Api.Service.Test.Uf
{
    public class UfTestes
    {
        public static string Nome { get; set; }
        public static string Sigla { get; set; }
        public static Guid UfId { get; set; }
        public List<UfDto> listUfDto = new List<UfDto>();
        public UfDto ufDto { get; set; }

        public UfTestes()
        {
            Nome = Faker.Address.UsState();
            Sigla = Faker.Address.UsState().Substring(1, 2);
            UfId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var item = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 2)
                };
                listUfDto.Add(item);
            };

            ufDto = new UfDto
            {
                Id = UfId,
                Nome = Nome,
                Sigla = Sigla
            };
        }
    }
}
