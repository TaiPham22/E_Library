using E_Library.Model;
using E_Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.Repository.Repository
{
    public class TaiKhoanRepository : ITaiKhoan
    {
        private readonly E_LibraryDbContext _context;
        private readonly UserManager<TaiKhoan> userManager;
        public TaiKhoanRepository(E_LibraryDbContext context, UserManager<TaiKhoan> taiKhoan)
        {
            _context = context;
            userManager = taiKhoan;
        }

        public string Add(CreateUser TaiKhoan)
        {
            TaiKhoan user = new TaiKhoan()
            {
                UserName = TaiKhoan.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = TaiKhoan.Email,
                PhoneNumber = TaiKhoan.PhoneNumber,
            };
            var result = userManager.CreateAsync(user, TaiKhoan.PassWord);
            if (!result.Result.Succeeded)
                return "Tao khong thanh cong";

            return "Tao thanh cong";
            
        }

        public string Delete(string id)
        {
            try {
                var TaiKhoan =  _context.TaiKhoan.Find(id);
                if (TaiKhoan == null)
                {
                    return "Tim khong thay";
                }

                _context.TaiKhoan.Remove(TaiKhoan);
                _context.SaveChanges();
                return "Xoa thanh cong";
            }
            catch(Exception ex) {
                return "Xoa khong thanh cong";
            } 
        }

        public TaiKhoan Detail(string id)
        {
            return _context.TaiKhoan.Find(id);
        }

        public List<TaiKhoan> GetAlias(string alias)
        {
            return _context.TaiKhoan.Where(n => n.UserName.Contains(alias)).ToList();
        }

        public List<TaiKhoan> GetAll()
        {
            return _context.TaiKhoan.ToList();
        }

        public List<TaiKhoan> OrderBy()
        {
            return _context.TaiKhoan.OrderBy(m => m.UserName).ToList();
        }

        public string Update(TaiKhoan TaiKhoan)
        {
            try
            {
                _context.Entry(TaiKhoan).State = EntityState.Modified;
                _context.SaveChanges();
                return "Cap nhat thanh cong";
            }
            catch(Exception ex)
            {
                return "Cap nhat khong thanh cong";
            }
        }
        public bool Exist(string id)
        {
           if(_context.TaiKhoan.Find(id)==null)
            {
                return false;
            }
            return true;
        }
    }
}