using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using E_Library.Model;

namespace E_Library.Model
{
    public class E_LibraryDbContext : DbContext
    {
        public E_LibraryDbContext(DbContextOptions<E_LibraryDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<E_Library.Model.BoMon> BoMon { get; set; }

        public DbSet<E_Library.Model.DeThi> DeThi { get; set; }

        public DbSet<E_Library.Model.ChuDe> ChuDe { get; set; }

        public DbSet<E_Library.Model.MonHoc> MonHoc { get; set; }

        public DbSet<E_Library.Model.PhanQuyen> PhanQuyen { get; set; }

        public DbSet<E_Library.Model.TaiKhoan> TaiKhoan { get; set; }

        public DbSet<E_Library.Model.TaiLieu> TaiLieu { get; set; }

        public DbSet<E_Library.Model.ThuVien> ThuVien { get; set; }

        public DbSet<E_Library.Model.LopHoc> LopHoc { get; set; }
        public DbSet<E_Library.Model.LopHocMonHoc> LopHocMonHoc { get; set; }
        public DbSet<E_Library.Model.LopHocTaiLieu> LopHocTaiLieu { get; set; }

        public DbSet<E_Library.Model.ThongBao> ThongBao { get; set; }
        public DbSet<E_Library.Model.TepRieng> TepRieng { get; set; }
        public DbSet<E_Library.Model.VaiTro> VaiTro { get; set; }
        public DbSet<E_Library.Model.VaiTroPhanQuyen> VaiTroPhanQuyen { get; set; }

        public DbSet<E_Library.Model.TroGiup> TroGiup { get; set; }
    }
}