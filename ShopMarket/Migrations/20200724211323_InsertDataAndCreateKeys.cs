using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopMarket.Migrations
{
    public partial class InsertDataAndCreateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cateories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cateories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    QuantityInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categorytoProducts",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorytoProducts", x => new { x.productId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_categorytoProducts_cateories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "cateories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categorytoProducts_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "Price", "QuantityInStock" },
                values: new object[] { 1, 854.0m, 5 });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "Price", "QuantityInStock" },
                values: new object[] { 2, 3302.0m, 8 });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "Price", "QuantityInStock" },
                values: new object[] { 3, 2500m, 3 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "Description", "ItemId", "Name" },
                values: new object[] { 1, "آموزش ASP.Net", 1, "Learning" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "Description", "ItemId", "Name" },
                values: new object[] { 2, "آموزش Blazer", 2, "Learning Blazer" });

            migrationBuilder.CreateIndex(
                name: "IX_categorytoProducts_CategoryId",
                table: "categorytoProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ItemId",
                table: "products",
                column: "ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorytoProducts");

            migrationBuilder.DropTable(
                name: "cateories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
