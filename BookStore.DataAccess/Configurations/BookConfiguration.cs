using BookStore.Core.Models;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Titel)
                .HasMaxLength(Book.MAX_TITEL_LENGHT)
                .IsRequired();
            builder.Property(b => b.Price)
                .IsRequired();
            builder.Property(b => b.Description)
                .IsRequired();
        }
    }
}
