/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 6-20-2021-1:29 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/**********************************************************************************************************************************
 *                                 >>> WARNING: THIS IS THE MAWS DEVELOPMENT BRANCH <<<                                           *
 **********************************************************************************************************************************
 * Unless I have forgotten to update this comment, you are looking at v0.9.x.x of the MAWS development branch. You can confirm    *
 * this by checking the following line in /Properties/AssemblyInfo.cs:                                                            *
 *                                                                                                                                *
 *  [assembly: AssemblyVersion("X.X.X.X")]                                                                                        *
 *                                                                                                                                *                                                                                                                       *
 * The MAWS development branch should not be used in production environments.                                                     *
 *                                                                                                                                *
 * For previous development branch versions, please see:                                                                          *
 *  https://github.com/spectrum-health-systems/MyAvatoolWebService/tree/main/dev                                                  *
 *********************************************************************************************************************************/

/* For information about this sourcecode, please see:
 *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
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
        /// Returns the MAWS version string.
        /// </summary>
        /// <returns>The MAWS version string (e.g., "VERSION 1.0").</returns>
        /// <remarks>This method is required by myAvatar. DO NOT REMOVE.</remarks>
        [WebMethod]
        public string GetVersion()
        {
            // Uncomment to test MAWS. See comments in MyAvatoolWebService.ForceTest() for more information.
            ForceTest();

            // Leaving this as v1.0 throughout development.
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
            /* For information about how to perform a MAWS request from within myAvatar, please see:
             * https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-using-maws.md
             */
            var requestCommand = RequestSyntaxEngine.GetRequestCommand(mawsRequest);

            switch(requestCommand)
            {
                case "InptAdmitDate":
                    InptAdmitDate.ExecuteAction(sentOptionObject, mawsRequest);
                    break;

                default:
                    // Log this event
                    var logFileContent = $"[ERROR]{Environment.NewLine}" +
                                         $"request command \"{requestCommand}\" is not valid.{Environment.NewLine}";
                    Logger.WriteToTimestampedFile("[ERROR]MyAvatoolWebService.RunScript", logFileContent);
                    break;
            }

            return sentOptionObject;
        }

        /// <summary>
        /// Test MAWS functionality.
        /// </summary>
        private static void ForceTest()
        {
            /* This is probably a Bad Idea? But I do want an easy way to test functionality, so...uncomment lines below
             * to test various functionality.
             *
             * Then:
             * 1. Run MAWS
             * 2. Click "GetVersion"
             * 3. Click the "Invoke" button
             *
             * It's probably best if you uncomment each of the lines below individually, for the fucntionality you want
             * to test. Each <class>.ForceTest() method should have a breakpoint line at the end, so you can check
             * outputs, etc.
             *
             */
            RequestSyntaxEngine.ForceTest();
            InptAdmitDate.ForceTest();
        }
    }
}
