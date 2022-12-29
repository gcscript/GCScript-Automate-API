using System.Text.Json.Serialization;

namespace GCScript_Automate_API.Models;

public class SubtypeModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime Registered { get; set; } = DateTime.UtcNow;
    public Guid TypeId { get; set; }

    // RELATIONSHIPS
    [JsonIgnore] public TypeModel Type { get; set; }
}
