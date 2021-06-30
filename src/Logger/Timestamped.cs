﻿/* PROJECT: Logger (https://github.com/aprettycoolprogram/Logger)
 *    FILE: Logger.Timestamped.cs
 * UPDATED: 6-30-2021-9:39 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Logger
{
    public class Timestamped
    {
        /// <summary>
        /// Writes a timestamped log file.
        /// </summary>
        /// <param name="logType">         The type of log (e.g., "DEBUG", "ERROR"). This value will be enclosed in brackets, and prepended to the file name.</param>
        /// <param name="assemblyName">    The executing assembly name (e.g., "MyProgram"). This value will be included in the filename, as well as the log message.</param>
        /// <param name="logMessage">      The optional message that is written to the logfile ["No log message defined"]</param>
        /// <param name="verboseLog">      Deterimes if the log is verbose [true] or not [false].</param>
        /// <param name="callerfilePath">  The filename where the error occured (e.g., "MyFile.cs").</param>
        /// <param name="callerMemberName">The method where the error occured (e.g., "MyMethod()")</param>
        /// <param name="callerLineNumber">The line where the error occured (e.g., "100")</param>
        public static void WriteToFile(string logType, string assemblyName, string logMessage = "No log message defined.", bool verboseLog = true, [CallerFilePath] string callerfilePath = "",
                                      [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            Maintenance.ConfirmLogDirectoryExists();

            var timestamp = DateTime.Now.ToString("yyMMdd-HHmmss");
            var logPath    = $"C:/MAWS/Logs/[{logType}]-{assemblyName}_{timestamp}";

            var logContents = verboseLog
                ? $"Message{Environment.NewLine}" +
                  $"======={Environment.NewLine}" +
                  $"{logMessage}{Environment.NewLine}" +
                  $"{Environment.NewLine}" +
                  $"Details{Environment.NewLine}" +
                  $"======={Environment.NewLine}" +
                  $"     Assembly name: {assemblyName}{Environment.NewLine}" +
                  $"  Source file path: {Path.GetFileName(callerfilePath)}{Environment.NewLine}" +
                  $"Source member name: {callerMemberName}{Environment.NewLine}" +
                  $"Source line number: {callerLineNumber}"
                : $"{logMessage}{Environment.NewLine}" +
                  $"[{assemblyName}][{Path.GetFileName(callerfilePath)}][{callerMemberName}][[{callerLineNumber}]";

            File.WriteAllText(logPath, logContents);
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