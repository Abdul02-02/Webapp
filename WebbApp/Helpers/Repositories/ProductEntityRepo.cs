using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Webbapp.Contexts;
using Webbapp.Models.Entities;

namespace Webbapp.Helpers.Repositories;

public class ProductEntityRepo : Repository<ProductEntity>
{
    private readonly IdentityContext _context;
    public ProductEntityRepo(IdentityContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var items = await _context.Products
            .Include(x => x.Categories)
            .ThenInclude(x => x.Category)
            .ToListAsync();
        return items;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        var items = await _context.Products
        .Include(x => x.Categories)
        .ThenInclude(x => x.Category)
        .Where(expression)
        .ToListAsync();
        return items;

    }

    public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        var item = await _context.Products
            .Include(x => x.Categories)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(expression);
        return item!;
    }
}

