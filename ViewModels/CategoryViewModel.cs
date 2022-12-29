namespace GCScript_Automate_API.ViewModels;

public class CategoryPostViewModel
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class CategoryPutViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; }
    public string Name { get; set; }
}
