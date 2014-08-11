namespace D3_Classicube_Gui {
    class Block {
        public string InternalId;
        public string BlockName;
        public string ClientId;
        public string Physic;
        public string PhysicPlugin;
        public string DoTime;
        public string DoTimeRandom;
        public string DoRepeat;
        public string DobyLoad;
        public string CreatePlugin;
        public string DelPlugin;
        public string RankPlace;
        public string RankDelete;
        public string AfterDelete;
        public string Killer;
        public string Special;
        public string OverviewColor;
        public string Rbl;
        public string CpeReplace;
        public string CpeLevel;

        public Block(string iid, string bname, string cid, string physics, string pPlug, string dtime, string dtrand, string drep, string dload, string cplug, string dplug, string rplace, string rdel, string adel, string kill, string spec, string overview) {
            InternalId = iid;
            BlockName = bname;
            ClientId = cid;
            Physic = physics;
            PhysicPlugin = pPlug;
            DoTime = dtime;
            DoTimeRandom = dtrand;
            DoRepeat = drep;
            DobyLoad = dload;
            CreatePlugin = cplug;
            DelPlugin = dplug;
            RankPlace = rplace;
            RankDelete = rdel;
            AfterDelete = adel;
            Killer = kill;
            Special = spec;
            OverviewColor = overview;
        }
    }
}
