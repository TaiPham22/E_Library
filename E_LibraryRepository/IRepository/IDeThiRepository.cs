using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface IDeThi
    {
        public string Add(DeThi deThi);
        public string Delete(int id);
        public string Update(DeThi deThi);
        public string PheDuyet(int id, bool trangThai);
        public List<DeThi> GetAll();
        public List<DeThi> GetAlias(string alias);
        public List<DeThi> OrderBy(int combobox);
        public DeThi Detail(int id);
        public bool Exist(int id);
    }
}