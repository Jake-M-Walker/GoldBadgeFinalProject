using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Badge_POCO
{
    public class Badge
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> Doors { get; set; }

        public Badge() { }

        public Badge(string name, List<string> doorNames)
        {
            Name = name;
            Doors = doorNames;
        }

        public Badge(int id, string name, List<string> doorNames)
        {
            ID = id;
            Name = name;
            Doors = doorNames;
        }

    }
}
