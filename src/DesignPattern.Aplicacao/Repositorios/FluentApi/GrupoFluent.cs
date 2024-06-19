using DesignPattern.Aplicacao.Dominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPattern.Aplicacao.Repositorios.FluentApi
{
    internal class GrupoFluent : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {

            builder.Property(p => p.Descricao)
                .HasColumnType($"varchar({Grupo.DescricaoMaxLenght})")
                .HasMaxLength(Grupo.DescricaoMaxLenght);

            builder.ToTable("Grupos");
        }
    }
}
