using Entities;
using System.Net;
using System.Net.Mail;

namespace BlogWebApplication.Utils
{
    public class MailHelper
    {
        public static bool SendMail(Contact contact)
        {
			try
			{
				SmtpClient client= new SmtpClient("mail.siteadi.com",587);
				client.Credentials = new NetworkCredential("email kullanici adi","email şifresi");
				//client.EnableSsl= true; //eğer mailde ssl kullanılıyorsa burayı aç
				MailMessage message= new MailMessage();
				message.From = new MailAddress("info@siteadi.com");
				message.To.Add("mesajınGidecegiAdres@siteadi.com");
				message.Subject = "Siteden Mesaj var";
				message.Body = $"<p>Mesaj Bilgileri; <hr/> İsim : {contact.Name} <hr/> Email : {contact.Email} <hr/> Email : {contact.Email} <hr/> Telefon : {contact.Phone} <hr/> Mesaj : {contact.Message} <hr/> Mesaj Tarihi: {contact.CreateDate}  </p>";
				message.IsBodyHtml= true;
				client.Send(message);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
        }
    }
}
