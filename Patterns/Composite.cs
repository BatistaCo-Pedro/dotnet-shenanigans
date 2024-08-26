namespace Patterns.Composite;

public interface IComponent
{
    public string Operation();
    
    public void Add(IComponent component);
    
    public void Remove(IComponent component);

    public bool IsComposite() => true;
}

public class Leaf : IComponent
{
    public string Operation() => "Leaf";
    
    public void Add(IComponent component) => throw new NotSupportedException("Lead components can't have children");

    public void Remove(IComponent component) => throw new NotSupportedException("Lead components can't have children");

    public bool IsComposite() => false;
}

public class Composite : IComponent
{
    protected readonly List<IComponent> Children = [];
    
    public void Add(IComponent component) => Children.Add(component);

    public void Remove(IComponent component) => Children.Remove(component);

    public string Operation()
    {
        var result = new StringBuilder("Branch(");
        foreach (var child in Children.
                     Select((x, i) => (Value: x, Index: i)))
        {
            result.Append(child.Value.Operation());
            if (child.Index < Children.Count - 1)
            {
                result.Append('+');
            }
        }
        return result.Append(')').ToString();
    }
}

public class CompositeClient
{
    public void ClientCode(IComponent component)
    {
        Console.WriteLine($"RESULT: {component.Operation()}\n");
    }
    
    public void ClientCode2(IComponent component1, IComponent component2)
    {
        if (component1.IsComposite())
        {
            component1.Add(component2);
        }
            
        Console.WriteLine($"RESULT: {component1.Operation()}");
    }
}

public class Program
{
    public static void Main()
    {
        var client = new CompositeClient();
        
        var leaf = new Leaf();
        Console.WriteLine("Client: I get a simple component:");
        client.ClientCode(leaf);
        
        var tree = new Composite();
        var branch1 = new Composite();
        branch1.Add(new Leaf());
        branch1.Add(new Leaf());
        branch1.Add(new Leaf());
        var branch2 = new Composite();
        branch2.Add(new Leaf());
        branch2.Add(new Leaf());
        var branch3 = new Composite();
        branch3.Add(new Leaf());
        tree.Add(branch1);
        tree.Add(branch2);
        tree.Add(branch3);
        Console.WriteLine("Client: Now I've got a composite tree:");
        client.ClientCode(tree);

        Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
        client.ClientCode2(tree, leaf);
    }
}