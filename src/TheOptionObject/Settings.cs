/* PROJECT: TheOptionObject (https://github.com/aprettycoolprogram/TheOptionObject)
 *    FILE: TheOptionObject.Settings.cs
 * UPDATED: 7-1-2021-8:48 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.IO;

namespace TheOptionObject
{
    public class Settings
    {
        /// <summary>
        /// Gets the settings information from TheOptionObject.settings file.
        /// </summary>
        /// <returns>The TheOptionObject settings dictionary.</returns>
        //public static Dictionary<string, string> GetSettings()
        //{
        //    var theOptionObjectSettings     = new Dictionary<string, string>();
        //    var theOptionObjectSettingsPath = @"C:/MAWS/TheOptionObject.settings";

        //    if(File.Exists(theOptionObjectSettingsPath))
        //    {
        //        var    settingsFileStream = new StreamReader(theOptionObjectSettingsPath);
        //        var    settingsAsList     = new List<string>();
        //        string settingLine;

        //        using(settingsFileStream)
        //        {
        //            while((settingLine = settingsFileStream.ReadLine()) != null)
        //            {
        //                settingsAsList.Add(settingLine.Trim());
        //            }
        //        }

        //        string[] keyValuePair;

        //        foreach(var item in settingsAsList)
        //        {
        //            if(!item.StartsWith("#"))
        //            {
        //                keyValuePair = item.Split('=');
        //                theOptionObjectSettings.Add(keyValuePair[0], keyValuePair[1]);
        //            }
        //        }
        //    }

        //    return theOptionObjectSettings;
        //}
    }
}
