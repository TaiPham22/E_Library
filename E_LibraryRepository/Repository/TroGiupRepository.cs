using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class TroGiupRepository : ITroGiup
    {
        private readonly E_LibraryDbContext _context;
        public TroGiupRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(TroGiup troGiup)
        {
            try
            {
                _context.TroGiup.Add(troGiup);
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
                var ChoGiup = _context.TroGiup.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.TroGiup.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public TroGiup Detail(int id)
        {
            return _context.TroGiup.Find(id);
        }

        public List<TroGiup> GetAlias(string alias)
        {
            return _context.TroGiup.Where(n => n.ChuDe.Contains(alias)||n.NoiDung.Contains(alias)).ToList();
        }

        public List<TroGiup> GetAll()
        {
            return _context.TroGiup.ToList();
        }

        public List<TroGiup> OrderBy()
        {
            return _context.TroGiup.OrderBy(m => m.ChuDe).ToList();
        }

        public string Update(TroGiup troGiup)
        {
            try
            {
                _context.Entry(troGiup).State = EntityState.Modified;
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
            if (_context.TroGiup.Find(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}