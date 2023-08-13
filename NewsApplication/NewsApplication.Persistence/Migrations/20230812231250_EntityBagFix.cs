using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApplication.Persistence.Migrations
{
    public partial class EntityBagFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementId",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementId1",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Files_FileId",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Files_FileId1",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Announcements_AnnouncementId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_AnnouncementId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId1",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_AnnouncementId1",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnnouncementId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementFiles_AnnouncementId1",
                table: "AnnouncementFiles");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementFiles_FileId1",
                table: "AnnouncementFiles");

            migrationBuilder.DropColumn(
                name: "AnnouncementId1",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "AnnouncementId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnnouncementId1",
                table: "AnnouncementFiles");

            migrationBuilder.DropColumn(
                name: "FileId1",
                table: "AnnouncementFiles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Announcements",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementId",
                table: "AnnouncementFiles",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Files_FileId",
                table: "AnnouncementFiles",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Announcements_AnnouncementId",
                table: "Comments",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId",
                table: "Likes",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementId",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Files_FileId",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Announcements_AnnouncementId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId1",
                table: "Likes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId1",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Announcements",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId1",
                table: "AnnouncementFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileId1",
                table: "AnnouncementFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AnnouncementId1",
                table: "Likes",
                column: "AnnouncementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnnouncementId1",
                table: "Comments",
                column: "AnnouncementId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementFiles_AnnouncementId1",
                table: "AnnouncementFiles",
                column: "AnnouncementId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementFiles_FileId1",
                table: "AnnouncementFiles",
                column: "FileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementId",
                table: "AnnouncementFiles",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementId1",
                table: "AnnouncementFiles",
                column: "AnnouncementId1",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Files_FileId",
                table: "AnnouncementFiles",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Files_FileId1",
                table: "AnnouncementFiles",
                column: "FileId1",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Announcements_AnnouncementId1",
                table: "Comments",
                column: "AnnouncementId1",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_AnnouncementId",
                table: "Comments",
                column: "AnnouncementId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId",
                table: "Likes",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Announcements_AnnouncementId1",
                table: "Likes",
                column: "AnnouncementId1",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
