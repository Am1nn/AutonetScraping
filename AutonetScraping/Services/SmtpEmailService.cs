using System;
using System.Net.Mail;
using System.Net;

namespace AutonetScraping.Services
{
    public class SmtpEmailService
    {
        public void SendEmail(int? generatedPlates)
        {
            var fromAddress = new MailAddress("aminbnnayev926@gmail.com", "AutoHomeServices");
            var toAddress = new MailAddress("aminbennayevv@gmail.com", "");

            const string fromPassword = "iqqxfmrtlbkorlbx";
            const string subject = "AutoHome";
            string body = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: black;
                            color: white;
                            margin: 0;
                            padding: 0;
                        }}
                        .container {{
                            width: 80%;
                            margin: auto;
                            padding: 20px;
                            background-color: #222;
                            border-radius: 10px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
                        }}
                        .header {{
                            text-align: center;
                            padding: 10px 0;
                            border-bottom: 1px solid #444;
                        }}
                        .header h1 {{
                            color: red;
                            margin: 0;
                        }}
                        .content {{
                            text-align: center; /* Ortalanan metin */
                            padding: 20px 0;
                        }}
                        .footer {{
                            text-align: center;
                            padding: 10px 0;
                            border-top: 1px solid #444;
                            font-size: 12px;
                            color: #aaa;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Plate Scraping</h1>
                        </div>
                        <div class='content'>
                            <p style='font-weight: bold; color: white;'>Generated Plates: {generatedPlates}</p>
                        </div>
                        <div class='footer'>
                            <p>AutoHome - All rights reserved</p>
                        </div>
                    </div>
                </body>
                </html>";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true 
            })
            {
                smtp.Send(message);
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Email sent successfully.");
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
