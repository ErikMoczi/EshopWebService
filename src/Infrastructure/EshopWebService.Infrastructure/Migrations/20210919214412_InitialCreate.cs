using Microsoft.EntityFrameworkCore.Migrations;

namespace EshopWebService.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "HelloWorld-1", "/media/1/file1.png", "Product-1", 2.3m },
                    { 73, "HelloWorld-73", "/media/73/file73.png", "Product-73", 167.9m },
                    { 72, "HelloWorld-72", "/media/72/file72.png", "Product-72", 165.6m },
                    { 71, "HelloWorld-71", "/media/71/file71.png", "Product-71", 163.3m },
                    { 70, "HelloWorld-70", "/media/70/file70.png", "Product-70", 161.0m },
                    { 69, "HelloWorld-69", "/media/69/file69.png", "Product-69", 158.7m },
                    { 68, "HelloWorld-68", "/media/68/file68.png", "Product-68", 156.4m },
                    { 67, "HelloWorld-67", "/media/67/file67.png", "Product-67", 154.1m },
                    { 66, "HelloWorld-66", "/media/66/file66.png", "Product-66", 151.8m },
                    { 65, "HelloWorld-65", "/media/65/file65.png", "Product-65", 149.5m },
                    { 64, "HelloWorld-64", "/media/64/file64.png", "Product-64", 147.2m },
                    { 63, "HelloWorld-63", "/media/63/file63.png", "Product-63", 144.9m },
                    { 62, "HelloWorld-62", "/media/62/file62.png", "Product-62", 142.6m },
                    { 61, "HelloWorld-61", "/media/61/file61.png", "Product-61", 140.3m },
                    { 60, "HelloWorld-60", "/media/60/file60.png", "Product-60", 138.0m },
                    { 59, "HelloWorld-59", "/media/59/file59.png", "Product-59", 135.7m },
                    { 58, "HelloWorld-58", "/media/58/file58.png", "Product-58", 133.4m },
                    { 57, "HelloWorld-57", "/media/57/file57.png", "Product-57", 131.1m },
                    { 56, "HelloWorld-56", "/media/56/file56.png", "Product-56", 128.8m },
                    { 55, "HelloWorld-55", "/media/55/file55.png", "Product-55", 126.5m },
                    { 54, "HelloWorld-54", "/media/54/file54.png", "Product-54", 124.2m },
                    { 53, "HelloWorld-53", "/media/53/file53.png", "Product-53", 121.9m },
                    { 74, "HelloWorld-74", "/media/74/file74.png", "Product-74", 170.2m },
                    { 52, "HelloWorld-52", "/media/52/file52.png", "Product-52", 119.6m },
                    { 75, "HelloWorld-75", "/media/75/file75.png", "Product-75", 172.5m },
                    { 77, "HelloWorld-77", "/media/77/file77.png", "Product-77", 177.1m },
                    { 98, "HelloWorld-98", "/media/98/file98.png", "Product-98", 225.4m },
                    { 97, "HelloWorld-97", "/media/97/file97.png", "Product-97", 223.1m },
                    { 96, "HelloWorld-96", "/media/96/file96.png", "Product-96", 220.8m },
                    { 95, "HelloWorld-95", "/media/95/file95.png", "Product-95", 218.5m },
                    { 94, "HelloWorld-94", "/media/94/file94.png", "Product-94", 216.2m },
                    { 93, "HelloWorld-93", "/media/93/file93.png", "Product-93", 213.9m },
                    { 92, "HelloWorld-92", "/media/92/file92.png", "Product-92", 211.6m },
                    { 91, "HelloWorld-91", "/media/91/file91.png", "Product-91", 209.3m },
                    { 90, "HelloWorld-90", "/media/90/file90.png", "Product-90", 207.0m },
                    { 89, "HelloWorld-89", "/media/89/file89.png", "Product-89", 204.7m },
                    { 88, "HelloWorld-88", "/media/88/file88.png", "Product-88", 202.4m },
                    { 87, "HelloWorld-87", "/media/87/file87.png", "Product-87", 200.1m },
                    { 86, "HelloWorld-86", "/media/86/file86.png", "Product-86", 197.8m },
                    { 85, "HelloWorld-85", "/media/85/file85.png", "Product-85", 195.5m },
                    { 84, "HelloWorld-84", "/media/84/file84.png", "Product-84", 193.2m },
                    { 83, "HelloWorld-83", "/media/83/file83.png", "Product-83", 190.9m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "HelloWorld-82", "/media/82/file82.png", "Product-82", 188.6m },
                    { 81, "HelloWorld-81", "/media/81/file81.png", "Product-81", 186.3m },
                    { 80, "HelloWorld-80", "/media/80/file80.png", "Product-80", 184.0m },
                    { 79, "HelloWorld-79", "/media/79/file79.png", "Product-79", 181.7m },
                    { 78, "HelloWorld-78", "/media/78/file78.png", "Product-78", 179.4m },
                    { 76, "HelloWorld-76", "/media/76/file76.png", "Product-76", 174.8m },
                    { 51, "HelloWorld-51", "/media/51/file51.png", "Product-51", 117.3m },
                    { 50, "HelloWorld-50", "/media/50/file50.png", "Product-50", 115.0m },
                    { 49, "HelloWorld-49", "/media/49/file49.png", "Product-49", 112.7m },
                    { 22, "HelloWorld-22", "/media/22/file22.png", "Product-22", 50.6m },
                    { 21, "HelloWorld-21", "/media/21/file21.png", "Product-21", 48.3m },
                    { 20, "HelloWorld-20", "/media/20/file20.png", "Product-20", 46.0m },
                    { 19, "HelloWorld-19", "/media/19/file19.png", "Product-19", 43.7m },
                    { 18, "HelloWorld-18", "/media/18/file18.png", "Product-18", 41.4m },
                    { 17, "HelloWorld-17", "/media/17/file17.png", "Product-17", 39.1m },
                    { 16, "HelloWorld-16", "/media/16/file16.png", "Product-16", 36.8m },
                    { 15, "HelloWorld-15", "/media/15/file15.png", "Product-15", 34.5m },
                    { 14, "HelloWorld-14", "/media/14/file14.png", "Product-14", 32.2m },
                    { 13, "HelloWorld-13", "/media/13/file13.png", "Product-13", 29.9m },
                    { 12, "HelloWorld-12", "/media/12/file12.png", "Product-12", 27.6m },
                    { 11, "HelloWorld-11", "/media/11/file11.png", "Product-11", 25.3m },
                    { 10, "HelloWorld-10", "/media/10/file10.png", "Product-10", 23.0m },
                    { 9, "HelloWorld-9", "/media/9/file9.png", "Product-9", 20.7m },
                    { 8, "HelloWorld-8", "/media/8/file8.png", "Product-8", 18.4m },
                    { 7, "HelloWorld-7", "/media/7/file7.png", "Product-7", 16.1m },
                    { 6, "HelloWorld-6", "/media/6/file6.png", "Product-6", 13.8m },
                    { 5, "HelloWorld-5", "/media/5/file5.png", "Product-5", 11.5m },
                    { 4, "HelloWorld-4", "/media/4/file4.png", "Product-4", 9.2m },
                    { 3, "HelloWorld-3", "/media/3/file3.png", "Product-3", 6.9m },
                    { 2, "HelloWorld-2", "/media/2/file2.png", "Product-2", 4.6m },
                    { 23, "HelloWorld-23", "/media/23/file23.png", "Product-23", 52.9m },
                    { 24, "HelloWorld-24", "/media/24/file24.png", "Product-24", 55.2m },
                    { 25, "HelloWorld-25", "/media/25/file25.png", "Product-25", 57.5m },
                    { 26, "HelloWorld-26", "/media/26/file26.png", "Product-26", 59.8m },
                    { 48, "HelloWorld-48", "/media/48/file48.png", "Product-48", 110.4m },
                    { 47, "HelloWorld-47", "/media/47/file47.png", "Product-47", 108.1m },
                    { 46, "HelloWorld-46", "/media/46/file46.png", "Product-46", 105.8m },
                    { 45, "HelloWorld-45", "/media/45/file45.png", "Product-45", 103.5m },
                    { 44, "HelloWorld-44", "/media/44/file44.png", "Product-44", 101.2m },
                    { 43, "HelloWorld-43", "/media/43/file43.png", "Product-43", 98.9m },
                    { 42, "HelloWorld-42", "/media/42/file42.png", "Product-42", 96.6m },
                    { 41, "HelloWorld-41", "/media/41/file41.png", "Product-41", 94.3m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "HelloWorld-40", "/media/40/file40.png", "Product-40", 92.0m },
                    { 39, "HelloWorld-39", "/media/39/file39.png", "Product-39", 89.7m },
                    { 99, "HelloWorld-99", "/media/99/file99.png", "Product-99", 227.7m },
                    { 38, "HelloWorld-38", "/media/38/file38.png", "Product-38", 87.4m },
                    { 36, "HelloWorld-36", "/media/36/file36.png", "Product-36", 82.8m },
                    { 35, "HelloWorld-35", "/media/35/file35.png", "Product-35", 80.5m },
                    { 34, "HelloWorld-34", "/media/34/file34.png", "Product-34", 78.2m },
                    { 33, "HelloWorld-33", "/media/33/file33.png", "Product-33", 75.9m },
                    { 32, "HelloWorld-32", "/media/32/file32.png", "Product-32", 73.6m },
                    { 31, "HelloWorld-31", "/media/31/file31.png", "Product-31", 71.3m },
                    { 30, "HelloWorld-30", "/media/30/file30.png", "Product-30", 69.0m },
                    { 29, "HelloWorld-29", "/media/29/file29.png", "Product-29", 66.7m },
                    { 28, "HelloWorld-28", "/media/28/file28.png", "Product-28", 64.4m },
                    { 27, "HelloWorld-27", "/media/27/file27.png", "Product-27", 62.1m },
                    { 37, "HelloWorld-37", "/media/37/file37.png", "Product-37", 85.1m },
                    { 100, "HelloWorld-100", "/media/100/file100.png", "Product-100", 230.0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
