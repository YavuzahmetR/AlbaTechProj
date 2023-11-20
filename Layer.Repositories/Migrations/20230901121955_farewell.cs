using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Layer.Repositories.Migrations
{
    public partial class farewell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Membership",
                table: "Customers",
                newName: "Segment");

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "CustomerCampaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 19, 55, 437, DateTimeKind.Local).AddTicks(9041));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Segment",
                table: "Customers",
                newName: "Membership");

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
    }
}
