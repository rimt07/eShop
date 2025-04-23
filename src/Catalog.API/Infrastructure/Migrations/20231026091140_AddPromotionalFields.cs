using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Catalog.API.Infrastructure.Migrations
{
    public partial class AddPromotionalFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromotionalDiscountPercentage",
                table: "CatalogItems",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "PromotionalDiscountDescription",
                table: "CatalogItems",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "PromotionStartDate",
                table: "CatalogItems",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "PromotionEndDate",
                table: "CatalogItems",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "BadgeDesign",
                table: "CatalogItems",
                nullable: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "PromotionalDiscountPercentage", table: "CatalogItems");
            migrationBuilder.DropColumn(name: "PromotionalDiscountDescription", table: "CatalogItems");
            migrationBuilder.DropColumn(name: "PromotionStartDate", table: "CatalogItems");
            migrationBuilder.DropColumn(name: "PromotionEndDate", table: "CatalogItems");
            migrationBuilder.DropColumn(name: "BadgeDesign", table: "CatalogItems");
        }
    }
}