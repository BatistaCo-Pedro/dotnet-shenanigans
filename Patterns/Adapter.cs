namespace Patterns.Adapter;

public interface ITarget
{
    string GetRequest();
}

public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request";
    }
}

public class Adapter(Adaptee adaptee) : ITarget
{
    public string GetRequest() => adaptee.GetSpecificRequest();
}

public class Program
{
    public static void Main()
    {
        var adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        Console.WriteLine("Adaptee interface is incompatible with the client.");
        Console.WriteLine("But with adapter client can call it's method.");

        Console.WriteLine(target.GetRequest());
    }
}