using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoDDD.Infrastructure.Data.Context
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco() : base("projetoDDDContext")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<ModulosAcesso> ModulosAcesso { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>(); 
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); 
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
               .Where(p => p.Name == p.ReflectedType.Name + "Id")  // Cliente_Id e uma chave primária
               .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar")); // tudo que for string vai ser tipo varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100)); // tamanho do campo para string

            modelBuilder.Properties<string>().Where(p => p.Name.Contains("Descricao")).Configure(p => p.HasMaxLength(400));
            modelBuilder.Properties<string>().Where(p => p.Name.Contains("UF")).Configure(p => p.HasMaxLength(2));




            base.OnModelCreating(modelBuilder);
        }

    }
}
