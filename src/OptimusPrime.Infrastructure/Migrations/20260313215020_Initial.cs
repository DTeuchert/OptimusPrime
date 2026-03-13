using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OptimusPrime.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transformers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    AllianceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformers", x => x.Id);
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
                values: new object[,]
                {
                    { new Guid("24a1832f-cb0c-4770-a559-d4d9fc146c77"), "Aerialbots" },
                    { new Guid("288870ca-239b-4612-ba27-a9ac1a908c0a"), "Targetmasters" },
                    { new Guid("2fc83505-6cc8-4d5e-930c-5a96fa15f458"), "Throttlebots" },
                    { new Guid("3e05f3c6-0e6b-4ac0-8a24-5d5edc818aa6"), "Technobots" },
                    { new Guid("72e18b93-6926-4798-9976-2857d93296fc"), "Junkions" },
                    { new Guid("76552f0c-9505-4c3d-a2f0-098fc8493a4c"), "Headmasters" },
                    { new Guid("78bd17e8-7cd5-4161-9397-2830ef279a74"), "Others" },
                    { new Guid("83d2f378-26f9-4b83-a562-88ac627a3477"), "Female Autobots" },
                    { new Guid("9fd942c2-9660-4bcb-a70d-74382215c329"), "Clonebots" },
                    { new Guid("b72793c4-a462-4268-88d8-f080e0eefa42"), "Main" },
                    { new Guid("be1c56c4-6947-4466-8e07-86542556e576"), "Dinobots" },
                    { new Guid("d51cc438-6117-4cb2-8d2f-5f33e14d04fc"), "Autobot Cars" },
                    { new Guid("d74d16ae-2f91-49ce-a741-a00d8ae684ac"), "Mini-Bots" },
                    { new Guid("d9a95247-30f7-4033-83c2-81e45c996619"), "Protectobots" }
                });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Id", "AllianceId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("178fb622-a034-4378-a19c-554ee9330512"), 0, new Guid("b72793c4-a462-4268-88d8-f080e0eefa42"), "Cliffjumper" },
                    { new Guid("33a6a0a1-c13a-4c97-a0a7-c567255299e0"), 0, new Guid("b72793c4-a462-4268-88d8-f080e0eefa42"), "Bumblebee" },
                    { new Guid("8a78dc38-93c4-413b-8369-7784d8296a00"), 0, new Guid("b72793c4-a462-4268-88d8-f080e0eefa42"), "Optimus Prime" },
                    { new Guid("ad07477c-e728-42bf-bb0d-54db2688da1c"), 1, new Guid("b72793c4-a462-4268-88d8-f080e0eefa42"), "Megatron" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transformers_CategoryId",
                table: "Transformers",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transformers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
