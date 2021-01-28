using Microsoft.EntityFrameworkCore;

namespace crudPessoaFisica.Models
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
        }

        public DbSet<PessoaFisica> PessoaFisica { get; set; }
    }
}
