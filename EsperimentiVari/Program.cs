// See https://aka.ms/new-console-template for more information
using EsperimentiVari;
using System.Text;

//Console.WriteLine("Hello, World!");
//int? value = null;
//string? s = null;
//MyClass? myClass = null;

//myClass = new MyClass { Name = "Luigi" };


//value = 10;
//var a = value + 1;
//s = "Ciao";
//var b = s + " Salvatore";

//myClass!.Name = "Mario";
//myClass!.Description += "Ciao ";
//Console.WriteLine($"{myClass.Name} {myClass.Description}");
//if (myClass != null
//{
//    myClass.Name = "Salvatore";
//}   


var salvatore = new Person("Salvatore", new DateTime(1970, 1, 1));
var salvatore2 = salvatore with { FirstName = "Mario Rossi" };
var salvatore3 = new Person("Salvatore", new DateTime(1970, 1, 1));
Console.WriteLine("Confronto di uguaglianza tra record");
Console.WriteLine(salvatore == salvatore3);
Console.WriteLine(salvatore == salvatore2);

var (nome, data) = salvatore;






var person = new PersonAsClass("Mario Rossi", new DateTime(1970, 1, 1));
var person2 = new PersonAsClass("Mario Rossi", new DateTime(1970, 1, 1));
Console.WriteLine("Confronto di uguaglianza trra istanze di classe");
Console.WriteLine(person == person2);


var x = new Person("Luigi Bianchi", new DateTime(1970, 1, 1));
Console.WriteLine(x);


public abstract record AbstractPerson(string FirstName, DateTime birthDate)
{
   protected virtual bool PrintMembers(StringBuilder sb) {
        sb.Append($"Ciao, Ciao {FirstName}");
        return true;
    }
};

public record Person(string FirstName, DateTime birthDate)
    : AbstractPerson(FirstName, birthDate)
{
    protected override bool PrintMembers(StringBuilder sb) {
        sb.Append($"Ciao, {FirstName}");
        return true;
    }
};

public record PersonExtended
{


    public required string FirstName { get; init; }
    public required DateTime birthDate { get; init; }

}




public record struct Point(int X, int Y);

public class PersonAsClass
{
    public string FirstName { get; init; }
    public DateTime BirthDate { get; init; }

    public PersonAsClass(string firstName, DateTime birthDate)
    {
        FirstName = firstName;
        BirthDate = birthDate;
    }
}

  
