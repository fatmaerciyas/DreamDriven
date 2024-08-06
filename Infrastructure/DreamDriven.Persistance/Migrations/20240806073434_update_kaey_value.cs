using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DreamDriven.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class update_kaey_value : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUploads_AspNetUsers_UserId",
                table: "UserUploads");

            migrationBuilder.DropTable(
                name: "BackgroundImages");

            migrationBuilder.DropTable(
                name: "CounterLogs");

            migrationBuilder.DropTable(
                name: "Notificatins");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUploads",
                table: "UserUploads");

            migrationBuilder.RenameTable(
                name: "UserUploads",
                newName: "EntityBase");

            migrationBuilder.RenameIndex(
                name: "IX_UserUploads_UserId",
                table: "EntityBase",
                newName: "IX_EntityBase_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "EntityBase",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "FileUrl",
                table: "EntityBase",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "EntityBase",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CounterId",
                table: "EntityBase",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Counter_Name",
                table: "EntityBase",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Counter_Updated_at",
                table: "EntityBase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EntityBase",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EntityBase",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "EntityBase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "EntityBase",
                type: "interval",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "EntityBase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "EntityBase",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EntityBase",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Read",
                table: "EntityBase",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "EntityBase",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageDetail",
                table: "EntityBase",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EntityBase",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Notificatin_UserId",
                table: "EntityBase",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "EntityBase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "EntityBase",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Todo_UserId",
                table: "EntityBase",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EntityBase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "EntityBase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "EntityBase",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "EntityBase",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserUpload_UserId",
                table: "EntityBase",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityBase",
                table: "EntityBase",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntityBase_CategoryId",
                table: "EntityBase",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityBase_CounterId",
                table: "EntityBase",
                column: "CounterId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityBase_Notificatin_UserId",
                table: "EntityBase",
                column: "Notificatin_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityBase_Todo_UserId",
                table: "EntityBase",
                column: "Todo_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityBase_UserUpload_UserId",
                table: "EntityBase",
                column: "UserUpload_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_AspNetUsers_Notificatin_UserId",
                table: "EntityBase",
                column: "Notificatin_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_AspNetUsers_Todo_UserId",
                table: "EntityBase",
                column: "Todo_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_AspNetUsers_UserId",
                table: "EntityBase",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_AspNetUsers_UserUpload_UserId",
                table: "EntityBase",
                column: "UserUpload_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_EntityBase_CategoryId",
                table: "EntityBase",
                column: "CategoryId",
                principalTable: "EntityBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_EntityBase_CounterId",
                table: "EntityBase",
                column: "CounterId",
                principalTable: "EntityBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_AspNetUsers_Notificatin_UserId",
                table: "EntityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_AspNetUsers_Todo_UserId",
                table: "EntityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_AspNetUsers_UserId",
                table: "EntityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_AspNetUsers_UserUpload_UserId",
                table: "EntityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_EntityBase_CategoryId",
                table: "EntityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_EntityBase_CounterId",
                table: "EntityBase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityBase",
                table: "EntityBase");

            migrationBuilder.DropIndex(
                name: "IX_EntityBase_CategoryId",
                table: "EntityBase");

            migrationBuilder.DropIndex(
                name: "IX_EntityBase_CounterId",
                table: "EntityBase");

            migrationBuilder.DropIndex(
                name: "IX_EntityBase_Notificatin_UserId",
                table: "EntityBase");

            migrationBuilder.DropIndex(
                name: "IX_EntityBase_Todo_UserId",
                table: "EntityBase");

            migrationBuilder.DropIndex(
                name: "IX_EntityBase_UserUpload_UserId",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "CounterId",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Counter_Name",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Counter_Updated_at",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Is_Read",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "MessageDetail",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Notificatin_UserId",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Todo_UserId",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "UserUpload_UserId",
                table: "EntityBase");

            migrationBuilder.RenameTable(
                name: "EntityBase",
                newName: "UserUploads");

            migrationBuilder.RenameIndex(
                name: "IX_EntityBase_UserId",
                table: "UserUploads",
                newName: "IX_UserUploads_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserUploads",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileUrl",
                table: "UserUploads",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUploads",
                table: "UserUploads",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificatins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Is_Read = table.Column<bool>(type: "boolean", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    MessageDetail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificatins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificatins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackgroundImages_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_BackgroundImages_CategoryId",
                table: "BackgroundImages",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterLogs_CounterId",
                table: "CounterLogs",
                column: "CounterId");

            migrationBuilder.CreateIndex(
                name: "IX_Counters_UserId",
                table: "Counters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificatins_UserId",
                table: "Notificatins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserId",
                table: "Todos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUploads_AspNetUsers_UserId",
                table: "UserUploads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
