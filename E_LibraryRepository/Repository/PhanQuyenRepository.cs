using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class PhanQuyenRepository : IPhanQuyen
    {
        private readonly E_LibraryDbContext _context;
        public PhanQuyenRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string AddPhanQuyen(PhanQuyen PhanQuyen)
        {
            try
            {
                _context.PhanQuyen.Add(PhanQuyen);
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
                var ChoGiup = _context.PhanQuyen.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.PhanQuyen.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public PhanQuyen Detail(int id)
        {
            return _context.PhanQuyen.Find(id);
        }

        public List<PhanQuyen> GetAlias(string alias)
        {
            return _context.PhanQuyen.Where(n => n.TenPhanQuyen.Contains(alias)).ToList();
        }

        public List<PhanQuyen> GetAll()
        {
            return _context.PhanQuyen.ToList();
        }

        public List<PhanQuyen> OrderBy()
        {
            return _context.PhanQuyen.OrderBy(m => m.TenPhanQuyen).ToList();
        }

        public string Update(PhanQuyen PhanQuyen)
        {
            try
            {
                _context.Entry(PhanQuyen).State = EntityState.Modified;
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
            if (_context.PhanQuyen.Find(id) == null)
            {
                return false;
            }
            return true;
        }
        
    }
}