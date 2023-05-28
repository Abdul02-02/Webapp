using Webbapp.Models.Entities;

namespace Webbapp.ViewModels;

public class ColletionViewModel
{
    public string? Title { get; set; }
    public IEnumerable<ProductEntity> Items { get; set; } = new List<ProductEntity>();
}
