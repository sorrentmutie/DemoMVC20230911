using Corso.Core.Entities.Events;

namespace Corso.BlazorWASM.Services;

public class StaticEventsData : IEventsData
{
    public IEnumerable<EventListElement> GetEvents()
    {
        return new List<EventListElement>
        {
            new EventListElement
            { Id = 1, Description = "Event 1", Date = DateTime.Now, Location = "Remota" },
                 new EventListElement
                 { Id = 2, Description = "Event 2", Date = DateTime.Now.AddDays(7), Location = "Roma" }
                     };
    }
}
