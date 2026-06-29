using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi08_EFCoreCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loais",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loais", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    MaHh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.MaHh);
                    table.ForeignKey(
                        name: "FK_HangHoas_Loais_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loais",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoas",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoas");

            migrationBuilder.DropTable(
                name: "Loais");
        }
    }
}
