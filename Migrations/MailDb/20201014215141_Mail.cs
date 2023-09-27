using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistroLabb2.Migrations.MailDb
{
    public partial class Mail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    amountMonthlyLogin = table.Column<int>(nullable: false),
                    amountDeletedMessage = table.Column<int>(nullable: false),
                    nameOfUser = table.Column<string>(nullable: true),
                    latestLoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    theTimeStamp = table.Column<DateTime>(nullable: false),
                    header = table.Column<string>(nullable: true),
                    messageWasRead = table.Column<bool>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    fromUserid = table.Column<string>(nullable: true),
                    toUserid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_users_fromUserid",
                        column: x => x.fromUserid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_messages_users_toUserid",
                        column: x => x.toUserid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_fromUserid",
                table: "messages",
                column: "fromUserid");

            migrationBuilder.CreateIndex(
                name: "IX_messages_toUserid",
                table: "messages",
                column: "toUserid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
