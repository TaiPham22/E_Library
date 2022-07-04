using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Mail;
using E_Library.Model;

namespace ELibrary.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class XacThucController : ControllerBase
    {
        private readonly E_LibraryDbContext _context;

        public XacThucController(E_LibraryDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<string> TaoMaXacThuc(string _to, string sdt)
        {
            var email = await _context.TaiKhoan.Where(t => t.Email == _to || t.PhoneNumber == sdt).ToListAsync();
            if (email.Count > 0)
            {

                string Characters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
                Random r = new Random();
                string token = "";
                for (int i = 0; i < 6; i++)
                {
                    token += Characters[r.Next(Characters.Length)];
                }

                var message = await MailUtils.SendMail(_to, token);
                return message;
            }
            return "Email va so dien thoai khong trung khop";

        }



        [HttpGet]
        [Route("/DangXuat")]
        public async Task<string> DangXuat()
        {
            HttpContext.Session.Clear();
            return "Dang xuat thanh cong";
        }

        [HttpGet]
        public async Task<string> DoiMatKhau(string pass, string rePass)
        {
            if (HttpContext.Session.GetInt32("XacThuc") != 1)
            {
                return "Chua xac thuc";
            }
            if (pass == rePass)
            {
                var tk = await _context.TaiKhoan.Where(t => t.Email == HttpContext.Session.GetString("Gmail")).FirstOrDefaultAsync();
                if (tk != null)
                {
                    tk.PasswordHash = pass;
                }
                else
                {
                    return "Het phien";
                }

                var a = await _context.TaiKhoan.Where(n => n.Email == HttpContext.Session.GetString("Gmail")).ToListAsync();
                try
                {
                    _context.TaiKhoan.Update(tk);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.Remove("XacThuc");
                    var tb = new ThongBao();
                    tb.LoaiThongBao = true;
                    tb.TaiKhoanId = "";
                    tb.NoiDung = tk.UserName + " Da thay doi mat khau";
                    tb.ChuDe = "Thay doi mat khau";
                    tb.ThoiGian = DateTime.Now;
                    _context.Add(tb);
                    await _context.SaveChangesAsync();

                    return "Da luu mat khau moi";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return "Mat khau khong trung khop";
        }

        [HttpGet]
        public async Task<string> XacThucOTP(string otp)
        {
            if (HttpContext.Session.GetString("OTP") == null)
            {
                return "Dang nhap lai";
            }
            else
            if (otp == HttpContext.Session.GetString("OTP"))
            {
                HttpContext.Session.SetInt32("XacThuc", 1);
                HttpContext.Session.Remove("OTP");
                return "Xac thuc thanh cong";
            }

            string a = await TaoMaXacThuc(HttpContext.Session.GetString("Gmail"), HttpContext.Session.GetString("Sdt"));

            return "Da gui lai ma xac thuc";
        }

    }
}
