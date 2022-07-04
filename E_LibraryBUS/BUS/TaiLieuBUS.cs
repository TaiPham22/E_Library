using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class TaiLieuBUS : ITaiLieuBUS
    {
        private readonly ITaiLieu _TaiLieuRepository;

        public TaiLieuBUS(ITaiLieu TaiLieu)
        {
            _TaiLieuRepository = TaiLieu;
        }

        public string Add(TaiLieu TaiLieu)
        {
            return _TaiLieuRepository.Add(TaiLieu);
        }

        public string Delete(int id)
        {
            if(!_TaiLieuRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _TaiLieuRepository.Delete(id);
        }

        public TaiLieu Detail(int id)
        {
           
            return _TaiLieuRepository.Detail(id);
        }

        public List<TaiLieu> GetAlias(string alias)
        {
            return _TaiLieuRepository.GetAlias(alias);    
        }

        public List<TaiLieu> GetAll()
        {
            return _TaiLieuRepository.GetAll();
        }

        public List<TaiLieu> OrderBy(int ds)
        {
            return _TaiLieuRepository.OrderBy(ds);
        }

        public string Update(TaiLieu TaiLieu)
        {
           
            return _TaiLieuRepository.Update(TaiLieu);
        }
        public string PheDuyet(int id, bool tinhtrang)
        {
            return _TaiLieuRepository.PheDuyet(id, tinhtrang);
        }
        public string AddMonHoc(int id, int mon)
        {
            return _TaiLieuRepository.AddMonHoc(id, mon);
        }
        public string AddLopHoc(int id, int lop)
        {
            return _TaiLieuRepository.AddLopHoc(id, lop);
        }
    }
}