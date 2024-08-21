using System.Diagnostics.CodeAnalysis;

namespace ExpressionTrees;

public class Basics
{
    internal Action<int>? updateCapturedLocalVariable;
    internal Predicate<int> isEqualToCapturedLocalVariable;
    
    public void AllTypes()
    {
        Action<bool> action = Console.WriteLine;
        
        Func<int, bool> predicateFunc = num => num < 5;
        
        Predicate<int> predicate = num => num < 5;
    
        Expression<Func<int, bool>> expressionPredicate = num => num < 5;
    
        Expression<Func<int, bool>> predicateAsExpression = num => predicate(num);

        LambdaExpression inferredLambdaExpression = (int num) => num < 5; //   Func<int, bool>
        
        Expression inferredExpression = (int num) => num < 5; //   Func<int, bool>
        
        var inferredType = (int num) => num < 5; //   Func<int, bool>

        var specificReturnType = bool (int num) => num < 5;

        var objectReturnType = object (int num) => num < 5 ? "String" : 1L;
        
        PredicateDelegate predicateDelegate = num => num < 5;
        
        var increment = [return: NotNullIfNotNull(nameof(s))] (int? s) => s.HasValue ? s++ : null;
    }

    public void ParamsWithinLambdaExpressions(params int[] nums)
    {
        var sum = (params int[] numbers) => numbers.Sum();
        
        var result = sum(nums);
        
        Console.WriteLine($"Sum result: {result}");
    }

    public async Task AsyncLambdaExpression()
    {
        AsyncDelegate asyncDelegate = async someStuff =>
        {
            Console.WriteLine("This is before waiting one second.");
            await Task.Delay(1000);
            Console.WriteLine(someStuff);
        };

        await asyncDelegate("Hi there, im printing some stuff after waiting one second.");
    }

    public void GenericDelegates()
    {
        GenericDelegate<int, bool> genericDelegate = num => num < 5;
    }

    public void PreventVariableCapture(int num)
    {
        Func<int, bool> staticLambda = static num => num < 5;

        var result = staticLambda(num);
        
        Console.WriteLine($"Input number of {num} is bigger than 5: {result}");
    }

    public void VariableCapture(int input)
    {
        var i = 0;

        updateCapturedLocalVariable = x =>
        {
            i = x;
            var result = i > input;
            Console.WriteLine($"{i} is greater than {input}: {result}");
        };

        isEqualToCapturedLocalVariable = x => x == i;

        Console.WriteLine($"Local variable before lambda invocation: {i}");
        updateCapturedLocalVariable(10);
        Console.WriteLine($"Local variable after lambda invocation: {i}");
    }

    private delegate bool PredicateDelegate(int num);
    
    private delegate Task AsyncDelegate(string someStuff);
    
    private delegate TResult GenericDelegate<in TInput, out TResult>(TInput input);
}
