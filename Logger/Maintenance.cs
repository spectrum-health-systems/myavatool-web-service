using System.IO;
using System.Reflection;

namespace Logger
{
    public class Maintenance
    {
        /// <summary>
        /// Confirm that the log directory exists, and if it does not, then create it.
        /// </summary>
        public static void ConfirmLogDirectoryExists()
        {
            if(!Directory.Exists("C:/MAWS/Logs/"))
            {
                Directory.CreateDirectory("C:/MAWS/Logs/");

                // Log this event.
                var logFileContent = "Created directory: C:/MAWS/Logs/";
                Timestamped.WriteToFile("SYSTEM", Assembly.GetExecutingAssembly().GetName().Name, logFileContent);
            }
        }
    }
}
