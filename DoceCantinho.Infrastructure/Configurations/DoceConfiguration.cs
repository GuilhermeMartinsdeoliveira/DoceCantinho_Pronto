using DoceCantinho.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoceCantinho.Infrastructure.Configurations
{
    public class DoceConfiguration : IEntityTypeConfiguration<Doce>
    {
        public void Configure(EntityTypeBuilder<Doce> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(g => g.Description)
                .HasMaxLength(2000);

            // IMPORTANTE:
            // Imagens locais são convertidas para Base64.
            // Base64 pode ultrapassar facilmente 500 caracteres.
            // Por isso o campo precisa ser NVARCHAR(MAX).
            builder.Property(g => g.CoverImageUrl)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(g => g.IsRecomendado)
                .HasDefaultValue(false);

            builder.HasOne(g => g.Category)
                .WithMany(c => c.Doces)
                .HasForeignKey(g => g.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}