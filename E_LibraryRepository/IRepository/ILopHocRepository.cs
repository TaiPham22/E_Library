using E_Library.Model;

namespace E_Library.Repository.IRepository
{
    public interface ILopHoc
    {
        public string Add(LopHoc lopHoc);
        public string Delete(int id);
        public string Update(LopHoc lopHoc);
        public List<LopHoc> GetAll();
        public List<LopHoc> GetAlias(string alias);
        public List<LopHoc> OrderBy();
        public LopHoc Detail(int id);
        public bool Exist(int id);
    }
}