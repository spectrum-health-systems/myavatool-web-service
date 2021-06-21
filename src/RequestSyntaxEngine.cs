/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.RequestSyntaxEngine.cs
 * UPDATED: 6-21-2021-8:06 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Parsing logic for MAWS Requests.
 */

using System;

namespace MyAvatoolWebService
{
    public class RequestSyntaxEngine
    {
        /// <summary>
        /// Returns the MAWS Request command.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "InptAdmitDate").</returns>
        public static string GetRequestCommand(string mawsRequest)
        {
            return mawsRequest.Split('-')[0];
        }

        /// <summary>
        /// Returns the MAWS Request action.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "ComparePreAdmitToAdmit").</returns>
        public static string GetRequestAction(string mawsRequest)
        {
            return mawsRequest.Split('-')[1];
        }

        /// <summary>
        /// Returns the MAWS Request option.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "Testing") ["none"].</returns>
        public static string GetRequestOption(string mawsRequest)
        {
            return mawsRequest.Split('-').Length >= 3
                ? mawsRequest.Split('-')[2]
                : "none";
        }

        /// <summary>
        /// Test MyAvatoolWebService.RequestSyntaxEngine.cs functionality.
        /// </summary>
        public static void ForceTest()
        {
            var requestCommand = RequestSyntaxEngine.GetRequestCommand("ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear");
            var requestAction  = RequestSyntaxEngine.GetRequestAction("ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear");
            var requestOption  = RequestSyntaxEngine.GetRequestOption("ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear");

            // Log this event
            var logFileContent = $"requestCommand={requestCommand}{Environment.NewLine}" +
                                 $"requestAction={requestAction}{Environment.NewLine}" +
                                 $"requestOption={requestOption}{Environment.NewLine}";
            Logger.WriteToTimestampedFile("[DEBUG]RequestSyntaxEngine.ForceTest", logFileContent);
        }
    }
}

/* DEVELOPMENT NOTES
 * =================
 * - Some of these methods could be reduced to expressions, but I'm leaving them as blocks so it's easier to read.
 *
 */