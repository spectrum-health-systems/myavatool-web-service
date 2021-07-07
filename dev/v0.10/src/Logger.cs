/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Logger.cs
 * UPDATED: 6-25-2021-10:20 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* MAWS logging functionality.
 *
 * Development notes/comments can be found at the end of this class.
 */

using System;
using System.IO;

namespace MyAvatoolWebService
{
    public class Logger
    {
        /// <summary>
        /// Writes a timestamped log file to C:/MAWS/Log/.
        /// </summary>
        /// <param name="fileName">    The name of the file to write.</param>
        /// <param name="fileContents">The contents of the log file.</param>
        public static void WriteToTimestampedFile(string fileName, string fileContents)
        {
            Maintenance.ConfirmLogDirectoryExists();

            var currentTimestamp = DateTime.Now.ToString("yyMMdd-HHmmss");
            var filePath         = $"C:/MAWS/Logs/{fileName}_{currentTimestamp}";

            File.WriteAllText(filePath, fileContents);
        }
    }
}

/* DEVELOPMENT NOTES
 * =================
 *
 * - For information about this sourcecode, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
 */