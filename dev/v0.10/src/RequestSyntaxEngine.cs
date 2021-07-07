/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.RequestSyntaxEngine.cs
 * UPDATED: 6-25-2021-11:46 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Parsing logic for MAWS Requests.
 *
 * Development notes/comments can be found at the end of this class.
 */

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
            var requestCommand = mawsRequest.Split('-')[0].ToLower();
            Logger.WriteToTimestampedFile($"[DEBUG]RequestSyntaxEngine.GetRequestCommand()", $"[0025] MAWS Request: {mawsRequest} MAWS Command: {requestCommand}");

            return requestCommand;
        }

        /// <summary>
        /// Returns the MAWS Request action.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "ComparePreAdmitToAdmit").</returns>
        public static string GetRequestAction(string mawsRequest)
        {
            var requestAction = mawsRequest.Split('-')[1].ToLower();
            Logger.WriteToTimestampedFile($"[DEBUG]RequestSyntaxEngine.GetRequestAction()", $"[0038] MAWS Request: {mawsRequest} MAWS Action: {requestAction}");

            return mawsRequest.Split('-')[1].ToLower();
        }

        /// <summary>
        /// Returns the MAWS Request option.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "Testing") ["none"].</returns>
        public static string GetRequestOption(string mawsRequest)
        {
            var requestOption = mawsRequest.Split('-').Length >= 3
                ? mawsRequest.Split('-')[2].ToLower()
                : "none";
            Logger.WriteToTimestampedFile($"[DEBUG]RequestSyntaxEngine.GetRequestOption()", $"[0053] MAWS Request: {mawsRequest} MAWS Option: {requestOption}");

            return requestOption;
        }

        /// <summary>
        /// Test MyAvatoolWebService.RequestSyntaxEngine.cs functionality.
        /// </summary>
        public static void ForceTest()
        {
            var mawsRequest    = "ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear";
            var requestCommand = GetRequestCommand(mawsRequest);
            var requestAction  = GetRequestAction(mawsRequest);
            var requestOption  = GetRequestOption(mawsRequest);
            Logger.WriteToTimestampedFile($"[DEBUG]RequestSyntaxEngine.ForceTest()", $"[0067] MAWS Request: {mawsRequest} MAWS Command: {requestCommand} MAWS Action: {requestAction} MAWS Option: {requestOption}");
        }
    }
}

/* DEVELOPMENT NOTES
 * =================
 * - Some of these methods could be reduced to expressions, but I'm leaving them as blocks so it's easier to read.
 *
 * - A MAWS Request is comprised of a "command" (e.g., "InptAdmitDate"), an "action" (e.g., "ComparePreAdmitToAdmit"),
 *   and potentially an option (e.g., "Testing"), all seperated by a "-" delimiter.
 *
 *   A MAWS Request looks like this:
 *
 *      <command>-<action>[-<option>]
 *
 *   Or...
 *
 *      "InptAdmitDate-ComparePreAdmitToAdmit-Testing"
 *
 * - Prior to returning a MAWS Request component, it is converted to lowercase.
 *
 * - For information about how to perform a MAWS Request from within myAvatar, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-using-maws.md
 *
 * - For information about this sourcecode, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
 */