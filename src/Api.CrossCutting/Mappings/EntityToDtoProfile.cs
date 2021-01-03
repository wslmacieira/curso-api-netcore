using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;
using Domain.Dtos.Cep;
using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
using Domain.Entities;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
            #endregion

            #region  UF
            CreateMap<UfDto, UfEntity>()
            .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioDto, MunicipioEntity>()
                .ReverseMap();
            CreateMap<MunicipioDtoCompleto, MunicipioEntity>()
                .ReverseMap();
            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>()
                .ReverseMap();
            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>()
                .ReverseMap();
            #endregion

            #region CEP
            CreateMap<CepDto, CepEntity>()
                .ReverseMap();
            CreateMap<CepDtoCreateResult, CepEntity>()
                .ReverseMap();
            CreateMap<CepDtoUpdateResult, CepEntity>()
                .ReverseMap();
            #endregion
        }
    }
}
