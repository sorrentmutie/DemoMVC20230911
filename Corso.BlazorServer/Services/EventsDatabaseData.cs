using Corso.Core.Entities.Events;

namespace Corso.BlazorServer.Services;

public class EventsDatabaseData : IEventsData
{
    public IEnumerable<EventListElement> GetEvents()
    {
        return new List<EventListElement>
        {
            new EventListElement
            { Id = 1, Description = "Event 3", Date = DateTime.Now, Location = "Remota" },
                 new EventListElement
                 { Id = 2, Description = "Event 4", Date = DateTime.Now.AddDays(7), Location = "Roma" }
                     };
    }
}
