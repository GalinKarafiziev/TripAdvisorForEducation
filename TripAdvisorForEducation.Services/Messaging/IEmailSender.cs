using System.Threading.Tasks;

namespace TripAdvisorForEducation.Services.Messaging
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
