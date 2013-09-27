using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3_Classicube_Gui {
    class Command {
        public string internalName;
        public string Name;
        public string rank;
        public string rankShow;
        public string plugin;
        public string group;
        public string description;

        public Command(string iN, string n, string r, string rs, string p, string g, string d) {
            internalName = iN;
            Name = n;
            rank = r;
            rankShow = rs;
            plugin = p;
            group = g;
            description = d;
        }
    }
}
