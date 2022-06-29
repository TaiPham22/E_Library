using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Repository.Repository
{
    public class BoMonRepository : IBoMon
    {
        private readonly E_LibraryDbContext _context;
        public BoMonRepository(E_LibraryDbContext context)
        {
            _context = context;
        }

        public string Add(string tenBoMon)
        {
            try { _context.BoMon.Add(new BoMon { Id=0,TenBoMon=tenBoMon });
            _context.SaveChanges();
            return "Them thanh cong";
            }
            catch(Exception ex)
            {
                return "Them khong thanh cong";
            }
            
        }

        public string Delete(int id)
        {
            try {
                var boMon =  _context.BoMon.Find(id);
                if (boMon == null)
                {
                    return "Tim khong thay";
                }

                _context.BoMon.Remove(boMon);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch(Exception ex) {
                return "Xoa khong thanh cong";
            } 
        }

        public BoMon Detail(int id)
        {
            return _context.BoMon.Find(id);
        }

        public List<BoMon> GetAlias(string alias)
        {
            return _context.BoMon.Where(n => n.TenBoMon.Contains(alias)).ToList();
        }

        public List<BoMon> GetAll()
        {
            return _context.BoMon.ToList();
        }

        public List<BoMon> OrderBy()
        {
            return _context.BoMon.OrderBy(m => m.TenBoMon).ToList();
        }

        public string Update(BoMon boMon)
        {
            try
            {
                _context.Entry(boMon).State = EntityState.Modified;
                _context.SaveChanges();
                return "Cap nhat thanh cong";
            }
            catch(Exception ex)
            {
                return "Cap nhat khong thanh cong";
            }
        }
        public bool Exist(int id)
        {
           if(_context.BoMon.Find(id)==null)
            {
                return false;
            }
            return true;
        }
    }
}