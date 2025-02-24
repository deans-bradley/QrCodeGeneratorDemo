using QrCodeGeneratorDemo.Models;
using QrCodeGeneratorDemo.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;


namespace QrCodeGeneratorDemo.Services
{
    public class EmailService : IEmailService
    {
        public async Task<EmailResponse> SendEmail(Email email)
        {
            string? apiKey = Environment.GetEnvironmentVariable("QR_CODE_GENERATOR_DEMO_SEND_GRID_API_KEY");

            SendGridClient client = new SendGridClient(apiKey);
            SendGridMessage msg = MailHelper.CreateSingleEmail(email.From, email.To, email.Subject, String.Empty, email.Body);
            msg.AddAttachment(email.Attatchment);

            try 
            {
                Response response = await client.SendEmailAsync(msg);
                EmailResponse emailResponse = new EmailResponse();
                
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted)
                {
                    emailResponse.Message = "Email sent successfully!";
                    emailResponse.IsSuccess = true;
                }
                else 
                {
                    emailResponse.Message = "Failed to send email!";
                    emailResponse.IsSuccess = false;
                    emailResponse.StatusCode = (int)response.StatusCode;
                }

                return emailResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new EmailResponse
                {
                    ErrorMessage = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}