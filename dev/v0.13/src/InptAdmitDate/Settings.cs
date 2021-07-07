/* PROJECT: InptAdmitDate (https://github.com/aprettycoolprogram/InptAdmitDate)
 *    FILE: InptAdmitDate.Settings.cs
 * UPDATED: 7-1-2021-8:45 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.IO;

namespace InptAdmitDate
{
    public class Settings
    {
        /// <summary>
        /// Gets the settings information from InptAdmitDate.settings.
        /// </summary>
        /// <returns>The InptAdmitDate settings dictionary.</returns>
        public static Dictionary<string, string> GetSettings()
        {
            var inptAdmitDateSettings     = new Dictionary<string, string>();
            var inptAdmitDateSettingsPath = @"C:/MAWS/InptAdmitDate.settings";

            if(File.Exists(inptAdmitDateSettingsPath))
            {
                var    settingsFileStream = new StreamReader(inptAdmitDateSettingsPath);
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
                        inptAdmitDateSettings.Add(keyValuePair[0], keyValuePair[1]);
                    }
                }
            }

            return inptAdmitDateSettings;
        }
    }
}
