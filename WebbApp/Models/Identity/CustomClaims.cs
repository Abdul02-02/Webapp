using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Webbapp.Models.Identity;

public class CustomClaims : UserClaimsPrincipalFactory<AppUser>
{
    private readonly UserManager<AppUser> userManager;
    public CustomClaims(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
        this.userManager = userManager;
    }
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(user);

        claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));

        return claimsIdentity;

    }
}
