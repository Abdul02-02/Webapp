using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webbapp.Models.Entities;
using Webbapp.Models.Identity;

namespace Webbapp.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{


    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<ContactFormEntity> ContactForms { get; set; }
    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }

}
