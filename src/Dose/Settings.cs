/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Settings.cs
 * UPDATED: 7-1-2021-6:56 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dose
{
    public class Settings
    {
        public static Dictionary<string, string> GetSettings()
        {
            var settings = new Dictionary<string, string>();

            if(File.Exists(@"C:/MAWS/Dose.settings"))
            {
                var settingsFileStream = new System.IO.StreamReader(@"C:/MAWS/Dose.settings");

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
