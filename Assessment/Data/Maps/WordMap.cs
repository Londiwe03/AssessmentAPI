using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data
{
    internal sealed class WordMap : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(p => p.WordType)
                .IsRequired(true);


            builder.Property(p => p.Data)
                .IsRequired(true);


            builder.ToTable("Word", "dbo");
        }
    }
}
