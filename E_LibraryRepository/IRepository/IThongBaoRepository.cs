using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface IThongBao
    {
        public string Add(ThongBao thongBao);
        public string Delete(int id);
        public string Update(ThongBao thongBao);
        public List<ThongBao> GetAll(bool phanloai);
        public List<ThongBao> GetAlias(string alias, bool phanloai);
        public List<ThongBao> OrderBy(bool phanloai);
        public ThongBao Detail(int id);
        public bool Exist(int id);
    }
}