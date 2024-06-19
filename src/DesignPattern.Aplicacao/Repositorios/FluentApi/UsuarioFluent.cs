using DesignPattern.Aplicacao.Dominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPattern.Aplicacao.Repositorios.FluentApi
{
    internal class UsuarioFluent : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(p => p.Login)
              .HasColumnType($"varchar({Usuario.LoginMaxLenght})")
              .HasMaxLength(Usuario.LoginMaxLenght);

            builder.Property(p => p.Senha)
             .HasColumnType($"varchar({Usuario.SenhaMaxLenght})")
             .HasMaxLength(Usuario.SenhaMaxLenght);

            builder.Property(p => p.Nome)
             .HasColumnType($"varchar({Usuario.NomeMaxLenght})")
             .HasMaxLength(Usuario.NomeMaxLenght);

            builder.ToTable("Usuarios");
        }
    }
}
