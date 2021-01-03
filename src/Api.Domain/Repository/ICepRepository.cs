using System;
using System.Threading.Tasks;
using Domain.Entities;
using src.Api.Domain.Interfaces;

namespace Domain.Repository
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
    }
}
