using System.Security.Claims;

namespace server.Extensions;

public static class ClaimsExtensions
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        return user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.GivenName).Value;
    }

    public static string GetEmail(this ClaimsPrincipal user)
    {
        return user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value;
    }
}