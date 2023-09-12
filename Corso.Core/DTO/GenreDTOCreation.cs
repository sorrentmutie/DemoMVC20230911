using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Core.DTO;

public class GenreDTOCreation
{
    public string Name { get; set; } = null!;  
}

public class GenreDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
