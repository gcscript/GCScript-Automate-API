namespace GCScript_Automate_API.ViewModels;

public class SubtypePostViewModel
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string TypeCode { get; set; }
}

public class SubtypePutViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; }
    public string Name { get; set; }
    public string TypeCode { get; set; }
}
