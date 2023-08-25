using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RichDomain.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RichDomain");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "RichDomain",
                columns: table => new
                {
                    id_customer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(70)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(70)", nullable: false),
                    customer_type = table.Column<byte>(type: "tinyint", nullable: false),
                    cell_phone = table.Column<string>(type: "Varchar(14)", nullable: true),
                    phone_number = table.Column<string>(type: "Varchar(12)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id_customer);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                schema: "RichDomain",
                columns: table => new
                {
                    id_email = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.id_email);
                    table.ForeignKey(
                        name: "FK_Email_Customer_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "RichDomain",
                        principalTable: "Customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email_customer_id",
                schema: "RichDomain",
                table: "Email",
                column: "customer_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email",
                schema: "RichDomain");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "RichDomain");
        }
    }
}
