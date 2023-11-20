using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Layer.Repositories.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CampaignType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignsId = table.Column<int>(type: "int", nullable: false),
                    ChannelsId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignChannels_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignChannels_Channels_ChannelsId",
                        column: x => x.ChannelsId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCampaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignsId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCampaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCampaigns_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCampaigns_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "About", "CampaignType", "CreatedDate", "Description", "EndDate", "Name", "Priority", "StartDate", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "General", new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8623), null, new DateTime(23, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Kampanya 1", 10, new DateTime(23, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null },
                    { 2, null, "CustomerSpecial", new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8629), null, new DateTime(23, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Kampanya 2", 20, new DateTime(23, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { 3, null, "General", new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8632), null, new DateTime(23, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Kampanya 3", 30, new DateTime(22, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null },
                    { 4, null, "CustomerSpecial", new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8634), null, new DateTime(23, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Kampanya 4", 40, new DateTime(23, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "MOBIL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, "WEB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3, "EMAIL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 4, "SMS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "CustomerName", "CustomerNo", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer1", 1000, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer2", 1001, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer3", 1002, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer4", 1003, null, null }
                });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "CreatedDate", "Description", "GroupCode", "ParameterCode", "ParameterValue", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description1", "GeneralCampaigns", "Public", "Genel Kampanya", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description2", "CustomerCampaigns", "Private", "Müşteri Bazlı Kampanya", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Yavuz" });

            migrationBuilder.InsertData(
                table: "CampaignChannels",
                columns: new[] { "Id", "CampaignsId", "ChannelsId", "CreatedDate", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8508), true, null, null },
                    { 2, 1, 2, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8544), false, null, null },
                    { 3, 2, 1, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8548), true, null, null },
                    { 4, 4, 3, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8550), false, null, null }
                });

            migrationBuilder.InsertData(
                table: "CustomerCampaigns",
                columns: new[] { "Id", "CampaignsId", "CreatedDate", "CustomersId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8764), 1, null, null },
                    { 2, 3, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8768), 2, null, null },
                    { 3, 3, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8770), 3, null, null },
                    { 4, 2, new DateTime(2023, 8, 13, 14, 3, 33, 837, DateTimeKind.Local).AddTicks(8772), 4, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignChannels_CampaignsId",
                table: "CampaignChannels",
                column: "CampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignChannels_ChannelsId",
                table: "CampaignChannels",
                column: "ChannelsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCampaigns_CampaignsId",
                table: "CustomerCampaigns",
                column: "CampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCampaigns_CustomersId",
                table: "CustomerCampaigns",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignChannels");

            migrationBuilder.DropTable(
                name: "CustomerCampaigns");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
