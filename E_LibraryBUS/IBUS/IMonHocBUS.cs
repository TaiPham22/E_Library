﻿using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface IMonHocBUS
    {
        public string Add(MonHoc monHoc);
        public string Delete(int id);
        public string Update(MonHoc monHoc);
        public List<MonHoc> GetAll();
        public List<MonHoc> GetAlias(string alias);
        public List<MonHoc> OrderBy();
        public MonHoc Detail(int id);
    }
}