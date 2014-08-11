namespace D3_Classicube_Gui {
    class Command {
        public string InternalName;
        public string Name;
        public string Rank;
        public string RankShow;
        public string Plugin;
        public string Group;
        public string Description;

        public Command(string iN, string n, string r, string rs, string p, string g, string d) {
            InternalName = iN;
            Name = n;
            Rank = r;
            RankShow = rs;
            Plugin = p;
            Group = g;
            Description = d;
        }
    }
}
