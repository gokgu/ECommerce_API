using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], "Technology ECommerce", System.Text.Encoding.UTF8);

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
        }

        public async Task SendCompletedOrderMailAsync(string to, string customerName, string orderCode, DateTime orderDate, Product product)
        {
            string mail = $"Sayın {customerName} Merhaba, <br><br>" + $"{orderDate} tarihinde vermiş olduğunuz {orderCode} kodlu siparişiniz oluşturulmuştur.<br>" +
                          $"Sipariş detayınız aşağıda verilmiştir.<br>" + $"<ul><li>Ürün Adı : {product.Name} </li><li>Adet : {product.Quantity} </li>" +
                          $"<li>Birim Fiyat : {product.Price} </li></ul><br>" +
                          $"Bizi tercih ettiğiniz için teşekkür ederiz.";

            await SendMailAsync(to, $"{orderCode} Numaralı Siparişiniz Oluşturuldu.", mail);
        }
    }
}
