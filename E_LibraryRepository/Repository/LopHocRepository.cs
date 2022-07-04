using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class LopHocRepository : ILopHoc
    {
        private readonly E_LibraryDbContext _context;
        public LopHocRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(LopHoc LopHoc)
        {
            try
            {
                _context.LopHoc.Add(LopHoc);
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
                var ChoGiup = _context.LopHoc.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.LopHoc.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public LopHoc Detail(int id)
        {
            return _context.LopHoc.Find(id);
        }

        public List<LopHoc> GetAlias(string alias)
        {
            return _context.LopHoc.Where(n => n.TenLop.Contains(alias)).ToList();
        }

        public List<LopHoc> GetAll()
        {
            return _context.LopHoc.ToList();
        }

        public List<LopHoc> OrderBy()
        {
            return _context.LopHoc.OrderBy(m => m.TenLop).ToList();
        }

        public string Update(LopHoc LopHoc)
        {
            try
            {
                _context.Entry(LopHoc).State = EntityState.Modified;
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
            if (_context.LopHoc.Find(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}