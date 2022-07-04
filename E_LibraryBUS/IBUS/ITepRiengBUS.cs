using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface ITepRiengBUS
    {
        public string Add(TepRieng tepRieng);
        public string Delete(int id);
        public string Update(TepRieng tepRieng);
        public List<TepRieng> GetAll();
        public List<TepRieng> GetAlias(string alias);
        public List<TepRieng> OrderBy();
        public TepRieng Detail(int id);
    }
}