using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddArticlesCommits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseCommitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublishedCommitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 15000, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commits_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commits_Commits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Commits",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 240, 5, 194, 217, 114, 177, 103, 115, 197, 255, 34, 245, 73, 130, 252, 227, 29, 20, 18, 248, 186, 163, 156, 123, 247, 131, 69, 234, 248, 176, 131, 254, 67, 225, 143, 66, 111, 189, 179, 110, 206, 50, 253, 224, 223, 64, 212, 165, 207, 223, 33, 96, 122, 156, 35, 222, 11, 211, 57, 210, 15, 247, 50, 215 }, new byte[] { 167, 168, 248, 83, 195, 40, 72, 212, 38, 24, 167, 183, 114, 82, 10, 21, 77, 242, 160, 115, 21, 23, 133, 141, 225, 218, 173, 12, 34, 187, 183, 157, 189, 182, 203, 67, 194, 52, 232, 115, 30, 22, 147, 222, 240, 181, 30, 113, 84, 201, 78, 58, 228, 59, 105, 145, 136, 181, 197, 122, 4, 177, 97, 200, 132, 66, 68, 98, 106, 179, 38, 41, 240, 141, 195, 172, 241, 240, 24, 106, 220, 181, 180, 224, 252, 68, 37, 26, 41, 170, 122, 233, 142, 235, 201, 116, 216, 38, 60, 35, 221, 138, 11, 138, 244, 24, 61, 203, 225, 199, 221, 239, 5, 171, 239, 78, 246, 218, 59, 225, 197, 37, 235, 220, 235, 178, 98, 105 } });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_BaseCommitId",
                table: "Articles",
                column: "BaseCommitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PublishedCommitId",
                table: "Articles",
                column: "PublishedCommitId",
                unique: true,
                filter: "[PublishedCommitId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_ArticleId",
                table: "Commits",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_ParentId",
                table: "Commits",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Commits_BaseCommitId",
                table: "Articles",
                column: "BaseCommitId",
                principalTable: "Commits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Commits_PublishedCommitId",
                table: "Articles",
                column: "PublishedCommitId",
                principalTable: "Commits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Commits_BaseCommitId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Commits_PublishedCommitId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Commits");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 4, 2, 872, DateTimeKind.Local).AddTicks(7604), new byte[] { 38, 193, 252, 145, 238, 40, 69, 186, 117, 153, 128, 19, 179, 253, 59, 90, 247, 64, 1, 213, 194, 147, 157, 24, 132, 105, 205, 97, 254, 255, 180, 20, 110, 4, 24, 191, 94, 104, 181, 16, 110, 29, 242, 193, 26, 143, 77, 114, 153, 65, 120, 205, 18, 204, 84, 11, 255, 54, 205, 254, 40, 43, 77, 236 }, new byte[] { 54, 42, 212, 167, 13, 67, 124, 231, 135, 199, 225, 163, 171, 25, 230, 168, 191, 160, 225, 185, 63, 231, 0, 171, 204, 138, 86, 94, 181, 164, 70, 43, 98, 234, 253, 94, 242, 144, 220, 41, 186, 80, 38, 91, 1, 215, 163, 166, 46, 123, 236, 13, 137, 173, 148, 127, 134, 134, 56, 214, 71, 141, 189, 170, 75, 201, 49, 211, 24, 188, 94, 212, 127, 120, 55, 81, 79, 24, 13, 125, 242, 154, 28, 36, 105, 11, 195, 204, 90, 129, 191, 201, 81, 170, 226, 36, 87, 9, 7, 160, 170, 133, 239, 171, 201, 2, 193, 131, 215, 244, 0, 25, 205, 238, 239, 112, 17, 204, 9, 181, 115, 54, 82, 65, 183, 193, 190, 123 } });
        }
    }
}
