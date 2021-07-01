/* PROJECT: Logger (https://github.com/aprettycoolprogram/Logger)
 *    FILE: Logger.Maintenance.cs
 * UPDATED: 7-1-2021-12:39 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.IO;
using System.Reflection;

namespace Logger
{
    public class Maintenance
    {
        /// <summary>
        /// Confirm existance of and/or create the log directory.
        /// </summary>
        public static void ConfirmLogDirectoryExists(string directoryPath)
        {
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);

                Timestamped.LogEvent("system", "SYSTEM", Assembly.GetExecutingAssembly().GetName().Name, $"Created directory: {directoryPath}");
            }
        }
    }
}
