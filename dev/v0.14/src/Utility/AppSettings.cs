/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.AppSettings.cs
 * UPDATED: 7-8-2021-12:14 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Loads settings from an external file.
 */

using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public class AppSettings
    {
        /// <summary>
        /// Loads setting values from a file with key/value pairs.
        /// </summary>
        /// <param name="filePath">Path to the settings file.</param>
        /// <returns>A dictionary with the setting values.</returns>
        public static Dictionary<string, string> FromKeyValuePairFile(string filePath)
        {
            List<string> settingsAsList = SettingsAsList(filePath);

            return SettingsAsDictionary(settingsAsList);
        }

        /// <summary>
        /// Put valid setting lines from the a .settings file into a list.
        /// </summary>
        /// <param name="filePath">Path to the settings file.</param>
        /// <returns>A list with valid key/value pair setting lines.</returns>
        public static List<string> SettingsAsList(string filePath)
        {
            var fileAsList = new List<string>();

            if(File.Exists(filePath))
            {
                var fileStream = new StreamReader(filePath);
                var fileLine   = "";

                using(fileStream)
                {
                    while((fileLine = fileStream.ReadLine()) != null)
                    {
                        fileLine = fileLine.Trim();

                        var lineContainsData   = !string.IsNullOrWhiteSpace(fileLine);
                        var lineIsNotComment   = !fileLine.StartsWith("#");
                        var lineIsKeyValuePair = fileLine.Contains("=");

                        if(lineContainsData && lineIsNotComment && lineIsKeyValuePair)
                        {
                            fileAsList.Add(fileLine);
                        }
                    }
                }
            }

            return fileAsList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileAsList"></param>
        /// <returns></returns>
        public static Dictionary<string, string> SettingsAsDictionary(List<string> fileAsList)
        {
            string[] keyValuePair;
            var settingPairs = new Dictionary<string, string>();

            foreach(var item in fileAsList)
            {
                keyValuePair = item.Split('=');
                settingPairs.Add(keyValuePair[0], keyValuePair[1]);
            }

            return settingPairs;
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 */