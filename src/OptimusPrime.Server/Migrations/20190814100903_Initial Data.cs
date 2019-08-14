using Microsoft.EntityFrameworkCore.Migrations;

namespace OptimusPrime.Server.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transformers",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformers", x => x.Guid);
                });

            migrationBuilder.InsertData(
                table: "Transformers",
                columns: new[] { "Guid", "Name" },
                values: new object[] { "96543483-7f27-445f-a30b-08b11248afe9", "Bumblebee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transformers");
        }
    }
}
