using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Practice.Migrations
{
    /// <inheritdoc />
    public partial class EmpManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manager",
                columns: table => new
                {
                    mid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manager", x => x.mid);
                });

            migrationBuilder.CreateTable(
                name: "emps",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    esalary = table.Column<double>(type: "float", nullable: false),
                    mid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emps", x => x.eid);
                    table.ForeignKey(
                        name: "FK_emps_manager_mid",
                        column: x => x.mid,
                        principalTable: "manager",
                        principalColumn: "mid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emps_mid",
                table: "emps",
                column: "mid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emps");

            migrationBuilder.DropTable(
                name: "manager");
        }
    }
}
