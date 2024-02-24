using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<bool>(type: "bit", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceHDRId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Invoices_InvoiceHDRId",
                        column: x => x.InvoiceHDRId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "Customer", "Description", "InvoiceDate", "PaymentMethod" },
                values: new object[] { 1, "Ali", "description field", new DateTime(2024, 2, 21, 11, 58, 52, 832, DateTimeKind.Local).AddTicks(1213), true });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "Customer", "Description", "InvoiceDate", "PaymentMethod" },
                values: new object[] { 2, "Nour", "description field", new DateTime(2024, 2, 21, 11, 58, 52, 832, DateTimeKind.Local).AddTicks(1252), true });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "Customer", "Description", "InvoiceDate", "PaymentMethod" },
                values: new object[] { 5, "Ahmed", "description field##", new DateTime(2024, 2, 21, 11, 58, 52, 832, DateTimeKind.Local).AddTicks(1249), false });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "InvoiceHDRId", "ItemName", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, 1, "bread", 10m, 20 },
                    { 2, 5, "tea", 20m, 20 },
                    { 3, 1, "milk", 10m, 10 },
                    { 9, 2, "cup", 10m, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_InvoiceHDRId",
                table: "Items",
                column: "InvoiceHDRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
