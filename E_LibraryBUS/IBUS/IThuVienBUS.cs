using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface IThuVienBUS
    {
        public string Add(ThuVien ThuVien);
        public string Delete(int id);
        public string Update(ThuVien ThuVien);
        public List<ThuVien> GetAll();
        public ThuVien Detail(int id);
    }
}