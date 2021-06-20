/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Logger.cs
 * UPDATED: 6-20-2021-12:26 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using System.IO;

namespace MyAvatoolWebService
{
    public class Logger
    {
        public static void WriteToTimestampedFile(string fileName, string fileContents)
        {
            Maintenance.ConfirmLogDirectory();

            var currentTimestamp = DateTime.Now.ToString("yyMMdd-HHmmss");
            var filePath         = $"C:/MAWS/Log/{fileName}_{currentTimestamp}";

            File.WriteAllText(filePath, fileContents);
        }
    }
}