﻿using E_Library.Model;

namespace E_Library.BUS.IBUS
{
    public interface ITaiKhoanBUS
    {
        public string Add(CreateUser taiKhoan);
        public string Delete(string id);
        public string Update(TaiKhoan taiKhoan);
        public List<TaiKhoan> GetAll();
        public List<TaiKhoan> GetAlias(string alias);
        public TaiKhoan Detail(string id);
        public bool Exist(string id);
    }
}