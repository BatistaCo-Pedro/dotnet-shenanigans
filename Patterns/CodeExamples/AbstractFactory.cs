namespace Patterns.AbstractFactory;

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

public class ConcreteFactory2 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}

public class Program
{
    public static void Main()
    {
        IAbstractFactory factory = new ConcreteFactory();
        
        var productA1 = factory.CreateProductA();
        var productB1 = factory.CreateProductB();
        
        productA1.Operation();
        productB1.Operation();
        
        IAbstractFactory factory2 = new ConcreteFactory2();
        
        var productA2 = factory2.CreateProductA();
        var productB2 = factory2.CreateProductB();
        
        productA2.Operation();
        productB2.Operation();
    }
}