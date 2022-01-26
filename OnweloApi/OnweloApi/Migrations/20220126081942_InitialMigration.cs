using Microsoft.EntityFrameworkCore.Migrations;

namespace OnweloApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voters_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Candidate 1" },
                    { 2, "Candidate 2" },
                    { 3, "Candidate 3" }
                });

            migrationBuilder.InsertData(
                table: "Voters",
                columns: new[] { "Id", "CandidateId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Voter 1" },
                    { 2, null, "Voter 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voters_CandidateId",
                table: "Voters",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
