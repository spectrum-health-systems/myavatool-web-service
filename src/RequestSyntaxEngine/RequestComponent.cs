/* PROJECT: RequestSyntaxEngine (https://github.com/aprettycoolprogram/RequestSyntaxEngine)
 *    FILE: RequestSyntaxEngine.RequestComponent.cs
 * UPDATED: 7-19-2021-1:31 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Returns various components of a MAWS Request.
 */

using System.Reflection;
using Utility;

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
            string mawsCommand = mawsRequest.Split('-')[0].ToLower();
            LogEvent.Timestamped("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"The MAWS command is: {mawsCommand}");

            return mawsCommand;
        }

        /// <summary>
        /// Returns the MAWS Request action.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "ComparePreAdmitToAdmit").</returns>
        public static string GetAction(string mawsRequest)
        {
            string mawsAction = mawsRequest.Split('-')[1].ToLower();
            LogEvent.Timestamped("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"The MAWS action is: {mawsAction}");

            return mawsAction;
        }

        /// <summary>
        /// Returns the MAWS Request option.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "Testing") ["none"].</returns>
        public static string GetOption(string mawsRequest)
        {
            string mawsOption = mawsRequest.Split('-').Length >= 3
                ? mawsRequest.Split('-')[2].ToLower()
                : "none";
            LogEvent.Timestamped("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"The MAWS option is: {mawsOption}");

            return mawsOption;
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 *
 * -------------
 * GetCommand()
 * -------------
 * - The paramaters for the LogEvent command are hardcoded here because it's a single line, and it's easier/cleaner to
 *   do it this way.
 *
 * -------------
 * GetAction()
 * -------------
 * - The paramaters for the LogEvent command are hardcoded here because it's a single line, and it's easier/cleaner to
 *   do it this way.
 *
 * -------------
 * GetOption()
 * -------------
 * - The paramaters for the LogEvent command are hardcoded here because it's a single line, and it's easier/cleaner to
 *   do it this way.
 *
 */
