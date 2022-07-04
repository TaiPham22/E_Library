using E_Library.BUS.IBUS;
using E_Library.Model;
using E_Library.Repository.IRepository;

namespace E_Library.BUS.BUS
{
    public class VaiTroBUS : IVaiTroBUS
    {
        private readonly IVaiTro _VaiTroRepository;

        public VaiTroBUS(IVaiTro VaiTro)
        {
            _VaiTroRepository = VaiTro;
        }

        public string Add(VaiTro VaiTro)
        {
            return _VaiTroRepository.AddVaiTro(VaiTro);
        }

        public string Delete(int id)
        {
            if(!_VaiTroRepository.Exist(id))
            {
                return "Khong tim thay ket qua";
            }
            return _VaiTroRepository.Delete(id);
        }

        public VaiTro Detail(int id)
        {
           
            return _VaiTroRepository.Detail(id);
        }

        public List<VaiTro> GetAlias(string alias)
        {
            return _VaiTroRepository.GetAlias(alias);    
        }

        public List<VaiTro> GetAll()
        {
            return _VaiTroRepository.GetAll();
        }

        public List<VaiTro> OrderBy()
        {
            return _VaiTroRepository.OrderBy();
        }

        public string Update(VaiTro VaiTro)
        {
           
            return _VaiTroRepository.Update(VaiTro);
        }

        public string VaiTroPhanQuyen(VaiTroPhanQuyen vaiTrophanQuyen)
        {
            return _VaiTroRepository.VaiTroPhanQuyen(vaiTrophanQuyen);
        }
    }
}