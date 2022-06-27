﻿using System.Net;
using System.Net.Mail;

namespace notaria.Helpers
{
    public class MailService
    {
        IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void SendEmailGmail(String receptor, String asunto, String mensaje)
        {
            MailMessage mail = new MailMessage();

            String usermail = this.configuration["usuariogmail"];
            String passwordmail = this.configuration["passwordgmail"];

            Console.WriteLine(usermail);

            mail.From = new MailAddress(usermail);
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            String smtpserver = this.configuration["hostGmail"];
            int port = int.Parse(this.configuration["portGmail"]);
            bool ssl = bool.Parse(this.configuration["sslGmail"]);
            bool defaultcreadentials = bool.Parse(this.configuration["defaultcredentialsGmail"]);

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = smtpserver;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
            smtpClient.UseDefaultCredentials = defaultcreadentials;


            NetworkCredential usercredential = new NetworkCredential(usermail, passwordmail);

            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }
    }
}