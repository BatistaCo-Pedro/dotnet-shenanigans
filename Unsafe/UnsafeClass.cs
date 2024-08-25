namespace DotnetShenanigans;

public unsafe class UnsafeClass
{
    public unsafe void UnsafeMethod()
    {
        var x = 10; 
        var p = &x;
        Console.WriteLine(*p);
    }
}