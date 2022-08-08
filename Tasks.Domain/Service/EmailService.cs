using System;
using System.Net;
using System.Net.Mail;

namespace Tasks.Domain.Service
{
    public class EmailService
    {
        public string Addressee { get; set; }
        public string EmailContent { get; set; }

        #region Propriedades Privadas
        
        private string EmailSender { get; set; } = "condedrakula.corp@gmail.com";
        private string PasswordSender { get; set; } = "ozhuwogevqpcspro";

        #endregion

        public EmailService(string addressee, string emailContent)
        {
            Addressee = addressee;
            EmailContent = emailContent;
        }

        public void SendEmail()
        {
            MailMessage mail = new MailMessage();
            mail.Sender = new MailAddress(EmailSender);
            mail.From = new MailAddress(EmailSender);
            mail.To.Add(new MailAddress(Addressee));
            mail.Body = EmailContent;
            mail.Priority = MailPriority.High;

            try
            {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential(EmailSender, PasswordSender);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
