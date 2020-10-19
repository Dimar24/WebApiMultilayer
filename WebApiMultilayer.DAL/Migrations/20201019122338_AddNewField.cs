using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiMultilayer.DAL.Migrations
{
    public partial class AddNewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_ClientProfiles_clientProfileId",
                table: "Autos");

            migrationBuilder.RenameColumn(
                name: "clientProfileId",
                table: "Autos",
                newName: "ClientProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Autos_clientProfileId",
                table: "Autos",
                newName: "IX_Autos_ClientProfileId");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Autos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Autos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autos_UserId",
                table: "Autos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_ClientProfiles_ClientProfileId",
                table: "Autos",
                column: "ClientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_AspNetUsers_UserId",
                table: "Autos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_ClientProfiles_ClientProfileId",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_Autos_AspNetUsers_UserId",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_UserId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Autos");

            migrationBuilder.RenameColumn(
                name: "ClientProfileId",
                table: "Autos",
                newName: "clientProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Autos_ClientProfileId",
                table: "Autos",
                newName: "IX_Autos_clientProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_ClientProfiles_clientProfileId",
                table: "Autos",
                column: "clientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
