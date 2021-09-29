using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopAPI.Migrations
{
    public partial class AlexSucks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SubId);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    ItemPrice = table.Column<int>(type: "int", nullable: false),
                    ItemDiscount = table.Column<int>(type: "int", nullable: false),
                    ItemAmount = table.Column<int>(type: "int", nullable: false),
                    ItemStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CurrentPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Hardware" },
                    { 2, "Gaming" },
                    { 3, "PC & Tablets" },
                    { 4, "TV & HIFI" },
                    { 5, "Mobile" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "FirstName", "LastName", "MiddleName", "Password", "Phone", "PostalCode", "Role" },
                values: new object[,]
                {
                    { 1, "Noobstreet", "Test@gmail.com", "Anders", "Noob", "Er", "TestTest", "20202020", "1337", 1 },
                    { 2, "NewWorldChamp 1337", "Alex@gmail.com", "Alex", "Gud", "Er", "Test1234", "10101010", "7331", 2 },
                    { 3, "Noobstreet 7331", "Mathias@gmail.com", "Mathias", "Noob", "Er", "Test4321", "80088008", "1337", 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderStatus", "UserId" },
                values: new object[,]
                {
                    { 1, "In Shipping", 1 },
                    { 2, "In Cart", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "SubId", "CategoryId", "SubName" },
                values: new object[,]
                {
                    { 1, 1, "Laptop" },
                    { 2, 1, "PC Audio" },
                    { 3, 1, "Monitors" },
                    { 6, 5, "Shitty office equipment" },
                    { 4, 5, "MobilTelefoner" },
                    { 5, 5, "SmartWatches" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemId", "ItemAmount", "ItemDescription", "ItemDiscount", "ItemName", "ItemPrice", "ItemStatus", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, 10, "Shitty bÃ¦rbar, minimal teamkilling ability with this one.", 5, "Acer 15.6 tommer laptop", 4999, "In Stock", 1 },
                    { 6, 15, "Some good shit if i may say so myself.", 20, "Acer Extensa 15 EX215-54 15,5 FHD", 5999, "In Stock", 1 },
                    { 2, 2, "Top teir audio to own your teammates", 0, "SteelSeries Arctic 7 Wireless", 999, "In Stock", 2 },
                    { 3, 10, "Top tier MMO mouse, and bottom tier for friendly fire", 10, "Razor Naga Trinity mouse with detachables sides", 699, "In Stock", 2 },
                    { 5, 15, "Top tier mouse in every aspect", 15, "Logitech G Pro Wireless", 899, "In Stock", 2 },
                    { 4, 250, "Great for your wrist, and for your teammates survivabillity ", 0, "Logitech Office Mouse", 150, "In Stock", 6 },
                    { 7, 40, "Bling bling for your run", 0, "Garmin Vivoactive 4s GPS smartur, hvid-rose guld", 1799, "In Stock", 5 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "Amount", "CurrentPrice", "ItemId", "OrderId" },
                values: new object[] { 1, 5, 500, 1, 1 });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "Amount", "CurrentPrice", "ItemId", "OrderId" },
                values: new object[] { 2, 2, 1000, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Item_SubCategoryId",
                table: "Item",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
