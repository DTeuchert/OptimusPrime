using Microsoft.EntityFrameworkCore.Migrations;

namespace OptimusPrime.Server.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                        name: "FK_Transformers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Main" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Autobot Cars" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Mini-Bots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Dinobots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Aerialbots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Protectobots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Female Autobots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Technobots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Throttlebots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Targetmasters" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Headmasters" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Clonebots" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Junkions" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Others" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "35d663b8-e087-4e4e-8cae-fc31258f7c99", "Autobot", 1, "Optimus Prime" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "8a185940-0f60-46bd-97bd-9f122662fb85", "Autobot", 1, "Bumblebee" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "faaddd1b-92d7-47ac-b7d6-13be803ca63c", "Autobot", 1, "Cliffjumper" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "d5a1b9ce-3e63-4188-be5c-d3f640eded2e", "Decepticon", 1, "Megatron" });

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
                name: "Categories");
        }
    }
}
