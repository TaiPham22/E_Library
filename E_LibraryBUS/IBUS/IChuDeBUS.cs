using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface IChuDeBUS
    {
        public string Add(string tenChuDe);
        public string Delete(int id);
        public string Update(ChuDe ChuDe);
        public List<ChuDe> GetAll();
        public List<ChuDe> GetAlias(string alias);
        public List<ChuDe> OrderBy();
        public ChuDe Detail(int id);
    }
}