using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class TaiKhoanBUS : ITaiKhoanBUS
    {
        private readonly ITaiKhoan _TaiKhoanRepository;

        public TaiKhoanBUS(ITaiKhoan TaiKhoan)
        {
            _TaiKhoanRepository = TaiKhoan;
        }

        public string Add(CreateUser TaiKhoan)
        {
            return _TaiKhoanRepository.Add(TaiKhoan);
        }

        public string Delete(string id)
        {
            if(!_TaiKhoanRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _TaiKhoanRepository.Delete(id);
        }

        public TaiKhoan Detail(string id)
        {
           
            return _TaiKhoanRepository.Detail(id);
        }

        public bool Exist(string id)
        {
            return _TaiKhoanRepository.Exist(id);
        }

        public List<TaiKhoan> GetAlias(string alias)
        {
            return _TaiKhoanRepository.GetAlias(alias);    
        }

        public List<TaiKhoan> GetAll()
        {
            return _TaiKhoanRepository.GetAll();
        }

        public string Update(TaiKhoan TaiKhoan)
        {
            return _TaiKhoanRepository.Update(TaiKhoan);
        }

    }
}