using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class BoMonBUS : IBoMonBUS
    {
        private readonly IBoMon _BoMonRepository;

        public BoMonBUS(IBoMon boMon)
        {
            _BoMonRepository = boMon;
        }

        public string Add(string tenBoMon)
        {
            return _BoMonRepository.Add(tenBoMon);
        }

        public string Delete(int id)
        {
            if(!_BoMonRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _BoMonRepository.Delete(id);
        }

        public BoMon Detail(int id)
        {
           
            return _BoMonRepository.Detail(id);
        }

        public List<BoMon> GetAlias(string alias)
        {
            return _BoMonRepository.GetAlias(alias);    
        }

        public List<BoMon> GetAll()
        {
            return _BoMonRepository.GetAll();
        }

        public List<BoMon> OrderBy()
        {
            return _BoMonRepository.OrderBy();
        }

        public string Update(BoMon boMon)
        {
           
            return _BoMonRepository.Update(boMon);
        }
    }
}