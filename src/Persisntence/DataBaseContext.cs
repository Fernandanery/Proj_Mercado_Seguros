using Microsoft.EntityFrameworkCore;
using Proj_Mercado_Seguros.src.Models;

namespace Proj_Mercado_Seguros.src.Persisntence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext  (DbContextOptions <DataBaseContext> options)
            : base(options)
        {
            
        }
        public DbSet <Pessoa> Pessoas { get; set; }
        public DbSet <Contrato> Contratos { get; set; }
        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Pessoa> (tabela =>{
                tabela.HasKey(e => e.Id);
                tabela
                    .HasMany (e => e.contratos)
                    .WithOne ()
                    .HasForeignKey(c => c.PessoaId) ;

            });
            builder.Entity<Contrato> (tabela => {
                tabela.HasKey(e => e.Id) ;
                

            });

        }
    }
}