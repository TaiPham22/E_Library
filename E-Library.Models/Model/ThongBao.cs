using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Library.Model
{
    public class ThongBao
    {
        public int Id { get; set; }

        public bool LoaiThongBao { get; set; }

        public string ChuDe { get; set; }

        public string TaiKhoanId { get; set; }

        public string? HocVienId { get; set; }

        public string NoiDung { get; set; }

        public DateTime ThoiGian { get; set; }

    }
}
