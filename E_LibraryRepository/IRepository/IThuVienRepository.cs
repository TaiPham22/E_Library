using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface IThuVien
    {
        public string Add(ThuVien thuVien);
        public string Delete(int id);
        public string Update(ThuVien thuVien);
        public List<ThuVien> GetAll();
        public ThuVien Detail(int id);
        public bool Exist(int id);
    }
}