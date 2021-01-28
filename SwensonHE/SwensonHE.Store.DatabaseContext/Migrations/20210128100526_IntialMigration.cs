using Microsoft.EntityFrameworkCore.Migrations;

namespace SwensonHE.Store.Presistance.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flavor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemSize",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SizeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSize", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dozen = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSKU",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    HasWaterCompatibality = table.Column<bool>(nullable: false),
                    ProductID = table.Column<int>(nullable: true),
                    PackID = table.Column<int>(nullable: true),
                    FlavorID = table.Column<int>(nullable: true),
                    ModelTypeID = table.Column<int>(nullable: true),
                    ItemSizeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSKU", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemSKU_Flavor_FlavorID",
                        column: x => x.FlavorID,
                        principalTable: "Flavor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSKU_ItemSize_ItemSizeID",
                        column: x => x.ItemSizeID,
                        principalTable: "ItemSize",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSKU_ModelType_ModelTypeID",
                        column: x => x.ModelTypeID,
                        principalTable: "ModelType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSKU_Pack_PackID",
                        column: x => x.PackID,
                        principalTable: "Pack",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSKU_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSKU_Code",
                table: "ItemSKU",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSKU_FlavorID",
                table: "ItemSKU",
                column: "FlavorID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSKU_ItemSizeID",
                table: "ItemSKU",
                column: "ItemSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSKU_ModelTypeID",
                table: "ItemSKU",
                column: "ModelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSKU_PackID",
                table: "ItemSKU",
                column: "PackID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSKU_ProductID",
                table: "ItemSKU",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeID",
                table: "Product",
                column: "ProductTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemSKU");

            migrationBuilder.DropTable(
                name: "Flavor");

            migrationBuilder.DropTable(
                name: "ItemSize");

            migrationBuilder.DropTable(
                name: "ModelType");

            migrationBuilder.DropTable(
                name: "Pack");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
