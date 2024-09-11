using LibraryManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManagementSystem.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.DateOfBirth)
                .IsRequired();

            builder.Property(a => a.Bio)
                .HasMaxLength(1000);

            // Seed data for Author
            builder.HasData(
                new Author
                {
                    Id = 1,
                    Name = "George Orwell",
                    DateOfBirth = new DateTime(1903, 6, 25, 0, 0, 0, DateTimeKind.Utc),
                    Bio = "English novelist, essayist, journalist, and critic.",
                },
                new Author
                {
                    Id = 2,
                    Name = "J.K. Rowling",
                    DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, DateTimeKind.Utc),
                    Bio = "British author, best known for the Harry Potter series.",
                },
                new Author
                {
                    Id = 3,
                    Name = "Agatha Christie",
                    DateOfBirth = new DateTime(1890, 9, 15, 0, 0, 0, DateTimeKind.Utc),
                    Bio = "English writer known for her 66 detective novels.",
                },
                new Author
                {
                    Id = 4,
                    Name = "Leo Tolstoy",
                    DateOfBirth = new DateTime(1828, 9, 9, 0, 0, 0, DateTimeKind.Utc),
                    Bio = "Russian writer, best known for 'War and Peace' and 'Anna Karenina'.",
                },
                new Author
                {
                    Id = 5,
                    Name = "Mark Twain",
                    DateOfBirth = new DateTime(1835, 11, 30, 0, 0, 0, DateTimeKind.Utc),
                    Bio = "American writer, humorist, and lecturer, best known for 'The Adventures of Tom Sawyer'.",
                }
            );
        }
    }
}
