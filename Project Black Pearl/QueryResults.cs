using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Black_Pearl
{
    public class ResultObj
    {
        public string Title { get; set; }
        public List<string> URL1 { get; set; }
        public List<string> URL2 { get; set; }
        public List<string> URL3 { get; set; }
        public List<string> URL4 { get; set; }
    }

    public class QueryResults
    {
        public List<ResultObj> response { get; set; }
    }

    public class TempResults
    {
        public string Title { get; set; }
        public List<string> URL1 { get; set; }
        public List<string> URL2 { get; set; }
        public List<string> URL3 { get; set; }
        public List<string> URL4 { get; set; }
    }

    public class PrefetchQueryResults
    {
        public List<TempResults> response { get; set; }
    }
}
