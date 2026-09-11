using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace DoceCantinho.Infrastructure.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarRecuperacaoSenhaAsync(
            string emailDestino,
            string linkRecuperacao)
        {
            var host = _configuration["EmailSettings:Host"];

            var port = int.Parse(
                _configuration["EmailSettings:Port"] ?? "587");

            var usuario =
                _configuration["EmailSettings:UserName"];

            var senha =
                _configuration["EmailSettings:Password"];

            var emailRemetente =
                _configuration["EmailSettings:FromEmail"]
                ?? usuario;

            var nomeRemetente =
                _configuration["EmailSettings:FromName"]
                ?? "DoceCantinho";

            using var mensagem = new MailMessage();

            mensagem.From = new MailAddress(
                emailRemetente!,
                nomeRemetente);

            mensagem.To.Add(emailDestino);

            mensagem.Subject =
                "Redefinição de senha - DoceCantinho";

            mensagem.IsBodyHtml = true;

            mensagem.Body =
                CriarEmailHtml(linkRecuperacao);

            using var smtp =
                new SmtpClient(host, port);

            smtp.EnableSsl = true;

            smtp.Credentials =
                new NetworkCredential(
                    usuario,
                    senha);

            await smtp.SendMailAsync(mensagem);
        }

        private string CriarEmailHtml(
            string linkRecuperacao)
        {
            return $@"
<!DOCTYPE html>

<html lang='pt-BR'>

<head>
    <meta charset='UTF-8'>
</head>

<body style='
    margin:0;
    padding:0;
    background:#f5f1ee;
    font-family:Arial, sans-serif;
'>

<div style='
    max-width:600px;
    margin:40px auto;
    background:white;
    border-radius:14px;
    overflow:hidden;
'>

    <div style='
        background:#2b1b16;
        padding:30px;
        text-align:center;
    '>

        <h1 style='
            color:#dda078;
            margin:0;
        '>
            🍰 DoceCantinho
        </h1>

        <p style='color:white;'>
            Doces feitos com carinho
        </p>

    </div>

    <div style='
        padding:40px 35px;
        text-align:center;
    '>

        <h2 style='color:#2b1b16;'>
            Redefinição de senha
        </h2>

        <p style='
            color:#555;
            font-size:16px;
            line-height:1.6;
        '>
            Olá!
        </p>

        <p style='
            color:#555;
            font-size:15px;
            line-height:1.6;
        '>
            Recebemos uma solicitação para redefinir
            a senha da sua conta no
            <strong>DoceCantinho</strong>.
        </p>

        <p style='
            color:#555;
            font-size:15px;
        '>
            Clique no botão abaixo para criar uma
            nova senha:
        </p>

        <div style='margin:30px 0;'>

            <a href='{linkRecuperacao}'
               style='
                    display:inline-block;
                    background:#dda078;
                    color:white;
                    text-decoration:none;
                    padding:15px 30px;
                    border-radius:8px;
                    font-size:16px;
                    font-weight:bold;
               '>
                Redefinir minha senha
            </a>

        </div>

        <p style='
            color:#888;
            font-size:13px;
        '>
            Se você não solicitou a redefinição da
            sua senha, pode ignorar este e-mail.
        </p>

    </div>

    <div style='
        background:#f8f5f3;
        padding:20px;
        text-align:center;
    '>

        <p style='
            color:#888;
            font-size:12px;
        '>
            © {DateTime.Now.Year} DoceCantinho
        </p>

    </div>

</div>

</body>

</html>";
        }
    }
}