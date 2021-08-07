
using System.IO;
using System.Runtime.Serialization;

namespace Recognizer
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public string InputLanguageName { get; set; }

        [DataMember]
        public string OutputLanguageName { get; set; }

        [DataMember]
        public string InputLanguage { get; set; }

        [DataMember]
        public string OutputLanguage { get; set; }

        public void Save()
        {
            var json = new DataContractSerializer(typeof(Settings));

            using (var file = new FileStream("settings.json", FileMode.OpenOrCreate))
            {
                json.WriteObject(file, this); 
            }
        }
        
        public Settings Load()
        {
            Settings settings;

            var json = new DataContractSerializer(typeof(Settings));

            using (var file = new FileStream("settings.json", FileMode.OpenOrCreate))
            {
               settings = json.ReadObject(file) as Settings;
            }
            return settings;
        }
    }
}
