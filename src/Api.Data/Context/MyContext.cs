using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Data.Mapping;
using Data.Seeds;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class Mycontext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public Mycontext(DbContextOptions<Mycontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
              new UserEntity
              {
                  Id = Guid.NewGuid(),
                  Name = "Administrador",
                  Email = "wslmacieira@gmail.com",
                  CreateAt = DateTime.Now,
                  UpdateAt = DateTime.Now
              }
            );

            UfSeeds.Ufs(modelBuilder);
        }
    }
}
