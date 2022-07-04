using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface IVaiTroBUS
    {
        public string Add(VaiTro VaiTro);
        public string VaiTroPhanQuyen(VaiTroPhanQuyen vaiTrophanQuyen);
        public string Delete(int id);
        public string Update(VaiTro VaiTro);
        public List<VaiTro> GetAll();
        public List<VaiTro> GetAlias(string alias);
        public List<VaiTro> OrderBy();
        public VaiTro Detail(int id);
    }
}