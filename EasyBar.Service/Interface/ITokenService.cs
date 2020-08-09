using EasyBar.Domain.Entity.Authentication;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Service.Interface
{
    public interface ITokenService
    {
        IResult Generate(LoginDto credentialsEntity);
    }
}
