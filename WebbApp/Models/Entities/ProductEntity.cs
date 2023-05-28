using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbapp.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string? ProductName { get; set; }
    public string? Ingress { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();
}




