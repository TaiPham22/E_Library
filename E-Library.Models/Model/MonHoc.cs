using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Library.Model
{
    public class MonHoc
    {
        private List<LopHocMonHoc> lopHocMonHoc;

        public int Id { get; set; }
        public string TenMonHoc { get; set; }

        public int BoMonId { get; set; }
        public string MoTa { get; set; }
        public bool? TinhTrang { get; set; }

        public string ThongBaoMonHoc { get; set; }






    }
}
