using Microsoft.EntityFrameworkCore.Migrations;

namespace OptimusPrime.Server.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transformers",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Alliance = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformers", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Transformers_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Main Autobots" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "d91e068b-6708-41d5-8fb7-da03f7bdf1db", "Autobot", 1, "Bumblebee" });

            migrationBuilder.CreateIndex(
                name: "IX_Transformers_CategoryId",
                table: "Transformers",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transformers");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
