using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class TepRiengRepository : ITepRieng
    {
        private readonly E_LibraryDbContext _context;
        public TepRiengRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(TepRieng TepRieng)
        {
            try
            {
                _context.TepRieng.Add(TepRieng);
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
                var ChoGiup = _context.TepRieng.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.TepRieng.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public TepRieng Detail(int id)
        {
            return _context.TepRieng.Find(id);
        }

        public List<TepRieng> GetAlias(string alias)
        {
            return _context.TepRieng.Where(n => n.TenTep.Contains(alias)).ToList();
        }

        public List<TepRieng> GetAll()
        {
            return _context.TepRieng.ToList();
        }

        public List<TepRieng> OrderBy()
        {
            return _context.TepRieng.OrderBy(m => m.TenTep).ToList();
        }

        public string Update(TepRieng TepRieng)
        {
            try
            {
                _context.Entry(TepRieng).State = EntityState.Modified;
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
            if (_context.TepRieng.Find(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}