namespace Patterns.Decorator;

public interface IComponent
{
    string Operation();
}

public class ConcreteComponent : IComponent
{
    public string Operation()
    {
        return "Basic behaviour";
    }
}

public class ComponentDecorator(IComponent component) : IComponent
{
    public virtual string Operation()
    {
        AdditionalBehavior();
        return component.Operation();
    }
    
    private void AdditionalBehavior()
    {
        Console.WriteLine("Additional behavior");
    }
}

public interface IMultiFunctionComponent 
{
    string Operation1();
    string Operation2();
    string Operation3();
    string Operation4();
    string Operation5();
}

public class ConcreteMultiFunctionComponent : IMultiFunctionComponent
{
    public string Operation1()
    {
        return "Basic behaviour";
    }

    public string Operation2()
    {
        return "Basic behaviour 2";
    }

    public string Operation3()
    {
        return "Basic behaviour 3";
    }

    public string Operation4()
    {
        return "Basic behaviour 4";
    }

    public string Operation5()
    {
        return "Basic behaviour 5";
    }
}

public class MultiFunctionComponentDecorator(IMultiFunctionComponent multiFunctionComponent) : IMultiFunctionComponent
{
    public string Operation1()
    {
        AdditionalBehavior();
        return multiFunctionComponent.Operation1();
    }

    public string Operation2()
    {
        AdditionalBehavior2();
        return multiFunctionComponent.Operation2();
    }

    public string Operation3()
    {
        return multiFunctionComponent.Operation3();
    }

    public string Operation4()
    {
        return multiFunctionComponent.Operation4();
    }

    public string Operation5()
    {
        return multiFunctionComponent.Operation5();
    }
    
    private void AdditionalBehavior()
    {
        Console.WriteLine("Additional behavior");
    }
    
    private void AdditionalBehavior2()
    {
        Console.WriteLine("Additional behavior");
    }
}

public class Program
{
    public static void Main()
    {
        var component = new ConcreteComponent();

        component.Operation();

        var decorator = new ComponentDecorator(component);

        decorator.Operation();

        var multiFunctionComponent = new ConcreteMultiFunctionComponent();

        multiFunctionComponent.Operation1();
        multiFunctionComponent.Operation2();
        multiFunctionComponent.Operation5();

        var multiFunctionComponentDecorator = new MultiFunctionComponentDecorator(multiFunctionComponent);

        multiFunctionComponentDecorator.Operation1();
        multiFunctionComponentDecorator.Operation2();
        multiFunctionComponentDecorator.Operation5();
    }
}