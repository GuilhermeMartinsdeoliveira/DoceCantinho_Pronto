using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;
using DoceCantinho.Domain.Interfaces;

namespace DoceCantinho.Infrastructure.Configurations
{
    public class DoceConfiguration : IEntityTypeConfiguration<Doce>
    {
        public void Configure(EntityTypeBuilder<Doce> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title)
                .IsRequired() // Define que o campo é obrigatório
                .HasMaxLength(200); // Define um tamanho máximo para o campo

            builder.Property(g => g.Description)
                .HasMaxLength(2000); // Define um tamanho máximo para o campo

            builder.Property(g => g.CoverImageUrl)
                .HasMaxLength(500); // Define um tamanho máximo para o campo

            builder.Property(g => g.IsRecomendado)
                .HasDefaultValue(false);

            builder.HasOne(g => g.Category) // UM game tem UMA categoria
                .WithMany(c => c.Doces) // UMA categoria tem MUITOS games 
                .HasForeignKey(g => g.CategoryId) // a FK é CategoryId
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
