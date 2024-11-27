namespace Car_Rental_System_API.Services
{
    public interface INotificationService
    {
        Task SendRentalConfirmationAsync(string email, string carDetails);
    }
}
