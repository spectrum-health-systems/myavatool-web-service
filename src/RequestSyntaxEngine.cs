/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.RequestSyntaxEngine.cs
 * UPDATED: 6-19-2021-5:14 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

namespace MyAvatoolWebService
{
    public class RequestSyntaxEngine
    {
        ///// <summary>
        ///// Parse a MAWS Request into a command, action, and optional option.
        ///// </summary>
        ///// <param name="mawsRequest">The MAWS Request (e.g., "ThisIsACommand-ThisIsAnAction-Option")</param>
        ///// <returns>A Dictionary<string,string> containing the MAWS Request components.</returns>
        //public static Dictionary<string, string> ParseRequest(string mawsRequest)
        //{
        //    var mawsRequestAsArray = mawsRequest.Split('-');

        //    var mawsRequestAsDictionary = new Dictionary<string,string>
        //    {
        //        { "requestCommand", mawsRequestAsArray[0] },
        //        { "requestAction",  mawsRequestAsArray[1] },
        //        { "requestOption",  "none" },
        //    };

        //    if(mawsRequestAsArray.Length >= 3)
        //    {
        //        mawsRequestAsDictionary["requestOption"] = mawsRequestAsArray[2];
        //    }

        //    return mawsRequestAsDictionary;
        //}

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
        }
    }
}