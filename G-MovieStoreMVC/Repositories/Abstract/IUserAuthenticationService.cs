using G_MovieStoreMVC.Models.DTO;

namespace G_MovieStoreMVC.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);

        Task LogoutAsync();
        Task<Status> RegisterAsync(RegisterModel model);
    }
}
