using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Xml.Linq;

namespace HackersNewApi.Domian.Entities
{
    public class HackersNewsItem
    {
        public Int64 id { get; set; }
        public bool deleted { get; set; }
        public string type { get; set; }
        public string by { get; set; }
        public Int32 time { get; set; }
        public string text { get; set; }
        public bool dead { get; set; }
        public Int64 parent { get; set; }
        public Int64 poll { get; set; }
        public IEnumerable<Int64> kids { get; set; }
        public string url { get; set; }
        public Int16 score { get; set; }
        public string title { get; set; }
        public IEnumerable<Int32> parts { get; set; }
        public Int16 descendants { get; set; }
    }
}
