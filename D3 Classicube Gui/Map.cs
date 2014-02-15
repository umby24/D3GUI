using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace D3_Classicube_Gui {
    class Map {
        public int mapID;
        public string mapName;
        public string mapDirectory;
        public string delete;
        public string reload;
        public Image preview;
        // -- Once a map is loaded..
        public string mapVersion;
        public string uniqueID;
        public string rankBuild;
        public string rankJoin;
        public string rankShow;
        public string physics;
        public string motd;
        public string saveInt;
        public string Overview;
        public string size_x;
        public string size_y;
        public string size_z;
        public string spawnx;
        public string spawny;
        public string spawnz;
        public string spawnrot;
        public string spawnlook;
            
        public Map(int mid, string mname, string mdir, string del, string rel) {
            mapID = mid;
            mapName = mname;
            mapDirectory = mdir;
            delete = del;
            reload = rel;
        }
    }
}
