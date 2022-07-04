using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class TaiLieuRepository : ITaiLieu
    {
        private readonly E_LibraryDbContext _context;
        public TaiLieuRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(TaiLieu TaiLieu)
        {
            try
            {
                _context.TaiLieu.Add(TaiLieu);
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
                var ChoGiup = _context.TaiLieu.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.TaiLieu.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public TaiLieu Detail(int id)
        {
            return _context.TaiLieu.Find(id);
        }

        public List<TaiLieu> GetAlias(string alias)
        {
            return _context.TaiLieu.Where(n => n.TenTaiLieu.Contains(alias)||n.TieuDe.Contains(alias)).ToList();
        }

        public List<TaiLieu> GetAll()
        {
            return _context.TaiLieu.ToList();
        }

        public List<TaiLieu> OrderBy(int ds)
        {
            switch(ds)
            {
                case 1: return _context.TaiLieu.OrderBy(m => m.MonHocId).ToList();break;
                case 2: return _context.TaiLieu.OrderBy(m => m.TenTaiLieu).ToList();break;
                default: 
                        return _context.TaiLieu.OrderBy(m => m.Id).ToList();
            }
        }

        public string Update(TaiLieu TaiLieu)
        {
            try
            {
                _context.Entry(TaiLieu).State = EntityState.Modified;
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
            if (_context.TaiLieu.Find(id) == null)
            {
                return false;
            }
            return true;
        }

        public string PheDuyet(int id ,bool tinhtrang)
        {
            if(!Exist(id))
            {
                return "Tim khong thay";
            }
            var value = Detail(id);
            value.TinhTrang = tinhtrang;
            return Update(value);
        }

        public string AddMonHoc(int id, int mon)
        {
            if (!Exist(id))
            {
                return "Tim khong thay";
            }
            try
            {
                var value = _context.TaiLieu.Find(id);
                value.MonHocId = mon;
                Update(value);
                return "Them thanh cong";
            }
            catch(Exception ex)
            {
                return "Them khong thanh cong";
            }
        }

        public string AddLopHoc(int id, int lop)
        {
            if (!Exist(id))
            {
                return "Tim khong thay";
            }
            try
            {
                var value = new LopHocTaiLieu { LopHocId = lop, TaiLieuId = id };
                _context.LopHocTaiLieu.Add(value);
                _context.SaveChanges();
                return "Them thanh cong";
            }
            catch (Exception ex)
            {
                return "Them khong thanh cong";
            }
        }
    }
}