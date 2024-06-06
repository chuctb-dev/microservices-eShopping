using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopping.Discount.Api.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        private static readonly Guid Row1 = Guid.NewGuid();
        private static readonly Guid Row2 = Guid.NewGuid();
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "coupons",
            columns: ["id", "product_id", "product_name", "description", "amount"],
            values: new object[,]
            {
                { Row1, "602d2149e773f2a3990b47f5", "Adidas Quick Force Indoor Badminton Shoes", "", 500 },
                { Row2, "972d2149e773f2a3990b47fa", "Babolat Shadow Tour Mens Badminton Shoes (White/Blue)", "", 249 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "coupons",
            keyColumn: "id",
            keyValue: Row1);

            migrationBuilder.DeleteData(
            table: "coupons",
            keyColumn: "id",
            keyValue: Row2);
        }
    }
}
