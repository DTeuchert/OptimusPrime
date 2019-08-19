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
                values: new object[] { 1, "Main" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Autobot Cars" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Mini-Bots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Dinobots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Aerialbots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Protectobots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Female Autobots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Technobots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Throttlebots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Targetmasters" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Headmasters" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Clonebots" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Junkions" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Others" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "bd0a9655-d11e-4537-a8c8-65faec607c24", "Autobot", 1, "Optimus Prime" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "2d78c5bd-0747-4c0e-9e4a-a7b4678facc9", "Autobot", 1, "Bumblebee" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "f261f281-db91-4be2-8acb-feb5c4f3413a", "Autobot", 1, "Cliffjumper" });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Alliance", "CategoryId", "Name" },
                values: new object[] { "d1abf070-a87f-4c0b-aa5f-f6a108e6ba87", "Decepticon", 1, "Megatron" });

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
