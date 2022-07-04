using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class TepRiengBUS : ITepRiengBUS
    {
        private readonly ITepRieng _TepRiengRepository;

        public TepRiengBUS(ITepRieng TepRieng)
        {
            _TepRiengRepository = TepRieng;
        }

        public string Add(TepRieng TepRieng)
        {
            return _TepRiengRepository.Add(TepRieng);
        }

        public string Delete(int id)
        {
            if(!_TepRiengRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _TepRiengRepository.Delete(id);
        }

        public TepRieng Detail(int id)
        {
           
            return _TepRiengRepository.Detail(id);
        }

        public List<TepRieng> GetAlias(string alias)
        {
            return _TepRiengRepository.GetAlias(alias);    
        }

        public List<TepRieng> GetAll()
        {
            return _TepRiengRepository.GetAll();
        }

        public List<TepRieng> OrderBy()
        {
            return _TepRiengRepository.OrderBy();
        }

        public string Update(TepRieng TepRieng)
        {
           
            return _TepRiengRepository.Update(TepRieng);
        }
    }
}