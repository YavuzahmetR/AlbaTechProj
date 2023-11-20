using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Layer.Repositories.Migrations
{
    public partial class fixMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActionEndTime",
                table: "CampaignChannels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActionStartTime",
                table: "CampaignChannels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CampaignChannels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "CampaignChannels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5662));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5726));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5732));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 53, 12, 789, DateTimeKind.Local).AddTicks(5926));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionEndTime",
                table: "CampaignChannels");

            migrationBuilder.DropColumn(
                name: "ActionStartTime",
                table: "CampaignChannels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CampaignChannels");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "CampaignChannels");

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 659, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 660, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 660, DateTimeKind.Local).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 660, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 2, 19, 660, DateTimeKind.Local).AddTicks(126));
        }
    }
}
