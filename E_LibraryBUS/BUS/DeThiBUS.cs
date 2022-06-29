using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class DeThiBUS : IDeThiBUS
    {
        private readonly IDeThi _DeThiRepository;

        public DeThiBUS(IDeThi DeThi)
        {
            _DeThiRepository = DeThi;
        }

        public string Add(DeThi DeThi)
        {
            return _DeThiRepository.Add(DeThi);
        }

        public string Delete(int id)
        {
            if(!_DeThiRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _DeThiRepository.Delete(id);
        }

        public DeThi Detail(int id)
        {
           
            return _DeThiRepository.Detail(id);
        }

        public List<DeThi> GetAlias(string alias)
        {
            return _DeThiRepository.GetAlias(alias);    
        }

        public List<DeThi> GetAll()
        {
            return _DeThiRepository.GetAll();
        }

        public List<DeThi> OrderBy(int combobox)
        {
            return _DeThiRepository.OrderBy(combobox);
        }

        public string Update(DeThi DeThi)
        {
            return _DeThiRepository.Update(DeThi);
        }
        public string PheDuyet(int id,bool trangThai)
        {
            return _DeThiRepository.PheDuyet(id,trangThai);
        }


    }
}