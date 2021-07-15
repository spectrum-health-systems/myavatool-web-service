/* PROJECT: NewDevelopment (https://github.com/aprettycoolprogram/NewDevelopment)
 *    FILE: NewDevelopment.Settings.cs
 * UPDATED: 7-1-2021-8:46 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.IO;

namespace NewDevelopment
{
    public class Settings
    {
        /// <summary>
        /// Gets the settings information from NewDevelopment.settings.
        /// </summary>
        /// <returns>The NewDevelopment settings dictionary.</returns>
        //public static Dictionary<string, string> GetSettings()
        //{
        //    var newDevelopmentSettings = new Dictionary<string, string>();
        //    var newDevelopmentSettingsPath = @"C:/MAWS/NewDevelopment.settings";

        //    if (File.Exists(newDevelopmentSettingsPath))
        //    {
        //        var settingsFileStream = new StreamReader(newDevelopmentSettingsPath);
        //        var settingsAsList = new List<string>();
        //        string settingLine;

        //        using (settingsFileStream)
        //        {
        //            while ((settingLine = settingsFileStream.ReadLine()) != null)
        //            {
        //                settingsAsList.Add(settingLine.Trim());
        //            }
        //        }

        //        string[] keyValuePair;

        //        foreach (var item in settingsAsList)
        //        {
        //            if (!item.StartsWith("#"))
        //            {
        //                keyValuePair = item.Split('=');
        //                newDevelopmentSettings.Add(keyValuePair[0], keyValuePair[1]);
        //            }
        //        }
        //    }

        //    return newDevelopmentSettings;
        //}
    }
}
