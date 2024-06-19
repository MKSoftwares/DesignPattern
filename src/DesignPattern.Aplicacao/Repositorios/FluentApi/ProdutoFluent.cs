using DesignPattern.Aplicacao.Dominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPattern.Aplicacao.Repositorios.FluentApi
{
    internal class ProdutoFluent : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Descricao)
               .HasColumnType($"varchar({Produto.DescricaoMaxLenght})")
               .HasMaxLength(Grupo.DescricaoMaxLenght);

            builder.Property(p => p.Preco)
              .HasColumnType("decimal(15,4)");

            builder.ToTable("Produtos");
        }
    }
}
