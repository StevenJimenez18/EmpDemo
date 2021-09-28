using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDemo.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    departmentDepartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Eid);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_departmentDepartId",
                        column: x => x.departmentDepartId,
                        principalTable: "Departments",
                        principalColumn: "DepartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "Fiance" },
                    { 3, "IT" },
                    { 4, "QA" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Eid", "Department", "DeptId", "Email", "Ename", "departmentDepartId" },
                values: new object[,]
                {
                    { 101, 3, 3, "s@gmail.com", "Sarah", null },
                    { 102, 1, 1, "m@gmail.com", "Michael", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentDepartId",
                table: "Employees",
                column: "departmentDepartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
