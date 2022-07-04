using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class ThuVienRepository : IThuVien
    {
        private readonly E_LibraryDbContext _context;
        public ThuVienRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(ThuVien ThuVien)
        {
            try
            {
                _context.ThuVien.Add(ThuVien);
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
                var ChoGiup = _context.ThuVien.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.ThuVien.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public ThuVien Detail(int id)
        {
            return _context.ThuVien.Find(id);
        }

        public List<ThuVien> GetAll()
        {
            return _context.ThuVien.ToList();
        }

        public string Update(ThuVien ThuVien)
        {
            try
            {
                _context.Entry(ThuVien).State = EntityState.Modified;
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
            if (_context.ThuVien.Find(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}