using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Core.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
        public List<GenreDTO> Genres { get; set; } = new List<GenreDTO>();
    }
}
