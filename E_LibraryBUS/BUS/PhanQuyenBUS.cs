using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class PhanQuyenBUS : IPhanQuyenBUS
    {
        private readonly IPhanQuyen _PhanQuyenRepository;

        public PhanQuyenBUS(IPhanQuyen PhanQuyen)
        {
            _PhanQuyenRepository = PhanQuyen;
        }

        public string Add(PhanQuyen PhanQuyen)
        {
            return _PhanQuyenRepository.AddPhanQuyen(PhanQuyen);
        }

        public string Delete(int id)
        {
            if(!_PhanQuyenRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _PhanQuyenRepository.Delete(id);
        }

        public PhanQuyen Detail(int id)
        {
           
            return _PhanQuyenRepository.Detail(id);
        }

        public List<PhanQuyen> GetAlias(string alias)
        {
            return _PhanQuyenRepository.GetAlias(alias);    
        }

        public List<PhanQuyen> GetAll()
        {
            return _PhanQuyenRepository.GetAll();
        }

        public List<PhanQuyen> OrderBy()
        {
            return _PhanQuyenRepository.OrderBy();
        }

        public string Update(PhanQuyen PhanQuyen)
        {
           
            return _PhanQuyenRepository.Update(PhanQuyen);
        }
    }
}