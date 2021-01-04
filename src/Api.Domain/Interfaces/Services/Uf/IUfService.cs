using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos.Uf;

namespace Domain.Interfaces.Services.Uf
{
    public interface IUfService
    {
        Task<UfDto> Get(Guid id);
        Task<IEnumerable<UfDto>> GetAll();
    }
}
