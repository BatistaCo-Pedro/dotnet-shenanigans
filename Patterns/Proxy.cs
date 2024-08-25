namespace Patterns.Proxy;

public interface ISubject
{
    void Request();
}

public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject.Request()");
    }
}

class Proxy(RealSubject realSubject) : ISubject
{
    public void Request()
    {
        if (CheckAccess())
        {
            realSubject.Request();

            LogAccess();
        }
    }
    
    public bool CheckAccess()
    {
        Console.WriteLine("Proxy: Checking access prior to firing a real request.");

        return true;
    }
    
    public void LogAccess()
    {
        Console.WriteLine("Proxy: Logging the time of request.");
    }
}

public class Client
{
    public void ClientCode(ISubject subject)
    {
        subject.Request();
    }
}

public class Program
{
    public static void Main()
    {
        var client = new Client();
        var realSubject = new RealSubject();
        var proxy = new Proxy(realSubject);
        
        Console.WriteLine("Client: Executing the client code with a real subject:");
        client.ClientCode(realSubject);
        
        Console.WriteLine();
        
        Console.WriteLine("Client: Executing the same client code with a proxy:");
        client.ClientCode(proxy);
    }
}
