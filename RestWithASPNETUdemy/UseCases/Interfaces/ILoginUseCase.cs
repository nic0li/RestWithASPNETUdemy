using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.UseCases.Interfaces
{
    public interface ILoginUseCase
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string username);
    }
}
