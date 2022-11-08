using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.WebApi.Angular.Migrations
{
    public partial class CreateShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ffdeb4a-2b28-4fc8-9d41-30bd16984923"),
                column: "ConcurrencyStamp",
                value: "2394e4ac-4218-4950-afbd-50ffce013ac2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08d68e62-6e3b-4cf4-bfb0-49d59f670a5b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3da4a16d-6c68-4846-8681-48b0a74134ed", "AQAAAAEAACcQAAAAEJ+TRXRjZZ8K5Rkw9XxcIRT4AWki52/WFaP+U0GU2LsNlVfM88SQ+RRg3cCLko5Qmg==" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ffdeb4a-2b28-4fc8-9d41-30bd16984923"),
                column: "ConcurrencyStamp",
                value: "254a1351-77da-4b1f-b347-76876280c0a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("08d68e62-6e3b-4cf4-bfb0-49d59f670a5b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9e6a71d-84c7-4b3b-97c4-f135752c6d07", "AQAAAAEAACcQAAAAEA3akXgm/NdlnRfPdOOoPnnIkBI6/6VrsO3H9bd3J0nCKi7y+LDqdaP5WmILHFUKnA==" });
        }
    }
}
