using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface IPhanQuyen
    {
        public string AddPhanQuyen(PhanQuyen phanQuyen);
        public string Delete(int id);
        public string Update(PhanQuyen phanQuyen);
        public List<PhanQuyen> GetAll();
        public List<PhanQuyen> GetAlias(string alias);
        public List<PhanQuyen> OrderBy();
        public PhanQuyen Detail(int id);
        public bool Exist(int id);
    }
}