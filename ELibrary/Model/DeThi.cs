using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Model
{
    public class DeThi
    {
        public int Id { get; set; }

        public string TenDeThi { get; set; }

        public string Loai { get; set; }
        public int? MonHocId { get; set; }
        public string? TaiKhoanId { get; set; }
        public string HinhThuc { get; set; }
        public string NienKhoa { get; set; }
        public int ThoiLuong { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool? TinhTrang { get; set; }

        public int? NguoiPheDuyet { get; set; }
        public string? GhiChu { get; set; }



        
    }
}
