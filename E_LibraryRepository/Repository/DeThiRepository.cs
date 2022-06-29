using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class DeThiRepository : IDeThi
    {
        private readonly E_LibraryDbContext _context;
        public DeThiRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(DeThi DeThi)
        {
            try
            {
                _context.DeThi.Add(DeThi);
                _context.SaveChanges();
                return "Them thanh cong";
            }
            catch (Exception ex)
            {
                return "Them khong thanh cong";
            }

        }

        public string Delete(int id)
        {
            try
            {
                var ChoGiup = _context.DeThi.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.DeThi.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public DeThi Detail(int id)
        {
            return _context.DeThi.Find(id);
        }

        public List<DeThi> GetAlias(string alias)
        {
            return _context.DeThi.Where(n => n.TenDeThi.Contains(alias)).ToList();
        }

        public List<DeThi> GetAll()
        {
            return _context.DeThi.ToList();
        }

        public List<DeThi> OrderBy(int combobox=0)
        {
            switch(combobox)
            {
                case 1: return _context.DeThi.OrderBy(m => m.MonHocId).ToList(); break;
                case 2: return _context.DeThi.OrderBy(m => m.TinhTrang).ToList(); break;
                case 3: return _context.DeThi.OrderBy(m => m.NgayTao).ToList(); break;
                default: return _context.DeThi.OrderBy(m => m.TenDeThi).ToList();

            }
        }

        public string Update(DeThi DeThi)
        {
            try
            {
                _context.Entry(DeThi).State = EntityState.Modified;
                _context.SaveChanges();
                return "Cap nhat thanh cong";
            }
            catch (Exception ex)
            {
                return "Cap nhat khong thanh cong";
            }
        }
        public bool Exist(int id)
        {
            if (_context.DeThi.Find(id) == null)
            {
                return false;
            }
            return true;
        }

        public string PheDuyet(int id, bool trangThai)
        {
            if (Exist(id))
            {
                return "Tim khong thay ket qua";
            }
            var deThi = Detail(id);
            deThi.TinhTrang = trangThai;
            return Update(deThi);
        }
    }
}