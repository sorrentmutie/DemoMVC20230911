using System.Text.Json.Serialization;

namespace Corso.Core.ReqRes;


public class ReqResResponse
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public Person[] data { get; set; }
    public Support support { get; set; }
}

public class Support
{
    public string url { get; set; }
    public string text { get; set; }
}

public class Person
{
    public int id { get; set; }
    public string email { get; set; }
    //public string first_name { get; set; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    public string avatar { get; set; }
}


public class ReqResRequest
{
    public string name { get; set; }
    public string job { get; set; }
    public string id { get; set; }
    public DateTime createdAt { get; set; }
}
