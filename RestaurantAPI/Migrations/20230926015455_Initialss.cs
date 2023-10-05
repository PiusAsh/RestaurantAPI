using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initialss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Orders_OrderId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryGuy_DeliveryGuyDetailsDeliveryGuyId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryGuy");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryGuyDetailsDeliveryGuyId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryGuyDetailsDeliveryGuyId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IsMarked",
                table: "Notification",
                newName: "IsRead");

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Orders_OrderId",
                table: "Notification",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Orders_OrderId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "Notification",
                newName: "IsMarked");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryGuyDetailsDeliveryGuyId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Notification",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DeliveryGuy",
                columns: table => new
                {
                    DeliveryGuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryGuyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryGuy", x => x.DeliveryGuyId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryGuyDetailsDeliveryGuyId",
                table: "Orders",
                column: "DeliveryGuyDetailsDeliveryGuyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Orders_OrderId",
                table: "Notification",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryGuy_DeliveryGuyDetailsDeliveryGuyId",
                table: "Orders",
                column: "DeliveryGuyDetailsDeliveryGuyId",
                principalTable: "DeliveryGuy",
                principalColumn: "DeliveryGuyId");
        }
    }
}
