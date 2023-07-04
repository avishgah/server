using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    toun = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phon = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    tz = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    dateBirth = table.Column<DateTime>(type: "date", nullable: true),
                    pic = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    isManager = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    readTerms = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datePay = table.Column<DateTime>(type: "date", nullable: true),
                    code = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    idCust = table.Column<int>(type: "int", nullable: true),
                    endSum = table.Column<int>(type: "int", nullable: true),
                    isPay = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_orders",
                        column: x => x.idCust,
                        principalTable: "customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bike",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    battery = table.Column<int>(type: "int", nullable: true),
                    idStation = table.Column<int>(type: "int", nullable: true),
                    DateStart = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bike", x => x.id);
                    table.ForeignKey(
                        name: "FK_bike_stations",
                        column: x => x.idStation,
                        principalTable: "stations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "opinion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    idCust = table.Column<int>(type: "int", nullable: true),
                    idStation = table.Column<int>(type: "int", nullable: true),
                    caption = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    satisfactionLeve = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opinion", x => x.id);
                    table.ForeignKey(
                        name: "FK_opinion_customers",
                        column: x => x.id,
                        principalTable: "customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_opinion_stations",
                        column: x => x.idStation,
                        principalTable: "stations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_bike",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    dateStart = table.Column<DateTime>(type: "date", nullable: true),
                    dateEnd = table.Column<DateTime>(type: "date", nullable: true),
                    idBike = table.Column<int>(type: "int", nullable: true),
                    idPay = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    idStation = table.Column<int>(type: "int", nullable: true),
                    sum = table.Column<int>(type: "int", nullable: true),
                    dateOrder = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_bike", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_bike_bike",
                        column: x => x.id,
                        principalTable: "bike",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_order_bike_orders",
                        column: x => x.idPay,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_order_bike_stations",
                        column: x => x.idStation,
                        principalTable: "stations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bike_idStation",
                table: "bike",
                column: "idStation");

            migrationBuilder.CreateIndex(
                name: "IX_opinion_idStation",
                table: "opinion",
                column: "idStation");

            migrationBuilder.CreateIndex(
                name: "IX_order_bike_idPay",
                table: "order_bike",
                column: "idPay");

            migrationBuilder.CreateIndex(
                name: "IX_order_bike_idStation",
                table: "order_bike",
                column: "idStation");

            migrationBuilder.CreateIndex(
                name: "IX_orders_idCust",
                table: "orders",
                column: "idCust");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "opinion");

            migrationBuilder.DropTable(
                name: "order_bike");

            migrationBuilder.DropTable(
                name: "bike");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
