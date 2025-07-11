using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Migrations
{
    /// <inheritdoc />
    public partial class prescription1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "prescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
