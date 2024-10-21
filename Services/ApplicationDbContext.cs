using Microsoft.EntityFrameworkCore;
using Pim_Web.Models;

namespace Pim_Web.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Insumos> Insumos { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ofertas> Ofertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Name).HasMaxLength(50);
                tb.Property(col => col.Email).HasMaxLength(50);
                tb.Property(col => col.Telefone).HasMaxLength(50);
                tb.Property(col => col.Adress).HasMaxLength(50);
                tb.Property(col => col.Cpf).HasMaxLength(50);
                tb.Property(col => col.DataNasc).HasMaxLength(50);
                tb.Property(col => col.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
        }
    }
}
