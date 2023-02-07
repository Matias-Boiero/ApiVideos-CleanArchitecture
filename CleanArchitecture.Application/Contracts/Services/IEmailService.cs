using CleanArchitecture.Application.Contracts.Models;

namespace CleanArchitecture.Application.Contracts.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
