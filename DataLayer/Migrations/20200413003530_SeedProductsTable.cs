using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class SeedProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) " +
                "Values (1,'A', 1.25, 3, 3.00 )");
            migrationBuilder
                .Sql("INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) " +
                "Values (2,'B', 4.25, 1, 4.25 )");
            migrationBuilder
                .Sql("INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) " +
                "Values (3,'C', 1.00, 6, 5.00 )");
            migrationBuilder
                .Sql("INSERT INTO Products (Id,CodeName, UnitPrice, DiscountQtyBase, UnitDiscount) " +
                "Values (4,'D', 0.75, 1, 0.75 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Products");
        }
    }
}
