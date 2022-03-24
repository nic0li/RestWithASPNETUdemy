using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string username);
        bool RevokeToken(string username);
        User RefreshUserInfo(User user);
    }
}
