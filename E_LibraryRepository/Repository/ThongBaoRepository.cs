using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class ThongBaoRepository : IThongBao
    {
        private readonly E_LibraryDbContext _context;
        public ThongBaoRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(ThongBao ThongBao)
        {
            try
            {
                _context.ThongBao.Add(ThongBao);
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
                var ChoGiup = _context.ThongBao.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.ThongBao.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public ThongBao Detail(int id)
        {
            return _context.ThongBao.Find(id);
        }

        public List<ThongBao> GetAlias(string alias, bool phanloai)
        {
            return _context.ThongBao.Where(n => (n.ChuDe.Contains(alias)||n.NoiDung.Contains(alias))&&n.LoaiThongBao==phanloai).ToList();
        }

        public List<ThongBao> GetAll(bool phanloai)
        {
            return _context.ThongBao.Where(n=>n.LoaiThongBao==phanloai).ToList();
        }

        public List<ThongBao> OrderBy(bool phanloai)
        {
            return _context.ThongBao.OrderBy(m => m.ChuDe ).Where(m=>m.LoaiThongBao== phanloai).ToList();
        }

        public string Update(ThongBao ThongBao)
        {
            try
            {
                _context.Entry(ThongBao).State = EntityState.Modified;
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
            if (_context.ThongBao.Find(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}