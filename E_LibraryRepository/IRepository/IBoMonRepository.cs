using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface IBoMon
    {
        public string Add(string tenBoMon);
        public string Delete(int id);
        public string Update(BoMon boMon);
        public List<BoMon> GetAll();
        public List<BoMon> GetAlias(string alias);
        public List<BoMon> OrderBy();
        public BoMon Detail(int id);
        public bool Exist(int id);
    }
}