/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Settings.cs
 * UPDATED: 6-30-2021-9:43 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.IO;

namespace MyAvatoolWebService
{
    public class Settings
    {
        //public Dictionary<string, string> MawsSetting;

        public static Dictionary<string, string> GetSettings()
        {
            var settings = new Dictionary<string, string>();

            if(File.Exists(@"C:/MAWS/maws.settings"))
            {
                var settingsFileStream = new System.IO.StreamReader(@"C:/MAWS/maws.settings");

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