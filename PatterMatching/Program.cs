// See https://aka.ms/new-console-template for more information
using PatterMatching;
using System.Numerics;

Console.WriteLine("Hello, World!");

int? value = null;

if(value is int x)
{
    Console.WriteLine(x);
} else
{
    Console.WriteLine("value non ha un valore associato");
}

//string prova = null;
string prova = "Questa stringa non è nulla";   
if(prova is not null)
{
    Console.WriteLine(prova);
}


var numeri = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var medio = PuntoMedio(numeri);
Console.WriteLine(medio);

Console.WriteLine(PerformCommand(Command.Left));
Console.WriteLine(PerformCommand2("Left"));


Console.WriteLine(WaterState(123));

double[] numbers = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };




T AddAll<T>(T[] values) where T: INumber<T>
{
    T result = T.Zero;
    foreach(T value in values)
    {
        result += value;
    }
    return result;
}


T PuntoMedio<T>(IEnumerable<T> dati)
{
    if(dati is IList<T> lista)
    {
        return lista[lista.Count / 2];
    }
    else if (dati is null)
    {
        throw new Exception("dati non può essere null");            
    }
    else
    {
        int lunghezzaMeta = dati.Count() / 2;
        if(lunghezzaMeta < 0) lunghezzaMeta = 0;
        return dati.Skip(lunghezzaMeta).First();
    }
}

int PerformCommand(Command command)
    => command switch
    {
        Command.Up => 1,
        Command.Down => 2,
        Command.Left => 3,
        Command.Right => 4,
        _ => throw new ArgumentException("Comando non valido", nameof(command))
    };

int PerformCommand2(ReadOnlySpan<char> command)
    => command switch
    {
        "Up" => 1,
        "Down" => 2,
        "Left" => 3,
        "Right" => 4,
        _ => throw new ArgumentException("Comando non valido", nameof(command))
    };


string WaterState(int temperature) => temperature switch
{
    < 0 => "Solido",
    > 0 and < 100 => "Liquido",
    > 100 => "Gassoso",
    0 => "Solido/Liquido",
    100 => "Liquido / gas"
};



List<string[]> GetOrders()
{
    var orders = new List<string[]>();
    return orders;
}

decimal ReadOrders()
{
    var orders = GetOrders();
    var total = 0.0m;

    foreach(string[] order in orders)
    {
        total += order switch
        {

        };
    }
    return total;
}

decimal CalculateDiscount(Order order) => order switch
{
    { Items: > 10 } => order.Total * 0.1m,
    { Items: > 5 } => order.Total * 0.05m,
    { Total: > 500.0m } => order.Total * 0.2m,
    null => throw new ArgumentNullException(nameof(order)),
    _ => 0m
};


internal class MyOrder
{
    string[]? items { get; set;}
}




public record Order(int Items, decimal Total);
