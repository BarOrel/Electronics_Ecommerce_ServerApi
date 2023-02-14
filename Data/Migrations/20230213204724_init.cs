﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    Year_ExpirationDate = table.Column<int>(type: "int", nullable: false),
                    Month_ExpirationDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MilliampHours = table.Column<int>(type: "int", nullable: false),
                    Resolution = table.Column<int>(type: "int", nullable: false),
                    Panel = table.Column<int>(type: "int", nullable: false),
                    Inch = table.Column<double>(type: "float", nullable: false),
                    OperationSystem = table.Column<int>(type: "int", nullable: false),
                    SizeMM = table.Column<int>(type: "int", nullable: false),
                    CpuType = table.Column<int>(type: "int", nullable: false),
                    CpuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpuType = table.Column<int>(type: "int", nullable: false),
                    GpuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Threads = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    CreditCardId = table.Column<int>(type: "int", nullable: true),
                    IsShipped = table.Column<bool>(type: "bit", nullable: false),
                    Open = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MilliampHours = table.Column<int>(type: "int", nullable: false),
                    Resolution = table.Column<int>(type: "int", nullable: false),
                    Panel = table.Column<int>(type: "int", nullable: false),
                    Inch = table.Column<double>(type: "float", nullable: false),
                    OperationSystem = table.Column<int>(type: "int", nullable: false),
                    SizeMM = table.Column<int>(type: "int", nullable: false),
                    CpuType = table.Column<int>(type: "int", nullable: false),
                    CpuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpuType = table.Column<int>(type: "int", nullable: false),
                    GpuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Threads = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    IsOrderd = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Color", "Cores", "CpuName", "CpuType", "Description", "Discount", "GpuName", "GpuType", "ImgUrl", "Inch", "Manufacturer", "MilliampHours", "Name", "OperationSystem", "Panel", "Price", "ReleaseDate", "Resolution", "SizeMM", "Storage", "Threads", "Type" },
                values: new object[,]
                {
                    { 1, 9, 0, 0, null, 0, "The PlayStation 5 (PS5) is a home video game console developed by Sony Interactive Entertainment. It was announced as successor to the PlayStation 4 in April 2019, was launched on November 12, 2020", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11591925787cggjhepdvq.png", 0.0, 5, 0, "PlayStation 5", 0, 0, 499, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5861), 0, 0, 0, 0, 0 },
                    { 2, 9, 0, 0, null, 0, "The PlayStation 4 (PS4) is a home video game console developed by Sony Interactive Entertainment.\r\n", 0, null, 0, "data:image/jpeg;base64,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", 0.0, 5, 0, "PlayStation 4", 0, 0, 299, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5886), 0, 0, 0, 0, 0 },
                    { 3, 9, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 6, 0, "Xbox Series X", 0, 0, 329, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5888), 0, 0, 0, 0, 0 },
                    { 4, 9, 0, 0, null, 0, "The Xbox One is a home video game console developed by Microsoft. Announced in May 2013, it is the successor to Xbox 360 and the third base console in the Xbox series of video game consoles. It was first released in North America, parts of Europe, Australia, and South America in November 2013 and in Japan, China, and other European countries in September 2014", 0, null, 0, "data:image/jpeg;base64,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", 0.0, 6, 0, "Xbox One S", 0, 0, 299, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5889), 0, 0, 0, 0, 0 },
                    { 5, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYbxQSflwh1hUVEgUhRjQW1iYJOTdoNJQ6N_27Q07a3g40ozDRPCOwaNXilNQ0N-e7-gE&usqp=CAU", 0.0, 1, 0, "Iphone 12", 0, 0, 699, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5891), 0, 0, 0, 0, 0 },
                    { 6, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "data:image/jpeg;base64,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", 0.0, 1, 0, "Iphone 12 Pro", 0, 0, 799, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5892), 0, 0, 0, 0, 0 },
                    { 7, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 12 Max", 0, 0, 899, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5893), 0, 0, 0, 0, 0 },
                    { 8, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 13", 0, 0, 799, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5894), 0, 0, 0, 0, 0 },
                    { 9, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 13 Pro", 0, 0, 799, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5895), 0, 0, 0, 0, 0 },
                    { 10, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 13 Max", 0, 0, 899, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5897), 0, 0, 0, 0, 0 },
                    { 11, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 14 ", 0, 0, 799, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5898), 0, 0, 0, 0, 0 },
                    { 12, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 14 Pro", 0, 0, 899, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5899), 0, 0, 0, 0, 0 },
                    { 13, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 14 Max", 0, 0, 950, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5900), 0, 0, 0, 0, 0 },
                    { 14, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 14 ", 0, 0, 799, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5901), 0, 0, 0, 0, 0 },
                    { 15, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 14 Pro", 0, 0, 899, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5903), 0, 0, 0, 0, 0 },
                    { 16, 1, 0, 0, null, 0, "Xbox Series X is launching at participating retailers worldwide on 10 November 2020.", 0, null, 0, "https://www.citypng.com/public/uploads/preview/-11589218258unxbb3hzak.png", 0.0, 1, 0, "Iphone 14 Max", 0, 0, 950, new DateTime(2023, 2, 13, 22, 47, 24, 725, DateTimeKind.Local).AddTicks(5905), 0, 0, 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreditCardId", "Email", "FullName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "b2588efe-8b06-4163-94c7-8fa43a2b54f9", 1, 0, "bari0777@walla.com", "Bar Orel", null, null, "bar554401", null, "5f5e308a-2585-480d-895d-faaf8e7e594c", "bar1236" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartId",
                table: "CartProducts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_OrderId",
                table: "CartProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreditCardId",
                table: "Orders",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CreditCards");
        }
    }
}