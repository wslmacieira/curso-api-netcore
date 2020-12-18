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
            var optionsBuilder = new DbContextOptionsBuilder<Mycontext>();
            optionsBuilder.UseMySql(connectionString);
            return new Mycontext(optionsBuilder.Options);
        }
    }
}
