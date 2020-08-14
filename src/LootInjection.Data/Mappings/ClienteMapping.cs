using LootInjection.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootInjection.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(c => c.OpcaoSexual)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Nacionalidade)
                .HasColumnType("int");

            builder.Property(c => c.Telefone)
                .HasColumnType("bigint");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("bigint");

            // 1 : 1 => Cliente : Endereco
            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente);

            // 1 : N => Cliente : Contas
            builder.HasMany(l => l.Contas)
                .WithOne(o => o.Cliente)
                .HasForeignKey(o => o.ClienteId);

            builder.ToTable("Clientes");
        }
    }
}