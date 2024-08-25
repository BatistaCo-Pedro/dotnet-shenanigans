using System.Reflection;

namespace Reflection;

public class Basics
{
    public void GetAssemblies()
    {
        var callingAssembly = Assembly.GetCallingAssembly();

        var executingAssembly = Assembly.GetExecutingAssembly();

        var entryAssembly = Assembly.GetEntryAssembly();

        var assemblyContainingMathClass = Assembly.GetAssembly(typeof(Math));
        var assemblyContainingMathClassViaType = typeof(Math).Assembly;

    }
    
    public void GetProperties()
    {
        var allProperties = typeof(Math).GetProperties();
        
        var specificProperty = typeof(Math).GetProperty(nameof(Math.PI));

        var propertiesFromFilter = typeof(Math).GetProperties().Where(x => x.Name.Contains('a'));
        
        var staticProperties = typeof(Math).GetProperties(BindingFlags.Static);
        
        var instanceProperties = typeof(Math).GetProperties(BindingFlags.Instance);
        
        var publicProperties = typeof(Math).GetProperties(BindingFlags.Public);
        
        var privateProperties = typeof(Math).GetProperties(BindingFlags.NonPublic);
        
        var propertiesWithSpecificAttribute = typeof(Math).GetProperties().Where(x => x.GetCustomAttribute<ObsoleteAttribute>() != null);
    }
    
    public void GetMethods()
    {
        var allMethods = typeof(Math).GetMethods();
        
        var specificMethod = typeof(Math).GetMethod(nameof(Math.Abs));
        
        var methodsFromFilter = typeof(Math).GetMethods().Where(x => x.Name.Contains('a'));
        
        var staticMethods = typeof(Math).GetMethods(BindingFlags.Static);
        
        var instanceMethods = typeof(Math).GetMethods(BindingFlags.Instance);
    }
}