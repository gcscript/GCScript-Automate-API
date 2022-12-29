using System.Data;
using System.Text.Json.Serialization;

namespace GCScript_Automate_API.Models;

public class TypeModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime Registered { get; set; } = DateTime.UtcNow;
    public Guid CategoryId { get; set; }

    // RELATIONSHIPS
    [JsonIgnore] public CategoryModel Category { get; set; }
    [JsonIgnore] public ICollection<SubtypeModel> Subtypes { get; set; }
}
