using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class MonHocRepository : IMonHoc
    {
        private readonly E_LibraryDbContext _context;
        public MonHocRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(MonHoc MonHoc)
        {
            try
            {
                _context.MonHoc.Add(MonHoc);
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
                var ChoGiup = _context.MonHoc.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.MonHoc.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public MonHoc Detail(int id)
        {
            return _context.MonHoc.Find(id);
        }

        public List<MonHoc> GetAlias(string alias)
        {
            return _context.MonHoc.Where(n => n.TenMonHoc.Contains(alias)||n.MoTa.Contains(alias)).ToList();
        }

        public List<MonHoc> GetAll()
        {
            return _context.MonHoc.ToList();
        }

        public List<MonHoc> OrderBy()
        {
            return _context.MonHoc.OrderBy(m => m.TenMonHoc).ToList();
        }

        public string Update(MonHoc MonHoc)
        {
            try
            {
                _context.Entry(MonHoc).State = EntityState.Modified;
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
            if (_context.MonHoc.Find(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}