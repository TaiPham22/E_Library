using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Model
{
    public class VaiTroPhanQuyen
    {
        public int Id { get; set; }

        public int VaiTroId { get; set; }
        public VaiTro VaiTro { get; set; }
        public int PhanQuyenId { get; set; }
        public PhanQuyen PhanQuyen { get; set; }
    }
}
