using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Black_Pearl
{
    public class PrefetchQuery
    {
        public List<PrefetchEntry> response { get; set; }
    }

    public class PrefetchEntry
    {
        public string Title { get; set; }
        public string URI { get; set; }
    }
}
