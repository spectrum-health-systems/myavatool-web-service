using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InptAdmitDate
{
    public class Settings
    {
        public static Dictionary<string, string> GetSettings()
        {
            var settings = new Dictionary<string, string>();

            if(File.Exists(@"C:/MAWS/InptAdmitDate.settings"))
            {
                var settingsFileStream = new System.IO.StreamReader(@"C:/MAWS/InptAdmitDate.settings");

                var settingsAsList = new List<string>();
                var line = "";

                using(settingsFileStream)
                {
                    while((line = settingsFileStream.ReadLine()) != null)
                    {
                        settingsAsList.Add(line.Trim());
                    }
                }

                var keyValuePair  = new string[2];

                foreach(var item in settingsAsList)
                {
                    if(!item.StartsWith("#"))
                    {
                        keyValuePair = item.Split('=');
                        settings.Add(keyValuePair[0], keyValuePair[1]);
                    }
                }
            }

            return settings;
        }
    }
}
