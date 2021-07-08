/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Settings.cs
 * UPDATED: 7-1-2021-8:46 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Gets the MAWS settings from the MAWS.settings file.
 *
 * Development notes/comments can be found at the end of this class.
 */

using System.Collections.Generic;
using System.IO;

namespace MyAvatoolWebService
{
    public class Settings
    {
        ///// <summary>
        ///// Gets the settings information from MAWS.settings.
        ///// </summary>
        ///// <returns>The MAWS settings dictionary.</returns>
        //public static Dictionary<string, string> GetSettings()
        //{
        //    var mawsSettings     = new Dictionary<string, string>();
        //    var mawsSettingsPath = @"C:/MAWS/MAWS.settings";

        //    if(File.Exists(mawsSettingsPath))
        //    {
        //        var    settingsFileStream = new StreamReader(mawsSettingsPath);
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
        //                mawsSettings.Add(keyValuePair[0], keyValuePair[1]);
        //            }
        //        }
        //    }

        //    return mawsSettings;
        //}
    }
}