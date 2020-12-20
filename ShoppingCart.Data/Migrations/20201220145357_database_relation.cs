using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Data.Migrations
{
    public partial class database_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShoppingCartDetail_ShoppingCartId",
                table: "Tbl_ShoppingCartDetail",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ShoppingCartDetail_Tbl_ShoppingCart_ShoppingCartId",
                table: "Tbl_ShoppingCartDetail",
                column: "ShoppingCartId",
                principalTable: "Tbl_ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ShoppingCartDetail_Tbl_ShoppingCart_ShoppingCartId",
                table: "Tbl_ShoppingCartDetail");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_ShoppingCartDetail_ShoppingCartId",
                table: "Tbl_ShoppingCartDetail");
        }
    }
}
