using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface IVaiTro
    {
        public string AddVaiTro(VaiTro vaiTro);
        public string VaiTroPhanQuyen(VaiTroPhanQuyen vaiTrophanQuyen);
        public string Delete(int id);
        public string Update(VaiTro VaiTro);
        public List<VaiTro> GetAll();
        public List<VaiTro> GetAlias(string alias);
        public List<VaiTro> OrderBy();
        public VaiTro Detail(int id);
        public bool Exist(int id);
    }
}