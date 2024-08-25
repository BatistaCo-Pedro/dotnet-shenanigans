namespace Patterns;

public interface IProductA
{
    void Operation();
}

public interface IProductB
{
    void Operation();
}

public class ConcreteProductA1 : IProductA
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductA1.Operation()");
    }
}

public class ConcreteProductA2 : IProductA
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductA2.Operation()");
    }
}

public class ConcreteProductB1 : IProductB
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductB1.Operation()");
    }
}

public class ConcreteProductB2 : IProductB
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductB2.Operation()");
    }
}

public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public class ConcreteFactory : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}