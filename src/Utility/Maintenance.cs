/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.Maintenance.cs
 * UPDATED: 7-9-2021-9:33 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Performs various maintenance routines.
 *
 * Development notes/comments can be found at the end of this class.
 */

using System.IO;
using System.Reflection;

namespace Utility
{
    public class Maintenance
    {
        /// <summary>
        /// Confirm existance of and/or creates a log directory.
        /// </summary>
        public static void ConfirmDirectoryExists(string directoryPath)
        {
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                LogEvent.Timestamped("system", "SYSTEM", Assembly.GetExecutingAssembly().GetName().Name, $"Created directory: {directoryPath}");
            }
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 *
 * -------------
 * ConfirmLogDirectoryExists()
 * -------------
 * - The paramaters for the LogEvent command are hardcoded here because it's a single line, and it's easier/cleaner to
 *   do it this way.
 */