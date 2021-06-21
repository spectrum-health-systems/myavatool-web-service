/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Maintenance.cs
 * UPDATED: 6-21-2021-8:48 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* MAWS maintenance functionality.
 *
 * Development notes/comments can be found at the end of this class.
 */

using System.IO;

namespace MyAvatoolWebService
{
    public class Maintenance
    {

        /// <summary>
        /// Confirm that the log directory exists, and if it does not, then create it.
        /// </summary>
        public static void ConfirmLogDirectoryExists()
        {
            if(!Directory.Exists("C:/MAWS/Log/"))
            {
                Directory.CreateDirectory("C:/MAWS/Log/");

                // Log this event.
                var logFileContent = "Created directory: C:/MAWS/Log/";
                Logger.WriteToTimestampedFile("[SYSTEM]Maintenance.ConfirmLogDirectory", logFileContent);
            }
        }
    }
}

/* DEVELOPMENT NOTES
 * =================
 *
 * - For information about this sourcecode, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
 */