using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface IPhanQuyenBUS
    {
        public string Add(PhanQuyen PhanQuyen);
        public string Delete(int id);
        public string Update(PhanQuyen PhanQuyen);
        public List<PhanQuyen> GetAll();
        public List<PhanQuyen> GetAlias(string alias);
        public List<PhanQuyen> OrderBy();
        public PhanQuyen Detail(int id);
    }
}