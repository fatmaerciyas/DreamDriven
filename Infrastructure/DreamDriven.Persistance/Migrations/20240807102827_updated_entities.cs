using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DreamDriven.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updated_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CounterLogs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Counters");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "BackgroundImages",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "BackgroundImages",
                newName: "UploadedAt");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "UserUploads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserUploads",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Todos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notificatins",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_at",
                table: "Counters",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Counters",
                type: "interval",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Counters",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Counters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Counters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "BackgroundImages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "BackgroundImages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BackgroundImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BackgroundImages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "BackgroundImages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserUploads_CategoryId",
                table: "UserUploads",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundImages_UserId1",
                table: "BackgroundImages",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundImages_AspNetUsers_UserId1",
                table: "BackgroundImages",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUploads_Categories_CategoryId",
                table: "UserUploads",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundImages_AspNetUsers_UserId1",
                table: "BackgroundImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUploads_Categories_CategoryId",
                table: "UserUploads");

            migrationBuilder.DropIndex(
                name: "IX_UserUploads_CategoryId",
                table: "UserUploads");

            migrationBuilder.DropIndex(
                name: "IX_BackgroundImages_UserId1",
                table: "BackgroundImages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "UserUploads");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserUploads");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notificatins");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "BackgroundImages");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "BackgroundImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BackgroundImages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BackgroundImages");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BackgroundImages");

            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "BackgroundImages",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "BackgroundImages",
                newName: "Url");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_at",
                table: "Counters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Counters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CounterLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CounterId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounterLogs_Counters_CounterId",
                        column: x => x.CounterId,
                        principalTable: "Counters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CounterLogs_CounterId",
                table: "CounterLogs",
                column: "CounterId");
        }
    }
}
