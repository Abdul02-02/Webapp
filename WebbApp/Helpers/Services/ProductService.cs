using Webbapp.Helpers.Repositories;
using Webbapp.Models.Entities;

namespace Webbapp.Helpers.Services;

public class ProductService
{

    private readonly ProductEntityRepo _productsRepository;

    public ProductService(ProductEntityRepo productsRepository)
    {
        _productsRepository = productsRepository;
    }



    public async Task CreateAsync(ProductEntity productEntity)
    {
        await _productsRepository.AddAsync(productEntity);
    }

    public async Task<IEnumerable<ProductEntity>> GetAllByCategoryNameAsync(string CategoryName)
    {
        var items = await _productsRepository.GetAllAsync();
        var list = new List<ProductEntity>();
        foreach (var item in items)
        {
            var Categorylist = new List<string>();

            foreach (var Category in item.Categories)
                Categorylist.Add(Category.Category.CategoryName);

            list.Add(new ProductEntity
            {
                ArticleNumber = item.ArticleNumber,
                Description = item.Description,
                Ingress = item.Ingress,
                Categories = item.Categories,
                Price = item.Price,
                ProductName = item.ProductName,
            });

        }
        return list;
    }
    public async Task<ProductEntity> GetAsync(string ArticleNumber)
    {
        var item = await _productsRepository.GetAsync(x => x.ArticleNumber == ArticleNumber);

        var Categorylist = new List<string>();

        foreach (var Category in item.Categories)
            Categorylist.Add(Category.Category.CategoryName);

        var ProductEntity = new ProductEntity
        {
            ArticleNumber = item.ArticleNumber,
            Description = item.Description,
            Ingress = item.Ingress,
            Categories = item.Categories,
            Price = item.Price,
            ProductName = item.ProductName,
        };
        return ProductEntity;
    }
}
