namespace Patterns;

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
