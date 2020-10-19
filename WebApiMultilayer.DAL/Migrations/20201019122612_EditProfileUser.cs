using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiMultilayer.DAL.Migrations
{
    public partial class EditProfileUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_ClientProfiles_ClientProfileId",
                table: "Autos");

            migrationBuilder.DropTable(
                name: "ClientProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Autos_ClientProfileId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "ClientProfileId",
                table: "Autos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientProfileId",
                table: "Autos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProfiles_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_ClientProfileId",
                table: "Autos",
                column: "ClientProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_ClientProfiles_ClientProfileId",
                table: "Autos",
                column: "ClientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
