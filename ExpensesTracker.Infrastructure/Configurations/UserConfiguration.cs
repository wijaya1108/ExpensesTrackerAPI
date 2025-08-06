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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Define table name
            builder.ToTable("Users");

            //set primary key
            builder.HasKey(u => u.UID);

            //configure properties
            builder.Property(u => u.FirstName)
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Address)
                .HasMaxLength(200);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.CreatedDate)
                .IsRequired();

            builder.Property(u => u.IsDeleted)
                .IsRequired();

            // Optional: Add indexes for better query performance
            builder.HasIndex(u => u.Email)
                .IsUnique(); // Enforces uniqueness at the database level
        }
    }
}
