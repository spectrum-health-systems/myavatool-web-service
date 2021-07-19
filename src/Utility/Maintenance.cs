/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.Maintenance.cs
 * UPDATED: 7-19-2021-9:24 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Performs various maintenance routines.
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
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                LogEvent.Timestamped("system", "SYSTEM", Assembly.GetExecutingAssembly().GetName().Name, $"Created directory: {directoryPath}"); // Testing the length of comments for guidelines.
            }
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 *
 * ------------------------
 * ConfirmDirectoryExists()
 * ------------------------
 * - The paramaters for the LogEvent command are hardcoded here because it's a single line, and it's easier/cleaner to
 *   do it this way.
 */

// This comment is 80 characters ==============================================================|
//
// - File headers

// This comment is 120 characters =====================================================================================|
//
// - File footers
// - Descriptive comments



// This comment is 160 characters =============================================================================================================================|
//
// - Code


// This comment is 200 characters ====================================================================================================================================================================|
//
// - Max width for displaying on GitHub
