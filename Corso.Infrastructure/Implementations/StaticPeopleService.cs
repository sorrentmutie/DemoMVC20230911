using Corso.Core;
using Corso.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Corso.Infrastructure.Implementations;

public class StaticGenericService<T, U> : IData<T, U> where T: IEntity<U>
{

    private static List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Delete(U id)
    {
        if( Get(id) is T item)
        {
            items.Remove(item);
        }
    }

    public IEnumerable<T> Get()
    {
        return items;
    }

    public T? Get(U? id)
    {
         return items.FirstOrDefault(
             x => x.Id?.Equals(id) ?? false);
    }

    public void Update(T item)
    {
        var x = Get(item.Id);
        if (x is not null)
        {
           items.Remove(x);
           items.Add(item);
        }
    }
}

public class StaticPeopleService : IPersonData
{
    public StaticPeopleService(IMemoryCache memoryCache)
    {
        this.memoryCache = memoryCache;
    }

    private static List<Person> people =
         new()
         {
            new Person { Id = Guid.NewGuid(), FirstName = "Mario", LastName = "Rossi" },
            new Person { Id = Guid.NewGuid(), FirstName = "Luigi", LastName = "Verdi" },
            new Person { Id = Guid.NewGuid(), FirstName = "Giovanni", LastName = "Bianchi" }
        };
    private readonly IMemoryCache memoryCache;

    public void AddPerson(Person person)
    {
        people.Add(person);
      //  person.Id = people.Max(x =>x.Id) + 1;

        memoryCache.Set("lastPersonAdded", person);
       // memoryCahce.Set($"{person.FirstName}-{person.LastName}", person)
    }

    public IEnumerable<Person> GetPeople()
    {
        return people;
    }

    public Person GetPerson(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdatePerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void DeletePerson(int id)
    {
        throw new NotImplementedException();
    }
}
