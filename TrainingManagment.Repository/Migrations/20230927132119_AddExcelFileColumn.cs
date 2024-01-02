using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingManagment.Repository.Migrations
{
    public partial class AddExcelFileColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "EvaluationFile",
                table: "Session",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 900, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 901, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 898, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 898, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 898, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 898, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 898, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 600,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 27, 16, 21, 18, 898, DateTimeKind.Local).AddTicks(3028));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluationFile",
                table: "Session");

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "Lookup",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(6942));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "LookupCategory",
                keyColumn: "CategoryId",
                keyValue: 600,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8607));
        }
    }
}
