/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.RequestSyntaxEngine.cs
 * UPDATED: 6-20-2021-12:31 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;

namespace MyAvatoolWebService
{
    public class RequestSyntaxEngine
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="mawsRequest"></param>
        /// <returns></returns>
        public static string GetRequestCommand(string mawsRequest)
        {
            return mawsRequest.Split('-')[0];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mawsRequest"></param>
        /// <returns></returns>
        public static string GetRequestAction(string mawsRequest)
        {
            return mawsRequest.Split('-')[1];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mawsRequest"></param>
        /// <returns></returns>
        public static string GetRequestOption(string mawsRequest)
        {
            return mawsRequest.Split('-').Length >= 3
                ? mawsRequest.Split('-')[2]
                : "none";
        }

        /// <summary>
        ///
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