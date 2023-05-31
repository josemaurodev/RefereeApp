using RefereeAPI.Entities;

namespace RefereeAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}