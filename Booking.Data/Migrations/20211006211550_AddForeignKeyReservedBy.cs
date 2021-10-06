using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Data.Migrations
{
    public partial class AddForeignKeyReservedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25619052-7900-4ee6-8f2f-5396c1805aaa", "AQAAAAEAACcQAAAAECps+yY1vLONWUfvwTi9gXYyiOmYpk7D8MZVzIj6ZgDeRWL/lrUp9mxGJ9O8M4Jigg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b74ddd14-6340-4840-95c2-db12554843e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d70b39ca-d633-45d7-ae9d-42866cb7ee9a", "AQAAAAEAACcQAAAAEFsageQulffwyNp534JcHGYscgREbIkCHTl94AqgdzXEU5OUv9twoSOip8yAfRigDg==" });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 10, 6, 23, 15, 49, 499, DateTimeKind.Local).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 10, 6, 23, 15, 49, 499, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 10, 6, 23, 15, 49, 499, DateTimeKind.Local).AddTicks(5142));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedBy",
                table: "Reservations",
                column: "ReservedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservedBy",
                table: "Reservations",
                column: "ReservedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ReservedBy",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedBy",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8a51a97-59d8-455a-b17d-bf2030781372", "AQAAAAEAACcQAAAAEDtTnvvwYwpZzXvtjpBJyz1jZLoz6K6on8b3MylKoeVmCrDroJcDBryQ0B6fy72qsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b74ddd14-6340-4840-95c2-db12554843e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "077067c8-606c-4d22-b79a-0d8372ae484b", "AQAAAAEAACcQAAAAEF9eAZHJwKZaQmCgpCXIfEa1zpLZU4ItVUZ/4rMnZeoJNi+1bI0dv7aH25F914s5Zg==" });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 10, 6, 21, 44, 53, 47, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 10, 6, 21, 44, 53, 48, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 10, 6, 21, 44, 53, 48, DateTimeKind.Local).AddTicks(2499));
        }
    }
}
