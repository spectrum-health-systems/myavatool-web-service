/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 6-21-2021-8:37 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/******************************************************************************
 *             >>> WARNING: THIS IS THE MAWS DEVELOPMENT BRANCH <<<           *
 ******************************************************************************/

/* MyAvatoolWebService main class.
 *
 * Development notes/comments can be found at the end of this class.
 */

using System;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    /// <summary>
    /// Entry point for MAWS.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MyAvatoolWebService : WebService
    {
        /// <summary>
        /// Returns the MAWS version.
        /// </summary>
        /// <returns>The MAWS version (e.g., "VERSION 1.0").</returns>
        [WebMethod]
        public string GetVersion()
        {
            Testing.Force("all");

            return "VERSION 1.0";
        }

        /// <summary>
        /// Performs an MAWS request.
        /// </summary>
        /// <param name="sentOptionObject">The OptionObject2015 object sent from myAvatar.</param>
        /// <param name="mawsRequest">     The MAWS request to perform (e.g., "InptAdmitDate-VerifyPreAdmin")</param>
        /// <returns>A completed OptionObject2 that MAWS will return to myAvatar.</returns>
        /// <remarks>This method is required by myAvatar. DO NOT REMOVE.</remarks>
        public static OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string mawsRequest)
        {

            var requestCommand = RequestSyntaxEngine.GetRequestCommand(mawsRequest);

            switch(requestCommand)
            {
                case "InptAdmitDate":
                    InptAdmitDate.ExecuteAction(sentOptionObject, mawsRequest);
                    break;

                default:
                    // Log this event.
                    var logFileContent = $"[ERROR]{Environment.NewLine}" +
                                         $"request command \"{requestCommand}\" is not valid.{Environment.NewLine}";
                    Logger.WriteToTimestampedFile("[ERROR]MyAvatoolWebService.RunScript", logFileContent);
                    break;
            }

            return sentOptionObject;
        }
    }
}

/* DEVELOPMENT NOTES
 * =================
 *
 * - The goal with this class is to just have the "GetVersion" and "RunScript()" methods. Everything else will be taken
 *   care of in another class. Both methods are required by myAvatar, so don't remove them.
 *
 * - I'm leaving the "VERSION" as "1.0" throughout development.
 *
 * - Testing.Force() is probably a Bad Idea, but I wanted an easy way to test some functionality without having to
 *   publish the web service every time I made a change. So what ForceTest() does is it allow you to inject code into
 *   the GetVersion() method, allowing you to set breakpoints and/or view [DEBUG] log files. Again, probably a Bad Idea.
 *
 *   Since Testing.Force() is for use during developement, it is disabled in the production version of MAWS.
 *
 *   This is how you can use Testing.Force():
 *      1. Pass a specific test you would like to force (e.g., "requestSyntaxEngine"), or "all" to force all tests. You
 *         can also choose to not pass anything, in which case no tests will be forced.
 *      1. Run MAWS
 *      2. Click "GetVersion"
 *      3. Click the "Invoke" button
 *
 * - For information about how to perform a MAWS request from within myAvatar, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-using-maws.md
 *
 * - For information about this sourcecode, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
 */