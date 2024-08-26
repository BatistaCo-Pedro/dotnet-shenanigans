namespace Patterns.CodeExamples.Singleton;

// Static class is always a singletong

public static class StaticSingleton
{
    private static string StaticVariable = "Hi";
    
    public static void Operation() => Console.WriteLine(nameof(Operation));
    
    public static void OperationDependingOnVariable() => 
        Console.WriteLine(nameof(OperationDependingOnVariable) + StaticVariable);
    
    public static void ChangeVariableState(string variable) => StaticVariable = variable;
}

public class Singleton
{
    private Singleton() { }

    private static Singleton? _instance;
    
    public static Singleton Instance => _instance ?? new Singleton();

    public string Value { get; private set; }
}

public class ThreadSafeSingleton
{
    private ThreadSafeSingleton() { }
    
    private static readonly object Lock = new();

    private static ThreadSafeSingleton? _instance;

    public static ThreadSafeSingleton Instance
    {
        get
        {
            // Prevent threads stumbling over the lock
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                    }
                }
            }
            
            return _instance;
        }
    }
    
    public string Value { get; private set; }
}

// It's also thread safe
public class LazySingleton
{
    private static readonly Lazy<LazySingleton> Lazy =
        new(() => new LazySingleton());

    public static LazySingleton Instance => Lazy.Value;

    private LazySingleton() { }
}

public class Program
{
    public static void Main()
    {
        StaticSingleton.Operation();
        StaticSingleton.OperationDependingOnVariable();
        StaticSingleton.ChangeVariableState("Changed from Hi");
        StaticSingleton.OperationDependingOnVariable();

        var singletonInstance = Singleton.Instance;
        var singletonInstance2 = Singleton.Instance;
        
        // reference comparison
        Console.WriteLine($"Singleton instances are equal: {singletonInstance.Equals(singletonInstance2)}");
        
        var threadSafeSingletonInstance = ThreadSafeSingleton.Instance;
        var threadSafeSingletonInstance2 = ThreadSafeSingleton.Instance;
        
        Console.WriteLine($"Singleton instances are equal: " +
                          $"{threadSafeSingletonInstance.Equals(threadSafeSingletonInstance2)}");

        var lazySingletonInstance = LazySingleton.Instance;
        var lazySingletonInstance2 = LazySingleton.Instance;
        
        Console.WriteLine($"Singleton instances are equal: " + 
                          $"{lazySingletonInstance.Equals(lazySingletonInstance2)}");
    }
}