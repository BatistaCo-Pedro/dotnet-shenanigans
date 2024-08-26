namespace Patterns.CodeExamples;

// Saves the current state inside a memento.
public interface IMemento
{
    string Name { get;  }
    
    string State { get; }
    
    DateTime Date { get; }
}

public class Originator
{
    private static readonly Random Random = new();
    
    // Serialized string -- one variable only for simplicity sake
    private string _state;

    public Originator(string state)
    {
        _state = state;
        Console.WriteLine("Originator: Initial state is: " + state);
    }
    
    public void Operation()
    {
        Console.WriteLine("Originator: I'm doing something important.");
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        _state =  new string(Enumerable.Repeat(chars, 32)
            .Select(s => s[Random.Next(s.Length)]).ToArray()); // random state for simplicity
        Console.WriteLine($"Originator: and my state has changed to: {_state}");
    }

    public IMemento Save() => new ConcreteMemento(_state);

    public void Restore(IMemento memento)
    {
        _state = memento.State;
        Console.Write($"Originator: My state has changed to: {_state}");
    }
}

public class ConcreteMemento : IMemento
{
    public ConcreteMemento(string state)
    {
        State = state;
        Date = DateTime.Now;
    }

    public string Name => $"{Date} / ({State.Substring(0, 9)})...";
    public string State { get; init; }
    public DateTime Date { get; init; }
}

class Caretaker(Originator originator)
{
    private readonly List<IMemento> _mementos = [];

    public void Backup()
    {
        Console.WriteLine("\nCaretaker: Saving Originator's state...");
        _mementos.Add(originator.Save());
    }

    public void Undo()
    {
        if (_mementos.Count == 0)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        var memento = _mementos.Last();
        _mementos.Remove(memento);

        Console.WriteLine("Caretaker: Restoring state to: " + memento.Name);

        try
        {
            originator.Restore(memento);
        }
        catch (Exception)
        {
            Undo();
        }
    }

    public void ShowHistory()
    {
        foreach (var memento in _mementos)
        {
            Console.WriteLine(memento.Name);
        }
    }
}

public class Program
{
    public static void Main()
    {
        var originator = new Originator("currentState");
        var caretaker = new Caretaker(originator);

        caretaker.Backup();
        originator.Operation();

        caretaker.Backup();
        originator.Operation();

        caretaker.Backup();
        originator.Operation();

        Console.WriteLine();
        caretaker.ShowHistory();

        Console.WriteLine("\nClient: Now, let's rollback!\n");
        caretaker.Undo();

        Console.WriteLine("\n\nClient: Once more!\n");
        caretaker.Undo();

        Console.WriteLine();
    }
}