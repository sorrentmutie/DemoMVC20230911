namespace Corso.Core.Entities.Events;

public interface IEventsData
{
    IEnumerable<EventListElement> GetEvents();
}
