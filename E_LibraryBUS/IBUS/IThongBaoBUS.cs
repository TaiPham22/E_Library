using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface IThongBaoBUS
    {
        public string Add(ThongBao thongBao);
        public string Delete(int id);
        public string Update(ThongBao thongBao);
        public List<ThongBao> GetAll(bool phanloai);
        public List<ThongBao> GetAlias(string alias, bool phanloai);
        public List<ThongBao> OrderBy(bool phanloai);
        public ThongBao Detail(int id);
    }
}