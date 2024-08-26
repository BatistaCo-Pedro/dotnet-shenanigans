using System.Collections;

namespace Patterns.CodeExamples.Iterator;

public abstract class Iterator : IEnumerator
{
    public abstract int Key();

    public abstract bool MoveNext();

    public abstract void Reset();
    
    public abstract object Current();

    object IEnumerator.Current => Current(); 
}

abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}

class AlphabeticalOrderIterator : Iterator
{
    private WordsCollection _collection;
    
    private int _position = -1;
        
    private bool _reverse;

    public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
    {
        _collection = collection;
        _reverse = reverse;

        if (reverse)
        {
            _position = collection.GetItems().Count;
        }
    }
        
    public override object Current()
    {
        return _collection.GetItems()[_position];
    }

    public override int Key()
    {
        return _position;
    }
        
    public override bool MoveNext()
    {
        var updatedPosition = _position + (_reverse ? -1 : 1);

        if (updatedPosition >= 0 && updatedPosition < _collection.GetItems().Count)
        {
            _position = updatedPosition;
            return true;
        }

        return false;
    }
        
    public override void Reset()
    {
        _position = _reverse ? _collection.GetItems().Count - 1 : 0;
    }
}

class WordsCollection : IteratorAggregate
{
    List<string> _collection = new();

    private bool _direction;
        
    public void ReverseDirection()
    {
        _direction = !_direction;
    }
        
    public List<string> GetItems()
    {
        return _collection;
    }
        
    public void AddItem(string item)
    {
        _collection.Add(item);
    }
        
    public override IEnumerator GetEnumerator()
    {
        return new AlphabeticalOrderIterator(this, _direction);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var collection = new WordsCollection();
        collection.AddItem("First");
        collection.AddItem("Second");
        collection.AddItem("Third");

        Console.WriteLine("Straight traversal:");

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("\nReverse traversal:");

        collection.ReverseDirection();

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
    }
}