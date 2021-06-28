using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Reflection;

namespace Logger
{
    public class Timestamped
    {
        /// <summary>
        /// Writes a timestamped log file to C:/MAWS/Log/.
        /// </summary>
        /// <param name="fileName">  The name of the file to write.</param>
        /// <param name="logMessage">The log message.</param>
        public static void WriteToFile(string logType, string assemblyName, string logMessage, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            Maintenance.ConfirmLogDirectoryExists();

            var currentTimestamp = DateTime.Now.ToString("yyMMdd-HHmmss");
            var filePath         = $"C:/MAWS/Logs/[{logType}]-{assemblyName}_{currentTimestamp}";

            var logContents = $"Assembly: {assemblyName}{Environment.NewLine}" +
                              $"    File: {Path.GetFileName(file)}{Environment.NewLine}" +
                              $"  Method: {member}{Environment.NewLine}" +
                              $"    Line: {line}{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"{logMessage}";

            File.WriteAllText(filePath, logContents);
        }
    }
}

/*
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information
 */