using CleanArchitectureTemplate.Application.Models;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
