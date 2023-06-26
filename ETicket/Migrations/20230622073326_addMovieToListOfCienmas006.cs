using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicket.Migrations
{
    /// <inheritdoc />
    public partial class addMovieToListOfCienmas006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Cinemas_CinemaId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Parties_PartyId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CinemaId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_PartyId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "OrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CinemaId",
                table: "OrderItems",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PartyId",
                table: "OrderItems",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Cinemas_CinemaId",
                table: "OrderItems",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Parties_PartyId",
                table: "OrderItems",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
