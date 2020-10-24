using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leilao.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    update_at = table.Column<DateTime>(nullable: true),
                    create_at = table.Column<DateTime>(nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    xmin = table.Column<uint>(type: "xid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publicsales",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    update_at = table.Column<DateTime>(nullable: true),
                    create_at = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    inital_value = table.Column<double>(nullable: false),
                    used = table.Column<bool>(nullable: false),
                    responsible_user_id = table.Column<Guid>(nullable: false),
                    xmin = table.Column<uint>(type: "xid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_public_sale_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_public_sale_entity_user_entity_responsible_user_id",
                        column: x => x.responsible_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_public_sale_entity_responsible_user_id",
                table: "publicsales",
                column: "responsible_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "publicsales");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
