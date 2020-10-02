using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSP.WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "base");

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "job_statuses",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "treatments",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "base",
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookingId = table.Column<Guid>(nullable: false),
                    TreatmentId = table.Column<Guid>(nullable: false),
                    JobStatusId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobs_bookings_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "base",
                        principalTable: "bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobs_job_statuses_JobStatusId",
                        column: x => x.JobStatusId,
                        principalSchema: "base",
                        principalTable: "job_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobs_treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "base",
                        principalTable: "treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ClientId",
                schema: "base",
                table: "bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_BookingId",
                schema: "base",
                table: "jobs",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_JobStatusId",
                schema: "base",
                table: "jobs",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_TreatmentId",
                schema: "base",
                table: "jobs",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs",
                schema: "base");

            migrationBuilder.DropTable(
                name: "bookings",
                schema: "base");

            migrationBuilder.DropTable(
                name: "job_statuses",
                schema: "base");

            migrationBuilder.DropTable(
                name: "treatments",
                schema: "base");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "base");
        }
    }
}
