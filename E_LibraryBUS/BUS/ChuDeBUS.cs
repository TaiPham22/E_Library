using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class ChuDeBUS : IChuDeBUS
    {
        private readonly IChuDe _ChuDeRepository;

        public ChuDeBUS(IChuDe chuDe)
        {
            _ChuDeRepository = chuDe;
        }

        public string Add(string tenChuDe)
        {
            return _ChuDeRepository.Add(tenChuDe);
        }

        public string Delete(int id)
        {
            if(!_ChuDeRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _ChuDeRepository.Delete(id);
        }

        public ChuDe Detail(int id)
        {
           
            return _ChuDeRepository.Detail(id);
        }

        public List<ChuDe> GetAlias(string alias)
        {
            return _ChuDeRepository.GetAlias(alias);    
        }

        public List<ChuDe> GetAll()
        {
            return _ChuDeRepository.GetAll();
        }

        public List<ChuDe> OrderBy()
        {
            return _ChuDeRepository.OrderBy();
        }

        public string Update(ChuDe chuDe)
        {
           
            return _ChuDeRepository.Update(chuDe);
        }
    }
}