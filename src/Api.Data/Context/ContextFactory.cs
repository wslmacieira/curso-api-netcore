using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<Mycontext>
    {
        public Mycontext CreateDbContext(string[] args)
        {
            //Usado para criar as Migrações
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=gostack";
            //var connectionString = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=CursoApiNetcore;Integrated Security=true";
            var optionsBuilder = new DbContextOptionsBuilder<Mycontext>();
            optionsBuilder.UseMySql(connectionString);
            //optionsBuilder.UseSqlServer(connectionString);
            return new Mycontext(optionsBuilder.Options);
        }
    }
}
