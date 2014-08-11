using System.Collections.Generic;
using System.IO;

namespace D3_Classicube_Gui {
    class SettingsReader {
        readonly string _fileName = "";
        public Dictionary<string, string> Settings;

        public SettingsReader(string fName, bool create = false) {
            if (!File.Exists(fName) && create == false) 
                throw new FileNotFoundException("SettingsReader: Settings file not found");

            _fileName = fName;
            Settings = new Dictionary<string, string>();
        }

        public void ReadSettings() {
            var fileReader = new StreamReader(_fileName);

            do {
                var line = fileReader.ReadLine();

                if (line != null && !line.Contains("="))
                    continue;

                if (line == null) 
                    continue;

                var key = line.Substring(0, line.IndexOf(" "));
                var setting = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                Settings.Add(key, setting);
            } while (!fileReader.EndOfStream);
            // -- Settings parsed.
            fileReader.Close();
            fileReader.Dispose();
        }

        public void SaveSettings() {
            var fileWriter = new StreamWriter(_fileName);

            foreach (var pair in Settings) {
                fileWriter.Write(pair.Key + " = " + pair.Value + "\n");
            }

            fileWriter.Close();
            fileWriter.Dispose();
        }
    }
}
