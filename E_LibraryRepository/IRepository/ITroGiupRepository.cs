using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface ITroGiup
    {
        public string Add(TroGiup tenTroGiup);
        public string Delete(int id);
        public string Update(TroGiup troGiup);
        public List<TroGiup> GetAll();
        public List<TroGiup> GetAlias(string alias);
        public List<TroGiup> OrderBy();
        public TroGiup Detail(int id);
        public bool Exist(int id);
    }
}