using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface ITroGiupBUS
    {
        public string Add(TroGiup troGiup);
        public string Delete(int id);
        public string Update(TroGiup troGiup);
        public List<TroGiup> GetAll();
        public List<TroGiup> GetAlias(string alias);
        public List<TroGiup> OrderBy();
        public TroGiup Detail(int id);
    }
}