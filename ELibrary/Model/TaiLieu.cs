using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Model
{
    public class TaiLieu
    {
        public int Id { get; set; }
        public string TenTaiLieu { get; set; }
        public string LoaiTaiLieu { get; set; }
        public string TieuDe { get; set; }
        public int MonHocId { get; set; }
        public string? TaiKhoanId { get; set; }
        public string? GhiChu { get; set; }
        public string? NguoiChinhSuaCuoi { get; set; }
        public bool? TinhTrang { get; set; }
        public DateTime? NgayGuiPheDuyet { get; set; }

        public float KichThuoc { get; set; }
    
    }
}
