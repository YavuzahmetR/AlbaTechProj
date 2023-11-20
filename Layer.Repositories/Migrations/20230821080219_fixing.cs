using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Layer.Repositories.Migrations
{
    public partial class fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Campaigns");

            migrationBuilder.AddColumn<string>(
                name: "CampaignName",
                table: "CampaignChannels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChannelType",
                table: "CampaignChannels",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignName",
                table: "CampaignChannels");

            migrationBuilder.DropColumn(
                name: "ChannelType",
                table: "CampaignChannels");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8772));
        }
    }
}
