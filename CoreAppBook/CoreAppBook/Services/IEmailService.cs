using CoreAppBook.Models;
using System.Threading.Tasks;

namespace CoreAppBook.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        Task SendEmailForResetPassword(UserEmailOptions userEmailOptions);
    }
}