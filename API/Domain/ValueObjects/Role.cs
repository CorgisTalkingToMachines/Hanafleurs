namespace API.Domain.ValueObjects;

public class Role
{
    public string Value { get; }
    
    private Role(string value)
    {
        Value = value;
    }
    
    public static readonly Role Customer = new("Customer");
    public static readonly Role Florist = new("Florist");
    public static readonly Role Manager = new("Manager");

    public static Role FromString(string value)
    {
        return value switch
        {
            "Customer" => Customer,
            "Florist" => Florist,
            "Manager" => Manager,
            _ => throw new ArgumentException($"Role not known : {value}")
        };
    }
}