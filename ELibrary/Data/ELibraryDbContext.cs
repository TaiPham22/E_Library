using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ELibrary.Model;

    public class ELibraryDbContext : IdentityDbContext<TaiKhoan>
{
        public ELibraryDbContext (DbContextOptions<ELibraryDbContext> options)
            : base(options)
        {
        }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }


    public DbSet<ELibrary.Model.BoMon> BoMon { get; set; }

    public DbSet<ELibrary.Model.DeThi> DeThi { get; set; }

    public DbSet<ELibrary.Model.ChuDe> ChuDe { get; set; }

    public DbSet<ELibrary.Model.MonHoc> MonHoc { get; set; }

    public DbSet<ELibrary.Model.PhanQuyen> PhanQuyen { get; set; }

    public DbSet<ELibrary.Model.TaiKhoan> TaiKhoan { get; set; }

    public DbSet<ELibrary.Model.TaiLieu> TaiLieu { get; set; }

    public DbSet<ELibrary.Model.ThuVien> ThuVien { get; set; }

    public DbSet<ELibrary.Model.LopHoc> LopHoc { get; set; }
    public DbSet<ELibrary.Model.LopHocMonHoc> LopHocMonHoc { get; set; }
    public DbSet<ELibrary.Model.LopHocTaiLieu> LopHocTaiLieu { get; set; }

    public DbSet<ELibrary.Model.ThongBao> ThongBao { get; set; }
    public DbSet<ELibrary.Model.TepRieng> TepRieng { get; set; }
    public DbSet<ELibrary.Model.VaiTro> VaiTro { get; set; }
    public DbSet<ELibrary.Model.VaiTroPhanQuyen> VaiTroPhanQuyen { get; set; }

    public DbSet<ELibrary.Model.TroGiup> TroGiup { get; set; }
}
