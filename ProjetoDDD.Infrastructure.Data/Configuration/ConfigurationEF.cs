using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Infrastructure.Data.Configuration
{
    public class ModulosAcessoMap : EntityTypeConfiguration<ModulosAcesso>
    {
        public ModulosAcessoMap()
        {
            this.Haskey(t => t.IdModulo);

            this.Property(t => t.NomeModulo)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.NomeMenuAcesso)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.UrlMenu)
                .IsRequired()
                .HasMaxLength(300);

            this.ToTable("ModuloAcesso", "dbo");

            this.HasMany(t => t.PerfilUsuario)
                .WithMany(t => t.ModulosAcesso)
                .Map(m =>
                {
                    m.ToTable("PerfilModulos", "dbo");
                    m.MapLeftKey("idModulo");
                    m.MapRightKey("idPerfilusuario");
                }
                    
                );
        }

    }
}
