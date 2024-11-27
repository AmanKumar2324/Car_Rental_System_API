using System.Threading.Tasks;

namespace Car_Rental_System_API.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendRentalConfirmationAsync(string email, string carDetails)
        {
            // Use an email provider like SendGrid or SMTP to send emails
            Console.WriteLine($"Email sent to {email}: Rental confirmed for {carDetails}");
            await Task.CompletedTask;
        }
    }
}
