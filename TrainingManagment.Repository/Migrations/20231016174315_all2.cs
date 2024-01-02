using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingManagment.Repository.Migrations
{
    public partial class all2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Lookup_LookupYearId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_LookupYearId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "LookupYearId",
                table: "Session");

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "LookupCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 708, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(636));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 709, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 706, DateTimeKind.Local).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 706, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 706, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 706, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 706, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 600,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 20, 43, 14, 706, DateTimeKind.Local).AddTicks(6674));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LookupYearId",
                table: "Session",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "LookupCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 992, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 990, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 990, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 990, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 990, DateTimeKind.Local).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 990, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 600,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 16, 14, 1, 20, 990, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.CreateIndex(
                name: "IX_Session_LookupYearId",
                table: "Session",
                column: "LookupYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Lookup_LookupYearId",
                table: "Session",
                column: "LookupYearId",
                principalTable: "Lookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
