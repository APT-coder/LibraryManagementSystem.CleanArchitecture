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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            // Configure required properties
            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            // Configure the relationship with Author using the AuthorId as a foreign key
            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading deletes

            // Seed data for Book
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "1984",
                    AuthorId = 1,
                },
                new Book
                {
                    Id = 2,
                    Title = "Harry Potter and the Philosopher's Stone",
                    AuthorId = 2,
                },
                new Book
                {
                    Id = 3,
                    Title = "Murder on the Orient Express",
                    AuthorId = 3,
                },
                new Book
                {
                    Id = 4,
                    Title = "War and Peace",
                    AuthorId = 4,
                },
                new Book
                {
                    Id = 5,
                    Title = "The Adventures of Tom Sawyer",
                    AuthorId = 5,
                }
            );
        }
    }
}
