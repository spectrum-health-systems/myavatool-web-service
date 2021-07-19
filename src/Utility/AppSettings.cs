/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.AppSettings.cs
 * UPDATED: 7-19-2021-1:19 PM
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
        public static Dictionary<string, string> FromKeyValuePairFile(string fileName)
        {
            string filePath = $@"C:\MAWS\Configuration\{fileName}";
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
            List<string> fileAsList = new List<string>();

            if (File.Exists(filePath))
            {
                StreamReader fileStream = new StreamReader(filePath);
                string fileLine         = "";

                using (fileStream)
                {
                    while ((fileLine = fileStream.ReadLine()) != null)
                    {
                        fileLine = fileLine.Trim();

                        bool lineContainsData   = !string.IsNullOrWhiteSpace(fileLine);
                        bool lineIsNotComment   = !fileLine.StartsWith("#");
                        bool lineIsKeyValuePair = fileLine.Contains("=");

                        if (lineContainsData && lineIsNotComment && lineIsKeyValuePair)
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
            Dictionary<string, string> settingPairs = new Dictionary<string, string>();

            foreach (string item in fileAsList)
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