namespace Patterns;

public interface IComponent
{
    string Operation();
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