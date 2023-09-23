using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileSharingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AttachmentLenghtFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Attachment",
                table: "Files",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Attachment",
                table: "Files",
                type: "varbinary",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
