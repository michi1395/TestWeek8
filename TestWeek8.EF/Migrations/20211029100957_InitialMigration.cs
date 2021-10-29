using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWeek8.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    PlateType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plates_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cenone di Capodanno" },
                    { 2, "Pranzo di Natale" },
                    { 3, "Pranzo domenicale" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "mrossi@abc.it", "1234", 0 },
                    { 2, "michi13@abc.it", "5678", 1 }
                });

            migrationBuilder.InsertData(
                table: "Plates",
                columns: new[] { "Id", "Description", "MenuId", "Name", "PlateType", "Price" },
                values: new object[] { 1, "Sugo, macinato, cipolla, parmigiano, orecchiette fresche", 1, "Orecchiette con polpette", 0, 10.50m });

            migrationBuilder.InsertData(
                table: "Plates",
                columns: new[] { "Id", "Description", "MenuId", "Name", "PlateType", "Price" },
                values: new object[] { 2, "Polpettone, brodo e carote", 1, "Polpettone con carote", 1, 12.50m });

            migrationBuilder.InsertData(
                table: "Plates",
                columns: new[] { "Id", "Description", "MenuId", "Name", "PlateType", "Price" },
                values: new object[] { 3, "Biscotti, panna, ricotta, nutella", 1, "Cheesecake alla nutella", 3, 5.50m });

            migrationBuilder.CreateIndex(
                name: "IX_Plates_MenuId",
                table: "Plates",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
