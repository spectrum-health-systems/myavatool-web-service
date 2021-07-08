/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.LogEvent.cs
 * UPDATED: 7-8-2021-12:22 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Writes log files.
 *
 * Development notes/comments can be found at the end of this class.
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Utility
{
    public class LogEvent
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="logSetting">      The logging setting in the .settings file.</param>
        /// <param name="logType">         The type of log (e.g., "DEBUG", "ERROR"). This value will be enclosed in brackets, and prepended to the file name.</param>
        /// <param name="assemblyName">    The executing assembly name (e.g., "MyProgram"). This value will be included in the filename, as well as the log message.</param>
        /// <param name="logMessage">      The optional message that is written to the logfile ["No log message defined"]</param>
        /// <param name="callerfilePath">  The filename where the error occured (e.g., "MyFile.cs").</param>
        /// <param name="callerMemberName">The method where the error occured (e.g., "MyMethod()")</param>
        /// <param name="callerLineNumber">The line where the error occured (e.g., "100")</param>
        public static void Timestamped(string logSetting, string logType, string assemblyName, string logMessage = "No log message defined.",
                                       [CallerFilePath] string callerfilePath = "", [CallerMemberName] string callerMemberName = "",
                                       [CallerLineNumber] int callerLineNumber = 0)
        {
            var logEverything   = logSetting == "all";
            var logSpecificType = logType.ToLower().Contains(logSetting);

            if(logEverything || logSpecificType)
            {
                WriteToFile(logType, assemblyName, logMessage, callerfilePath, callerMemberName, callerLineNumber);
            }
        }

        /// <summary>
        /// Writes a timestamped log file.
        /// </summary>
        /// <param name="logType">         The type of log (e.g., "DEBUG", "ERROR"). This value will be enclosed in brackets, and prepended to the file name.</param>
        /// <param name="assemblyName">    The executing assembly name (e.g., "MyProgram"). This value will be included in the filename, as well as the log message.</param>
        /// <param name="logMessage">      The optional message that is written to the logfile ["No log message defined"]</param>
        /// <param name="callerfilePath">  The filename where the error occured (e.g., "MyFile.cs").</param>
        /// <param name="callerMemberName">The method where the error occured (e.g., "MyMethod()")</param>
        /// <param name="callerLineNumber">The line where the error occured (e.g., "100")</param>
        public static void WriteToFile(string logType, string assemblyName, string logMessage, string callerfilePath,
                                       string callerMemberName, int callerLineNumber)
        {
            var dateStamp        = DateTime.Now.ToString("yyMMdd");
            var logDirectoryPath = $"C:/MAWS/Logs/{dateStamp}";

            Maintenance.ConfirmDirectoryExists(logDirectoryPath);

            var hourStamp         = DateTime.Now.ToString($"HH");
            var minuteSecondStamp = DateTime.Now.ToString($"mmss");
            var millisecondStamp  = DateTime.Now.ToString($"fffffff");

            var logFilePath = $"{logDirectoryPath}/{minuteSecondStamp}-{millisecondStamp}_{logType}_{assemblyName}-{Path.GetFileName(callerfilePath)}-{callerMemberName}.mawslog";
            var logContents = $"Message{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"{logMessage}{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"Details{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"     Assembly name: {assemblyName}{Environment.NewLine}" +
                              $"  Source file path: {Path.GetFileName(callerfilePath)}{Environment.NewLine}" +
                              $"Source member name: {callerMemberName}{Environment.NewLine}" +
                              $"Source line number: {callerLineNumber}{Environment.NewLine}" +
                              $"[ID-{dateStamp}/{hourStamp}{minuteSecondStamp}:{millisecondStamp}]";

            File.WriteAllText(logFilePath, logContents);
            Thread.Sleep(10);
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 *
 * -------------
 * WriteToFile()
 * -------------
 * - The totally cool logic that determines the filepath/method/line number of the message that is being logged came
 *   from this article:
 *      https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information
 */