using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Horizon.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionRequestAndRequestStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BootstrapColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFrom = table.Column<TimeOnly>(type: "time", nullable: false),
                    TimeTo = table.Column<TimeOnly>(type: "time", nullable: false),
                    RespondBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionRequests_RequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRequests_EmployeeId",
                table: "PermissionRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRequests_RequestStatusId",
                table: "PermissionRequests",
                column: "RequestStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRequests");

            migrationBuilder.DropTable(
                name: "RequestStatuses");
        }
    }
}
