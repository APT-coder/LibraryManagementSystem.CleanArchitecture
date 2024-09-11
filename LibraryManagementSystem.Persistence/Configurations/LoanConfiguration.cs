using LibraryManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.LoanDate)
                .IsRequired();

            builder.Property(l => l.ReturnDate)
                .IsRequired(false);

            builder.HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Member)
                .WithMany(m => m.Loans)
                .HasForeignKey(l => l.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for Loan
            builder.HasData(
                new Loan
                {
                    Id = 1,
                    BookId = 1,
                    MemberId = 1,
                    LoanDate = DateTime.UtcNow.AddDays(-10),
                    ReturnDate = DateTime.UtcNow.AddDays(-3)
                },
                new Loan
                {
                    Id = 2,
                    BookId = 2,
                    MemberId = 2,
                    LoanDate = DateTime.UtcNow.AddDays(-7),
                    ReturnDate = null
                },
                new Loan
                {
                    Id = 3,
                    BookId = 3,
                    MemberId = 3,
                    LoanDate = DateTime.UtcNow.AddDays(-15),
                    ReturnDate = DateTime.UtcNow.AddDays(-5)
                },
                new Loan
                {
                    Id = 4,
                    BookId = 1,
                    MemberId = 4,
                    LoanDate = DateTime.UtcNow.AddDays(-3),
                    ReturnDate = null
                },
                new Loan
                {
                    Id = 5,
                    BookId = 5,
                    MemberId = 5,
                    LoanDate = DateTime.UtcNow.AddDays(-20),
                    ReturnDate = DateTime.UtcNow.AddDays(-2)
                }
            );
        }
    }
}
