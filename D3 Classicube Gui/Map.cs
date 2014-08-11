using System.Drawing;

namespace D3_Classicube_Gui {
    class Map {
        public int MapId;
        public string MapName;
        public string MapDirectory;
        public string Delete;
        public string Reload;
        public Image Preview;
        // -- Once a map is loaded..
        public string MapVersion;
        public string UniqueId;
        public string RankBuild;
        public string RankJoin;
        public string RankShow;
        public string Physics;
        public string Motd;
        public string SaveInt;
        public string Overview;
        public string SizeX;
        public string SizeY;
        public string SizeZ;
        public string Spawnx;
        public string Spawny;
        public string Spawnz;
        public string Spawnrot;
        public string Spawnlook;
            
        public Map(int mid, string mname, string mdir, string del, string rel) {
            MapId = mid;
            MapName = mname;
            MapDirectory = mdir;
            Delete = del;
            Reload = rel;
        }
    }
}
