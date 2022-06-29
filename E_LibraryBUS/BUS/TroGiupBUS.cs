using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class TroGiupBUS : ITroGiupBUS
    {
        private readonly ITroGiup _TroGiupRepository;

        public TroGiupBUS(ITroGiup TroGiup)
        {
            _TroGiupRepository = TroGiup;
        }

        public string Add(TroGiup troGiup)
        {
            return _TroGiupRepository.Add(troGiup);
        }

        public string Delete(int id)
        {
            if(!_TroGiupRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _TroGiupRepository.Delete(id);
        }

        public TroGiup Detail(int id)
        {
           
            return _TroGiupRepository.Detail(id);
        }

        public List<TroGiup> GetAlias(string alias)
        {
            return _TroGiupRepository.GetAlias(alias);    
        }

        public List<TroGiup> GetAll()
        {
            return _TroGiupRepository.GetAll();
        }

        public List<TroGiup> OrderBy()
        {
            return _TroGiupRepository.OrderBy();
        }

        public string Update(TroGiup TroGiup)
        {
           
            return _TroGiupRepository.Update(TroGiup);
        }
    }
}