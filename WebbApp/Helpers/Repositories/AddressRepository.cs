using Webbapp.Contexts;
using Webbapp.Models.Entities;

namespace Webbapp.Helpers.Repositories;

public class AddressRepository : Repository<AddressEntity>
{
    public AddressRepository(IdentityContext context) : base(context)
    {
    }
}
