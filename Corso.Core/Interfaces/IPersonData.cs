namespace Corso.Core.Interfaces;

public interface IEntity<T>
{
    T? Id { get; set; }
}

public interface IPersonData
{
    IEnumerable<Person> GetPeople();
    void AddPerson(Person person);
    Person GetPerson(int id);
    void UpdatePerson(Person person);
    void DeletePerson(int id);
}


public interface IData<T, U>
{
    IEnumerable<T> Get();
    void Add(T item);
    T? Get(U id);
    void Update(T item);
    void Delete(U id);
}
