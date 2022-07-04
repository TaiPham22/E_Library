using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface ITaiLieuBUS
    {
        public string Add(TaiLieu taiLieu);
        public string Delete(int id);
        public string Update(TaiLieu taiLieu);
        public List<TaiLieu> GetAll();
        public List<TaiLieu> GetAlias(string alias);
        public List<TaiLieu> OrderBy(int ds);
        public TaiLieu Detail(int id);
        public string AddMonHoc(int id, int mon);
        public string AddLopHoc(int id, int lop);
        public string PheDuyet(int id, bool tinhtrang);
    }
}