using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class VaiTroRepository : IVaiTro
    {
        private readonly E_LibraryDbContext _context;
        public VaiTroRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string AddVaiTro(VaiTro VaiTro)
        {
            try
            {
                _context.VaiTro.Add(VaiTro);
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
                var ChoGiup = _context.VaiTro.Find(id);
                if (ChoGiup == null)
                {
                    return "Tim khong thay";
                }

                _context.VaiTro.Remove(ChoGiup);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch (Exception ex)
            {
                return "Xoa khong thanh cong";
            }
        }

        public VaiTro Detail(int id)
        {
            return _context.VaiTro.Find(id);
        }

        public List<VaiTro> GetAlias(string alias)
        {
            return _context.VaiTro.Where(n => n.TenVaiTro.Contains(alias)).ToList();
        }

        public List<VaiTro> GetAll()
        {
            return _context.VaiTro.ToList();
        }

        public List<VaiTro> OrderBy()
        {
            return _context.VaiTro.OrderBy(m => m.TenVaiTro).ToList();
        }

        public string Update(VaiTro VaiTro)
        {
            try
            {
                _context.Entry(VaiTro).State = EntityState.Modified;
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
            if (_context.VaiTro.Find(id) == null)
            {
                return false;
            }
            return true;
        }

        public string VaiTroPhanQuyen(VaiTroPhanQuyen vaiTrophanQuyen)
        {
            try
            {
                _context.VaiTroPhanQuyen.Add(vaiTrophanQuyen);
                _context.SaveChanges();
                return "Them thanh cong";
            } catch(Exception ex)
            {
                return "Them khong thanh cong";
            }
        }
    }
}