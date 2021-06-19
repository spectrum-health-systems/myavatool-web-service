/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.RequestSyntaxEngine.cs
 * UPDATED: 6-19-2021-4:37 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;

namespace MyAvatoolWebService
{
    public class RequestSyntaxEngine
    {
        /// <summary>
        /// Parse a MAWS Request into a command, action, and optional option.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request (e.g., "ThisIsACommand-ThisIsAnAction-Option")</param>
        /// <returns>A Dictionary<string,string> containing the MAWS Request components.</returns>
        public static Dictionary<string, string> ParseRequest(string mawsRequest)
        {
            var mawsRequestAsArray = mawsRequest.Split('-');

            var mawsRequestAsDictionary = new Dictionary<string,string>
            {
                { "requestCommand", mawsRequestAsArray[0] },
                { "requestAction",  mawsRequestAsArray[1] },
                { "requestOption",  "none" },
            };

            if(mawsRequestAsArray.Length >= 3)
            {
                mawsRequestAsDictionary["requestOption"] = mawsRequestAsArray[2];
            }

            return mawsRequestAsDictionary;
        }

        /// <summary>
        ///
        /// </summary>
        public static void ForceTest()
        {
            // Test parsing the MAWS Request into a command and action.
            Dictionary<string, string> commandAction =  ParseRequest("ThisIsACommand-ThisIsAnAction");

            // Test parsing the MAWS Request into a command, action, and option.
            Dictionary<string, string> commandActionOption =  ParseRequest("ThisIsACommand-ThisIsAnAction-Testing");

            // Test parsing the MAWS Request that conists of more than a command, action, and option.
            Dictionary<string, string> commandActionOptionAndMore =  ParseRequest("ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear");

            var breakPointFor ="RequestSyntaxEngine.ForceTest()";
        }
    }
}