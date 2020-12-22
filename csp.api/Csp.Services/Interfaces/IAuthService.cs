using Csp.DAL.Models;
using System.Threading.Tasks;

namespace Csp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Login(string loginName, string password);

    }
}
