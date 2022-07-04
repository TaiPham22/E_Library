using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class MonHocBUS : IMonHocBUS
    {
        private readonly IMonHoc _MonHocRepository;

        public MonHocBUS(IMonHoc MonHoc)
        {
            _MonHocRepository = MonHoc;
        }

        public string Add(MonHoc MonHoc)
        {
            return _MonHocRepository.Add(MonHoc);
        }

        public string Delete(int id)
        {
            if(!_MonHocRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _MonHocRepository.Delete(id);
        }

        public MonHoc Detail(int id)
        {
           
            return _MonHocRepository.Detail(id);
        }

        public List<MonHoc> GetAlias(string alias)
        {
            return _MonHocRepository.GetAlias(alias);    
        }

        public List<MonHoc> GetAll()
        {
            return _MonHocRepository.GetAll();
        }

        public List<MonHoc> OrderBy()
        {
            return _MonHocRepository.OrderBy();
        }

        public string Update(MonHoc MonHoc)
        {
           
            return _MonHocRepository.Update(MonHoc);
        }
    }
}