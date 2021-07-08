/* PROJECT: Logger (https://github.com/aprettycoolprogram/Logger)
 *    FILE: Logger.Maintenance.cs
 * UPDATED: 7-7-2021-11:47 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Performs logging maintenance.
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
        /// Confirm existance of and/or create a log directory.
        /// </summary>
        public static void ConfirmLogDirectoryExists(string directoryPath)
        {
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);

                LogEvent.Timestamped("system", "SYSTEM", Assembly.GetExecutingAssembly().GetName().Name, "switch(mawsCommand) case: InptAdmitDate [{mawsCommand}]");
            }
        }
    }
}

/* Why hardcoded
 */