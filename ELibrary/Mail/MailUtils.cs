using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace ELibrary.Mail
{
    public static class MailUtils
    {

        /// <summary>
        /// Gửi Email
        /// </summary>
        /// <param name="_from">Địa chỉ email gửi</param>
        /// <param name="_to">Địa chỉ email nhận</param>
        /// <param name="_subject">Chủ đề của email</param>
        /// <param name="_body">Nội dung (hỗ trợ HTML) của email</param>
        /// <param name="client">SmtpClient - kết nối smtp để chuyển thư</param>
        /// <returns>Task</returns>
        
        public static async Task<string> SendMail(string _to, string _body)
        {
            string _from = "ptai22092001@gmail.com";
            string _subject = "Xác thực tài khoản E_Library";
            string _gmail = "ptai22092001@gmail.com";
            string _password = "9longgiang";
            try
            {
                // Tạo nội dung Email
                using (MailMessage message = new MailMessage(
                 from: _from,
                 to: _to,
                 subject: _subject,
                 body: _body
                     ))
                {
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.IsBodyHtml = true;
                    message.ReplyToList.Add(new MailAddress(_from));
                    message.Sender = new MailAddress(_from);
                     using var smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(_gmail, _password);
                    await smtpClient.SendMailAsync(message);
                }
                return "Gui mail thanh cong";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}