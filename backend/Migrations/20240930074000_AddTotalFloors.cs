using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalFloors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_userId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_userId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TotalFoolrs",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Properties",
                newName: "TotalFloors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstPossessionOn",
                table: "Properties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PostedBy",
                table: "Properties",
                column: "PostedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_PostedBy",
                table: "Properties",
                column: "PostedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_PostedBy",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PostedBy",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "TotalFloors",
                table: "Properties",
                newName: "userId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstPossessionOn",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalFoolrs",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_userId",
                table: "Properties",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_userId",
                table: "Properties",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
