using System.Net.Mail;
using System.Net;
using System.Drawing;

namespace ERPSoft.Web.EmailSender
{
    public class Email
    {

        public string Provedor { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioSenha { get; set; }


        public Email(string provedor, string usuarioEmail, string senha)
        {
            Provedor = provedor;
            UsuarioEmail = usuarioEmail;
            UsuarioSenha = senha;
        }



        public void EnviarEmail(string Email, string Assunto, string Corpo)
        {
            var mensagem = MensagemConstrutor(Email, Assunto, Corpo);
            EnviarEmailSmtp(mensagem);
        }

        private MailMessage MensagemConstrutor(string Email, string Assunto, string Corpo)
        {
            var main = new MailMessage();
            main.From = new MailAddress(UsuarioEmail);

            main.To.Add(Email);
            main.Subject = Assunto;
            main.Body = Corpo;

            return main;
        }

        private void EnviarEmailSmtp(MailMessage mensagem) 
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = Provedor;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(UsuarioEmail, UsuarioSenha);
            smtpClient.Send(mensagem);
        }
    }
}
