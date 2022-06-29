using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class ChuDeRepository : IChuDe
    {
        private readonly E_LibraryDbContext _context;
        public ChuDeRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(string tenChuDe)
        {
            try
            {
                _context.ChuDe.Add(new ChuDe { Id = 0, TenChuDe = tenChuDe });
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
                var ChuDe = _context.ChuDe.Find(id);
                if (ChuDe == null)
                {
                    return "Tim khong thay";
                }

                _context.ChuDe.Remove(ChuDe);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public ChuDe Detail(int id)
        {
            return _context.ChuDe.Find(id);
        }

        public List<ChuDe> GetAlias(string alias)
        {
            return _context.ChuDe.Where(n => n.TenChuDe.Contains(alias)).ToList();
        }

        public List<ChuDe> GetAll()
        {
            return _context.ChuDe.ToList();
        }

        public List<ChuDe> OrderBy()
        {
            return _context.ChuDe.OrderBy(m => m.TenChuDe).ToList();
        }

        public string Update(ChuDe ChuDe)
        {
            try
            {
                _context.Entry(ChuDe).State = EntityState.Modified;
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
            if (_context.ChuDe.Find(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}