using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class ThuVienBUS : IThuVienBUS
    {
        private readonly IThuVien _ThuVienRepository;

        public ThuVienBUS(IThuVien ThuVien)
        {
            _ThuVienRepository = ThuVien;
        }

        public string Add(ThuVien ThuVien)
        {
            return _ThuVienRepository.Add(ThuVien);
        }

        public string Delete(int id)
        {
            if(!_ThuVienRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _ThuVienRepository.Delete(id);
        }

        public ThuVien Detail(int id)
        {
           
            return _ThuVienRepository.Detail(id);
        }

        public List<ThuVien> GetAll()
        {
            return _ThuVienRepository.GetAll();
        }

        public string Update(ThuVien ThuVien)
        {
           
            return _ThuVienRepository.Update(ThuVien);
        }
    }
}