using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Migrations
{
    /// <inheritdoc />
    public partial class aapointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlotTime",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlotTime",
                table: "appointments");
        }
    }
}
