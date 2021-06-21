/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Maintenance.cs
 * UPDATED: 6-21-2021-7:57 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.IO;

namespace MyAvatoolWebService
{
    public class Maintenance
    {

        /// <summary>
        /// Confirm that the log directory exists, and if it does not, then create it.
        /// </summary>
        public static void ConfirmLogDirectory()
        {
            if(!Directory.Exists("C:/MAWS/Log/"))
            {
                Directory.CreateDirectory("C:/MAWS/Log/");

                // Log this event. Logic here, otherwise logging creates an infinate loop.
                var logFileContent = "Created directory: C:/MAWS/Log/";
                Logger.WriteToTimestampedFile("[SYSTEM]Maintenance.ConfirmLogDirectory", logFileContent);
            }
        }
    }
}