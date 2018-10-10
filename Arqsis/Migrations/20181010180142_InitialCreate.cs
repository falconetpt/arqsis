using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arqsis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Finishes",
                columns: table => new
                {
                    FinishId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finishes", x => x.FinishId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FinishId = table.Column<Guid>(nullable: false),
                    MinHeightInMillimeters = table.Column<int>(nullable: false),
                    MinWeightInMillimeters = table.Column<int>(nullable: false),
                    MinDepthInMillimeters = table.Column<int>(nullable: false),
                    MaxHeightInMillimeters = table.Column<int>(nullable: false),
                    MaxWeightInMillimeters = table.Column<int>(nullable: false),
                    MaxDepthInMillimeters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Finishes_FinishId",
                        column: x => x.FinishId,
                        principalTable: "Finishes",
                        principalColumn: "FinishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restrictions",
                columns: table => new
                {
                    RestrictionId = table.Column<Guid>(nullable: false),
                    BaseProductId = table.Column<Guid>(nullable: false),
                    CompatibleProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.RestrictionId);
                    table.ForeignKey(
                        name: "FK_Restrictions_Products_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restrictions_Products_CompatibleProductId",
                        column: x => x.CompatibleProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FinishId",
                table: "Products",
                column: "FinishId");

            migrationBuilder.CreateIndex(
                name: "IX_Restrictions_BaseProductId",
                table: "Restrictions",
                column: "BaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Restrictions_CompatibleProductId",
                table: "Restrictions",
                column: "CompatibleProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Restrictions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Finishes");
        }
    }
}
