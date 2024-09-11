using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "CreatedDate", "DateOfBirth", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "English novelist, essayist, journalist, and critic.", new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(2323), new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), "George Orwell", null },
                    { 2, "British author, best known for the Harry Potter series.", new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(2331), new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "J.K. Rowling", null },
                    { 3, "English writer known for her 66 detective novels.", new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(2332), new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Agatha Christie", null },
                    { 4, "Russian writer, best known for 'War and Peace' and 'Anna Karenina'.", new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(2365), new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Leo Tolstoy", null },
                    { 5, "American writer, humorist, and lecturer, best known for 'The Adventures of Tom Sawyer'.", new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(2367), new DateTime(1835, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Mark Twain", null }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(4371), "john.doe@example.com", "John Doe", null },
                    { 2, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(4374), "jane.smith@example.com", "Jane Smith", null },
                    { 3, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(4374), "alice.johnson@example.com", "Alice Johnson", null },
                    { 4, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(4375), "bob.williams@example.com", "Bob Williams", null },
                    { 5, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(4376), "charlie.brown@example.com", "Charlie Brown", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(3391), "1984", null },
                    { 2, 2, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(3393), "Harry Potter and the Philosopher's Stone", null },
                    { 3, 3, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(3394), "Murder on the Orient Express", null },
                    { 4, 4, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(3395), "War and Peace", null },
                    { 5, 5, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(3396), "The Adventures of Tom Sawyer", null }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookId", "CreatedDate", "LoanDate", "MemberId", "ReturnDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5756), new DateTime(2024, 9, 1, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5758), 1, new DateTime(2024, 9, 8, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5765), null },
                    { 2, 2, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5768), new DateTime(2024, 9, 4, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5769), 2, null, null },
                    { 3, 3, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5770), new DateTime(2024, 8, 27, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5771), 3, new DateTime(2024, 9, 6, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5771), null },
                    { 4, 1, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5772), new DateTime(2024, 9, 8, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5772), 4, null, null },
                    { 5, 5, new DateTime(2024, 9, 11, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5773), new DateTime(2024, 8, 22, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5774), 5, new DateTime(2024, 9, 9, 11, 28, 12, 743, DateTimeKind.Utc).AddTicks(5774), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberId",
                table: "Loans",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
