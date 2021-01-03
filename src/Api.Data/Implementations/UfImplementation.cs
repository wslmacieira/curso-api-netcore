using System;
using Api.Data.Context;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using src.Api.Data.Repository;

namespace Data.Implementations
{
    public class UfImplementation : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _dataset;

        public UfImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UfEntity>();
        }
    }
}
