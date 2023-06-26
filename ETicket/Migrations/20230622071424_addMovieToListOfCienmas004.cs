using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicket.Migrations
{
    /// <inheritdoc />
    public partial class addMovieToListOfCienmas004 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CinemaId",
                table: "Orders",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PartyId",
                table: "Orders",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cinemas_CinemaId",
                table: "Orders",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Parties_PartyId",
                table: "Orders",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cinemas_CinemaId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Parties_PartyId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CinemaId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PartyId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Orders");

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
