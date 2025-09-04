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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(t => t.UID);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Description)
                .HasMaxLength(250);

            builder.Property(t => t.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.CreatedDate)
                .IsRequired();

            builder.Property(t => t.ModifiedDate)
                .IsRequired();

            builder.Property(t => t.DeletedDate);

            builder.Property(t => t.IsDeleted)
                .IsRequired();

            builder.HasOne(t => t.TransactionType)
                .WithMany()
                .HasForeignKey(t => t.TransactionTypeId);

        }
    }
}
