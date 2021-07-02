/* PROJECT: RequestSyntaxEngine (https://github.com/aprettycoolprogram/RequestSyntaxEngine)
 *    FILE: RequestSyntaxEngine.RequestComponent.cs
 * UPDATED: 7-1-2021-8:46 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Reflection;

namespace RequestSyntaxEngine
{
    public class RequestComponent
    {
        /// <summary>
        /// Returns the MAWS Request command.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "InptAdmitDate").</returns>
        public static string GetCommand(string mawsRequest)
        {
            var mawsCommand = mawsRequest.Split('-')[0].ToLower();

            // The RequestSyntaxEngine doesn't have it's own settings file, so we hardcode the logSetting parameter.
            Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"mawsCommand: {mawsCommand}");

            return mawsCommand;
        }

        /// <summary>
        /// Returns the MAWS Request action.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "ComparePreAdmitToAdmit").</returns>
        public static string GetAction(string mawsRequest)
        {
            var mawsAction = mawsRequest.Split('-')[1].ToLower();

            // The RequestSyntaxEngine doesn't have it's own settings file, so we hardcode the logSetting parameter.
            Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"mawsCommand: {mawsAction}");

            return mawsAction;
        }

        /// <summary>
        /// Returns the MAWS Request option.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "Testing") ["none"].</returns>
        public static string GetOption(string mawsRequest)
        {
            var mawsOption = mawsRequest.Split('-').Length >= 3
                ? mawsRequest.Split('-')[2].ToLower()
                : "none";

            // The RequestSyntaxEngine doesn't have it's own settings file, so we hardcode the logSetting parameter.
            Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"mawsCommand: {mawsOption}");

            return mawsOption;
        }
    }
}
