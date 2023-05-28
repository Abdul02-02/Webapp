using Webbapp.Contexts;
using Webbapp.Models.Entities;

namespace Webbapp.Helpers.Repositories;

public class UserAddressRepository : Repository<UserAddressEntity>
{
    public UserAddressRepository(IdentityContext context) : base(context)
    {
    }
}
