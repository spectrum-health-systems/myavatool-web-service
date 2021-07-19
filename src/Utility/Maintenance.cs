﻿/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.Maintenance.cs
 * UPDATED: 7-19-2021-10:17 AM
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
                LogEvent.Timestamped("system", "SYSTEM", Assembly.GetExecutingAssembly().GetName().Name, $"Created directory: {directoryPath}");
            }
        }
    }
}

/*

=================
DEVELOPMENT NOTES
=================

------------------------
ConfirmDirectoryExists()
------------------------
The paramaters for the LogEvent command are hardcoded here because it's a single line, and it's easier/cleaner to do it this way.

 */