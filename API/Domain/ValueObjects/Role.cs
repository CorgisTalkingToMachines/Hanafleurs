namespace API.Domain.ValueObjects;

public class Role
{
    string Value { get; }
    
    private Role(string value)
    {
        Value = value;
    }
    
    public static readonly Role Customer = new("Customer");
    public static readonly Role Florist = new("Florist");
    public static readonly Role Manager = new("Manager");
}