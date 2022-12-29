using System.Data;
using System.Text.Json.Serialization;

namespace GCScript_Automate_API.Models;

public class CategoryModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime Registered { get; set; } = DateTime.UtcNow;

    // RELATIONSHIPS
    [JsonIgnore] public ICollection<TypeModel> Types { get; set; }
}
