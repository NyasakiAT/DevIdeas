using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIdeas.Objects
{
    public class ProjectEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Reputation { get; set; }
        public List<string> Tags { get; set; }
    }
}
