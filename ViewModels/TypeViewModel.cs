namespace GCScript_Automate_API.ViewModels;

public class TypePostViewModel
{
    public string Code { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}

public class TypePutViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}
