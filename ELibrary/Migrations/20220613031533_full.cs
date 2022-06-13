using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELibrary.Migrations
{
    public partial class full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeThi_MonHoc_MonHocId",
                table: "DeThi");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_MonHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocTaiLieu_LopHoc_LopHocId",
                table: "LopHocTaiLieu");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocTaiLieu_TaiLieu_TaiLieuId",
                table: "LopHocTaiLieu");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_BoMon_BoMonId",
                table: "MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiLieu_MonHoc_MonHocId",
                table: "TaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_MonHocId",
                table: "TaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_BoMonId",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LopHocTaiLieu_LopHocId",
                table: "LopHocTaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_LopHocTaiLieu_TaiLieuId",
                table: "LopHocTaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_LopHocMonHoc_LopHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_LopHocMonHoc_MonHocId",
                table: "LopHocMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_DeThi_MonHocId",
                table: "DeThi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_MonHocId",
                table: "TaiLieu",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_BoMonId",
                table: "MonHoc",
                column: "BoMonId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocTaiLieu_LopHocId",
                table: "LopHocTaiLieu",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocTaiLieu_TaiLieuId",
                table: "LopHocTaiLieu",
                column: "TaiLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocMonHoc_LopHocId",
                table: "LopHocMonHoc",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocMonHoc_MonHocId",
                table: "LopHocMonHoc",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_MonHocId",
                table: "DeThi",
                column: "MonHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeThi_MonHoc_MonHocId",
                table: "DeThi",
                column: "MonHocId",
                principalTable: "MonHoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocMonHoc_LopHoc_LopHocId",
                table: "LopHocMonHoc",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocMonHoc_MonHoc_MonHocId",
                table: "LopHocMonHoc",
                column: "MonHocId",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocTaiLieu_LopHoc_LopHocId",
                table: "LopHocTaiLieu",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocTaiLieu_TaiLieu_TaiLieuId",
                table: "LopHocTaiLieu",
                column: "TaiLieuId",
                principalTable: "TaiLieu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_BoMon_BoMonId",
                table: "MonHoc",
                column: "BoMonId",
                principalTable: "BoMon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaiLieu_MonHoc_MonHocId",
                table: "TaiLieu",
                column: "MonHocId",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
