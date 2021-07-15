/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.LogEvent.cs
 * UPDATED: 7-15-2021-9:08 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Writes log files.
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Reflection;

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

            // Production or staging.
            //var logDirectoryPath =$@"./AppData/Logs/{dateStamp}";
            //var logDirectoryPath = $"C:/MAWS/Staging/Logs/{dateStamp}";
            var logDirectory = $"C:/MAWS/Logs/{dateStamp}";
            Maintenance.ConfirmDirectoryExists(logDirectory);

            //var hourStamp         = DateTime.Now.ToString($"HH");      // Depreciate
            //var minuteSecondStamp = DateTime.Now.ToString($"mmss");    // Depreciate
            //var millisecondStamp  = DateTime.Now.ToString($"fffffff"); // Depreciate
            //var timestamp = DateTime.Now.ToString($"HHmmssfffffff");


            //var logFilePath = $"{logDirectoryPath}/{minuteSecondStamp}-{millisecondStamp}_{logType}_{assemblyName}-{Path.GetFileName(callerfilePath)}-{callerMemberName}.mawslog"; // Depreciate

            var logFileName = BuildLogFileName(logType, assemblyName, Path.GetFileName(callerfilePath), callerMemberName);
            var logFilePath = $"{logDirectory}/{logFileName}";

            if(File.Exists(logFilePath))
            {
                Thread.Sleep(100);
                logFileName = BuildLogFileName(logType, assemblyName, Path.GetFileName(callerfilePath), callerMemberName);
                logFilePath = $"{logDirectory}/{logFileName}";
            }

            var assemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            var logContents = $"Message{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"{logMessage}{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"Details{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"      MAWS Version: {assemblyVersion}" +
                              $"     Assembly name: {assemblyName}{Environment.NewLine}" +
                              $"  Source file path: {Path.GetFileName(callerfilePath)}{Environment.NewLine}" +
                              $"Source member name: {callerMemberName}{Environment.NewLine}" +
                              $"Source line number: {callerLineNumber}{Environment.NewLine}";

            //$"[ID-{dateStamp}/{hourStamp}{minuteSecondStamp}:{millisecondStamp}]"; // Depreciated last line.

            File.WriteAllText(logFilePath, logContents);
        }


        private static string BuildLogFileName(string logType, string assemblyName, string callerfilePath,
                                       string callerMemberName)
        {
            var timestamp = DateTime.Now.ToString($"HHmmss.fff");

            var io = callerfilePath.IndexOf('.');
            var l = callerfilePath.Length;


            callerfilePath = callerfilePath.Remove(io);

            //return $"{timestamp}_{logType}_{assemblyName}-{Path.GetFileName(callerfilePath)}-{callerMemberName}.mawslog";
            return $"{timestamp}-{logType}-{assemblyName}-{callerfilePath}-{callerMemberName}.mawslog";

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