using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneSale.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Users (Id, Name, Email)
                VALUES ('A3B03D73-8F24-4A7B-A493-B55E9AD31E40', 'John Doe', 'john.doe@example.com')
            ");
            migrationBuilder.Sql(@"
                INSERT INTO Products (Id, Name, Price)
                VALUES
                ('1A4CD040-8A7A-4C9A-8D7E-72EEF3ADB0CB', 'Laptop', 1200.00),
                ('A387DE31-9ED4-40F0-A64D-EBA2C93A2B10', 'Tablet', 600.00)
            ");
            migrationBuilder.Sql(@"
                INSERT INTO Orders (Id, UserId, Total)
                VALUES ('2B5CD140-9B8B-5D9A-9E8F-83F3F4B1C1DA', 'A3B03D73-8F24-4A7B-A493-B55E9AD31E40', 2000.00)
            ");
            migrationBuilder.Sql(@"
                INSERT INTO Items (Id, ProductId, Quantity, DiscountedPrice, OrderId)
                VALUES
                (NEWID(), '1A4CD040-8A7A-4C9A-8D7E-72EEF3ADB0CB', 1, 1200.00,'2B5CD140-9B8B-5D9A-9E8F-83F3F4B1C1DA')
      
            ");

            // Orden 2
            migrationBuilder.Sql(@"
                INSERT INTO Orders (Id, UserId, Total)
                VALUES ('3C6DE250-AC9C-4E8A-BF2E-94F4E5C2D2EB', 'A3B03D73-8F24-4A7B-A493-B55E9AD31E40', 2000.00)
            ");

            // Inserción de ítems para la orden 2
            migrationBuilder.Sql(@"
                INSERT INTO Items (Id, ProductId, Quantity, DiscountedPrice, OrderId)
                VALUES
                (NEWID(), 'A387DE31-9ED4-40F0-A64D-EBA2C93A2B10', 1, 600.00, '3C6DE250-AC9C-4E8A-BF2E-94F4E5C2D2EB')"
        );
        }

    }
}
