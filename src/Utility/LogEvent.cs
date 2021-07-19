/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.LogEvent.cs
 * UPDATED: 7-19-2021-11:37 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Writes log files.
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
        /// Determines if a log file should be written.
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
            bool logEverything = logSetting == "all";
            bool logSpecificType = logType.ToLower().Contains(logSetting);

            if (logEverything || logSpecificType)
            {
                WriteTimestampedFile(logType, assemblyName, logMessage, callerfilePath, callerMemberName, callerLineNumber);
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
        public static void WriteTimestampedFile(string logType, string assemblyName, string logMessage, string callerfilePath,
                                       string callerMemberName, int callerLineNumber)
        {
            string dateStamp = DateTime.Now.ToString("yyMMdd");
            string logDirectoryPath = $"C:/MAWS/Logs/{dateStamp}";
            Maintenance.ConfirmDirectoryExists(logDirectoryPath);

            string logFileName = BuildLogFileName(logType, assemblyName, Path.GetFileName(callerfilePath), callerMemberName);
            string logFilePath = $"{logDirectoryPath}/{logFileName}";

            if (File.Exists(logFilePath))
            {
                Thread.Sleep(100);
                logFileName = BuildLogFileName(logType, assemblyName, Path.GetFileName(callerfilePath), callerMemberName);
                logFilePath = $"{logDirectoryPath}/{logFileName}";
            }

            string logContents = $"Message{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"{logMessage}{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"Details{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"     Assembly name: {assemblyName}{Environment.NewLine}" +
                              $"  Source file path: {Path.GetFileName(callerfilePath)}{Environment.NewLine}" +
                              $"Source member name: {callerMemberName}{Environment.NewLine}" +
                              $"Source line number: {callerLineNumber}{Environment.NewLine}";

            File.WriteAllText(logFilePath, logContents);
        }

        /// <summary>
        /// Build a logfile name.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="assemblyName"></param>
        /// <param name="callerfilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <returns>A logfile name string.</returns>
        private static string BuildLogFileName(string logType, string assemblyName, string callerfilePath,
                                               string callerMemberName)
        {
            string timeStamp = DateTime.Now.ToString($"HHmmss.fff");
            int fileExtensionLocation = callerfilePath.IndexOf('.');
            string callerfilePathWithoutExtension = callerfilePath.Remove(fileExtensionLocation);
            string logFileName = $"{timeStamp}-{logType}-{assemblyName}-{callerfilePathWithoutExtension}-{callerMemberName}.mawslog";

            return logFileName;
        }
    }
}

/*

=================
DEVELOPMENT NOTES
=================

-------------
Timestamped()
-------------
When you call Utility.LogEvent.Timestamped(), you pass all the information that is need to write a logfile for a specific event,
which includes:
    - Whatever the current "Logging" setting is (e.g., "error"), which can vary depending on the .conf file being worked with
    - The type of logfile being passed (e.g., "ERROR")
    - All of the log information (messages, locations, et al.)

The first thing Timestamped() does is determine if a logfile should be written at all:

    -> If the "Logging" setting is "all", a logfile is written.
    -> If the "Logging" setting is another value:
       -> Determine what the passed logType is (e.g., "ERROR") AND if that logType is in the "Logging" setting.
          -> If the passed logType is found, write the logfile
          -> If the passed logType is not found, don't write the logfile.

The "Logging" setting can be a string of logTypes that are delimited by a "-". For example, "Logging=error-debug" would write all
logTypes of "ERROR" and "DEBUG", but no other logTypes. More information about how this work can be found in the .conf files.

The downside to this method is that every time LogEvent.Timestamped() is called, we do all of what is described above...and in
some cases it is determined that a logfile will not be created, which technically wastes time. The upside is that the type of logs
that can be written are completely agnostic: all you need to do is pass a particular logType, and make sure that logType is
defined in the "Logging" setting.


-------------
WriteTimestampedFile()
-------------
- The totally cool logic that determines the filepath/method/line number of the message that is being logged came
  from this article:
     https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information

- Code blocks:

    ```
    if(File.Exists(logFilePath))
    {
        > Since logfiles are written very quickly, it's possible that two logfiles will have the same name. The logic in this
        > block ensures filenames are unique by adding a few milliseconds to the timestamp when a duplicate filename is found.
    }
    ```

 */