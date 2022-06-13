using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Model
{
    public class TepRieng
    {
        public int Id { get; set; }
        public string TenTep { get; set; }
        public string? TheLoai { get; set; }
        public string? LoaiTep { get; set; }
        public string NguoiChinhSua { get; set; }
        public DateTime? NgaySuaCuoi { get; set; }
        public string File { get; set; }
        public int? KichThuoc { get; set; }

       

    }
}
