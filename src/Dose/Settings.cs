/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Settings.cs
 * UPDATED: 7-1-2021-8:42 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.IO;

namespace Dose
{
    public class Settings
    {
        /// <summary>
        /// Gets the settings information from Dose.settings.
        /// </summary>
        /// <returns>The MAWS settings dictionary.</returns>
        public static Dictionary<string, string> GetSettings()
        {
            var doseSettings     = new Dictionary<string, string>();
            var doseSettingsPath = @"C:/MAWS/MAWS.settings";

            if(File.Exists(doseSettingsPath))
            {
                var    settingsFileStream = new StreamReader(doseSettingsPath);
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
                        doseSettings.Add(keyValuePair[0], keyValuePair[1]);
                    }
                }
            }

            return doseSettings;
        }
    }
}
