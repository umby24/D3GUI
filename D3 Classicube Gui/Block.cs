using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3_Classicube_Gui {
    class Block {
        public string internalID;
        public string blockName;
        public string clientID;
        public string physic;
        public string physicPlugin;
        public string doTime;
        public string doTimeRandom;
        public string doRepeat;
        public string dobyLoad;
        public string createPlugin;
        public string delPlugin;
        public string rankPlace;
        public string rankDelete;
        public string afterDelete;
        public string killer;
        public string special;
        public string overviewColor;
        public string RBL;
        public string CPE_Replace;
        public string CPE_Level;

        public Block(string IID, string bname, string cid, string physics, string pPlug, string dtime, string dtrand, string drep, string dload, string cplug, string dplug, string rplace, string rdel, string adel, string kill, string spec, string overview) {
            internalID = IID;
            blockName = bname;
            clientID = cid;
            physic = physics;
            physicPlugin = pPlug;
            doTime = dtime;
            doTimeRandom = dtrand;
            doRepeat = drep;
            dobyLoad = dload;
            createPlugin = cplug;
            delPlugin = dplug;
            rankPlace = rplace;
            rankDelete = rdel;
            afterDelete = adel;
            killer = kill;
            special = spec;
            overviewColor = overview;
        }
    }
}
