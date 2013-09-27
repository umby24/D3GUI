using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3_Classicube_Gui {
    class Rank {
        public string number;
        public string name;
        public string prefix;
        public string onclient;

        public Rank(string rank, string Name, string Prefix, string onClient = "0") {
            number = rank;
            name = Name;
            prefix = Prefix;
            onclient = onClient;
        }
    }
}
