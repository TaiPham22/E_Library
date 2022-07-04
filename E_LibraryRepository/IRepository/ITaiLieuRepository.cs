using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface ITaiLieu
    {
        public string Add(TaiLieu taiLieu);
        public string AddMonHoc(int id,int lop);
        public string AddLopHoc(int id, int mon);
        public string Delete(int id);
        public string Update(TaiLieu taiLieu);
        public List<TaiLieu> GetAll();
        public List<TaiLieu> GetAlias(string alias);
        public List<TaiLieu> OrderBy(int ds);
        public TaiLieu Detail(int id);
        public string PheDuyet(int id,bool tinhtrang);
        public bool Exist(int id);
    }
}