using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Layer.Repositories.Migrations
{
    public partial class mig_scenario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CardStatus",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Membership",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampaignParameter",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 15, 57, 36, 762, DateTimeKind.Local).AddTicks(9518));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CardStatus",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Membership",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CampaignParameter",
                table: "Campaigns");

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
    }
}
