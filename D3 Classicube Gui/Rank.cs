namespace D3_Classicube_Gui {
    class Rank {
        public string Number;
        public string Name;
        public string Prefix;
        public string Suffix;
        public string Onclient;

        public Rank(string rank, string name, string prefix, string suffix, string onClient = "0") {
            Number = rank;
            Name = name;
            Prefix = prefix;
            Suffix = suffix;
            Onclient = onClient;
        }
    }
}
