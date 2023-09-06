using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using DesafioPulseITAPI.Models;

namespace DesafioPulseITAPI.Controllers
{
    [ApiController]
    [Route("api/correo")]
    public class EnviarCorreo : Controller
    {
        [HttpPost("enviar")]
        public bool MandarCorreo ( Correo correo )
        {
            string smtpHost = "smtp.office365.com";
            int smtpPort = 587;

            // Separar destinatarios
            string destinatarios = correo.Para.Replace(";", ",");

            MailMessage mail = new MailMessage(correo.De, destinatarios, correo.Asunto, correo.Msg);
            SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);


            smtpClient.Credentials = new NetworkCredential( correo.Email, correo.Contrasena );
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send( mail );
                return true;
            }
            catch ( Exception ex )
            {

                throw;
            }
        }
    }
}
