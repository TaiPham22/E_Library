using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Model
{
  
    public class VaiTro
    {
        public int Id { get; set; }
        public string TenVaiTro { get; set; }

        public string MoTa { get; set; }
        

        public int TaiNguyen { get; set; }

        public DateTime? NgayCapNhatCuoi { get; set; }

        public int ThongBao { get; set; }

  

        
    }
}
