namespace Patterns.Factory;

public interface IProduct
{
    void Operation();
}

public class ConcreteProductA : IProduct
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductA.Operation()");
    }
}

public class ConcreteProductB : IProduct
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductB.Operation()");
    }
}

public class Factory
{
    public IProduct FactoryMethod(bool condition)
    {
        return condition ? new ConcreteProductA() : new ConcreteProductB();
    }
}

public class Program
{
    public static void Main()
    {
        var factory = new Factory();
        
        var productA = factory.FactoryMethod(true);
        var productB = factory.FactoryMethod(false);
        
        productA.Operation();
        productB.Operation();
    }
}
