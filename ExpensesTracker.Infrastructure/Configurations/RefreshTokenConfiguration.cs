using ExpensesTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Infrastructure.Configurations
{
    public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).IsRequired();

            builder.Property(r => r.Token).HasMaxLength(200);

            builder.HasIndex(r => r.Token).IsUnique();

            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
        }
    }
}
