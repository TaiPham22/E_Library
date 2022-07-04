using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class ThongBaoBUS : IThongBaoBUS
    {
        private readonly IThongBao _ThongBaoRepository;

        public ThongBaoBUS(IThongBao ThongBao)
        {
            _ThongBaoRepository = ThongBao;
        }

        public string Add(ThongBao ThongBao)
        {
            return _ThongBaoRepository.Add(ThongBao);
        }

        public string Delete(int id)
        {
            if(!_ThongBaoRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _ThongBaoRepository.Delete(id);
        }

        public ThongBao Detail(int id)
        {
           
            return _ThongBaoRepository.Detail(id);
        }

        public List<ThongBao> GetAlias(string alias, bool phanloai)
        {
            return _ThongBaoRepository.GetAlias(alias,phanloai);    
        }

        public List<ThongBao> GetAll(bool phanloai)
        {
            return _ThongBaoRepository.GetAll(phanloai);
        }

        public List<ThongBao> OrderBy(bool phanloai)
        {
            return _ThongBaoRepository.OrderBy(phanloai);
        }

        public string Update(ThongBao ThongBao)
        {
           
            return _ThongBaoRepository.Update(ThongBao);
        }
    }
}