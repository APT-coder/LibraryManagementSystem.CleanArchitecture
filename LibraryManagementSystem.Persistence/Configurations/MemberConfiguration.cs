using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(m => m.Loans)
                .WithOne(l => l.Member)
                .HasForeignKey(l => l.MemberId);

            // Seed data for Member
            builder.HasData(
                new Member
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com"
                },
                new Member
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com"
                },
                new Member
                {
                    Id = 3,
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com"
                },
                new Member
                {
                    Id = 4,
                    Name = "Bob Williams",
                    Email = "bob.williams@example.com"
                },
                new Member
                {
                    Id = 5,
                    Name = "Charlie Brown",
                    Email = "charlie.brown@example.com"
                }
            );
        }
    }
}
