using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface IChuDe
    {
        public string Add(string tenChuDe);
        public string Delete(int id);
        public string Update(ChuDe chuDe);
        public List<ChuDe> GetAll();
        public List<ChuDe> GetAlias(string alias);
        public List<ChuDe> OrderBy();
        public ChuDe Detail(int id);
        public bool Exist(int id);
    }
}