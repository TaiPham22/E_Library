using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class LopHocBUS : ILopHocBUS
    {
        private readonly ILopHoc _LopHocRepository;

        public LopHocBUS(ILopHoc LopHoc)
        {
            _LopHocRepository = LopHoc;
        }

        public string Add(LopHoc LopHoc)
        {
            return _LopHocRepository.Add(LopHoc);
        }

        public string Delete(int id)
        {
            if(!_LopHocRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _LopHocRepository.Delete(id);
        }

        public LopHoc Detail(int id)
        {
           
            return _LopHocRepository.Detail(id);
        }

        public List<LopHoc> GetAlias(string alias)
        {
            return _LopHocRepository.GetAlias(alias);    
        }

        public List<LopHoc> GetAll()
        {
            return _LopHocRepository.GetAll();
        }

        public List<LopHoc> OrderBy()
        {
            return _LopHocRepository.OrderBy();
        }

        public string Update(LopHoc LopHoc)
        {
           
            return _LopHocRepository.Update(LopHoc);
        }
    }
}