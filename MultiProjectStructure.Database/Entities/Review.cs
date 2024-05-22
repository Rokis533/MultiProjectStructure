using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiProjectStructure.Database.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Reviewer { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
