using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopMarket.Migrations
{
    public partial class InsertDataAndCreateKeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cateories",
                columns: new[] { "id", "Discription", "Name" },
                values: new object[] { 1, "Asp.NetCore 3", "Asp.Net Core" });

            migrationBuilder.InsertData(
                table: "cateories",
                columns: new[] { "id", "Discription", "Name" },
                values: new object[] { 2, "Asp.Net Mvc", "Asp.Net Mvc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cateories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cateories",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
