/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.Settings.cs
 * UPDATED: 7-8-2021-9:48 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public class AppSettings
    {
        /// <summary>
        /// Gets the settings information from Dose.settings.
        /// </summary>
        /// <returns>The MAWS settings dictionary.</returns>
        public static Dictionary<string, string> LoadFromKeyValuePairFile(string settingsFilePath)
        {
            var settings = new Dictionary<string, string>();

            if(File.Exists(settingsFilePath))
            {
                var    settingsFileStream = new StreamReader(settingsFilePath);
                var    settingsAsList     = new List<string>();
                string settingLine;

                using(settingsFileStream)
                {
                    while((settingLine = settingsFileStream.ReadLine()) != null)
                    {
                        settingsAsList.Add(settingLine.Trim());
                    }
                }

                string[] keyValuePair;

                foreach(var item in settingsAsList)
                {
                    if(!item.StartsWith("#"))
                    {
                        keyValuePair = item.Split('=');
                        settings.Add(keyValuePair[0], keyValuePair[1]);
                    }
                }
            }

            //TODO Should have a error message here/log.

            return settings;
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 */