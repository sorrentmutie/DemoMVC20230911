using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Core.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Body { get; set; } = null!;
        public bool Reccomend { get; set; }
    }
}
