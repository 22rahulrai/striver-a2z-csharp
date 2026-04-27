using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();

if (args.Length == 0)
{
    var runnableTypes = assembly
        .GetTypes()
        .Where(t => t.IsClass && t.GetMethod("Test", BindingFlags.Public | BindingFlags.Static) != null)
        .OrderBy(t => t.Name)
        .ToList();

    if (runnableTypes.Count == 0)
    {
        Console.WriteLine("No problem classes with a Test() method found.");
        return;
    }

    Console.WriteLine($"Found {runnableTypes.Count} problem(s):\n");
    foreach (var t in runnableTypes)
        Console.WriteLine($"  {t.Name}");

    Console.WriteLine("\nUsage: dotnet run <ClassName>");
    return;
}

string className = args[0];

var type = assembly
    .GetTypes()
    .FirstOrDefault(t => t.IsClass && t.Name.Equals(className, StringComparison.OrdinalIgnoreCase));

if (type is null)
{
    Console.WriteLine($"Error: No class named '{className}' found.");
    Console.WriteLine("Run without arguments to list all available problems.");
    Environment.Exit(1);
    return;
}

var testMethod = type.GetMethod("Test", BindingFlags.Public | BindingFlags.Static);

if (testMethod is null)
{
    Console.WriteLine($"Error: '{className}' has no public static Test() method.");
    Console.WriteLine("Add:  public static void Test() { /* test cases */ }");
    Environment.Exit(1);
    return;
}

Console.WriteLine($"Running: {type.Name}\n");
testMethod.Invoke(null, null);
