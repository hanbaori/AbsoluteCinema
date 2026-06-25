using Microsoft.AspNetCore.Identity;

namespace AbsoluteCinema.Repository
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
