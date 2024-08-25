namespace Patterns.State;

public abstract class State
{
    protected Context _context;

    public void SetContext(Context context)
    {
        _context = context;
    }

    public abstract void Handle1();

    public abstract void Handle2();
}

public class ConcreteStateA : State
{
    public override void Handle1()
    {
        Console.WriteLine("ConcreteStateA handles request1.");
        Console.WriteLine("ConcreteStateA wants to change the state of the context.");
        _context.TransitionTo(new ConcreteStateB());
    }

    public override void Handle2()
    {
        Console.WriteLine("ConcreteStateA handles request2.");
    }
}

public class ConcreteStateB : State
{
    public override void Handle1()
    {
        Console.Write("ConcreteStateB handles request1.");
    }

    public override void Handle2()
    {
        Console.WriteLine("ConcreteStateB handles request2.");
        Console.WriteLine("ConcreteStateB wants to change the state of the context.");
        _context.TransitionTo(new ConcreteStateA());
    }
}

public class Context
{
    private State _state;

    public Context(State state)
    {
        TransitionTo(state);
    }
    
    public void TransitionTo(State state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        _state = state;
        _state.SetContext(this);
    }
    
    public void Request1()
    {
        _state.Handle1();
    }

    public void Request2()
    {
        _state.Handle2();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // The client code.
        var context = new Context(new ConcreteStateA());
        context.Request1();
        context.Request2();
    }
}