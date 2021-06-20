/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 6-19-2021-7:11 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/**********************************************************************************************************************************
 *                                 >>> WARNING: THIS IS THE MAWS DEVELOPMENT BRANCH <<<                                           *
 **********************************************************************************************************************************
 * Unless I have forgotten to update this comment, you are looking at v0.9.x.x of the MAWS development branch. You can confirm this   *
 * by checking the following line in /Properties/AssemblyInfo.cs:                                                                 *
 *                                                                                                                                *
 *  [assembly: AssemblyVersion("X.X.X.X")]                                                                                        *
 *                                                                                                                                *
 * To make sure you are using the latest development branch version, check the /Resources/Dev/development-information.md file:           *
 *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Dev/development-information.md  *
 *                                                                                                                                *
 * The MAWS development branch should not be used in production environments.                                                     *
 *                                                                                                                                *
 * For previous development branch versions, please see:                                                                          *
 *  https://github.com/spectrum-health-systems/MyAvatoolWebService/tree/main/dev                                                  *
 *********************************************************************************************************************************/

/* For information about this sourcecode, please see:
 *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Dev/sourcecode-information.md
 */

using System.Collections.Generic;
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
            // Uncomment to test MAWS functionality.
            ForceTest();

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
            /* This method is required by myAvatar. Do not remove! The only changes to this method should be adding external methods to the switch statement.
             *
             * For information about how to perform a MAWS request from within myAvatar, please see:
             *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-using-maws.md
             */
            var requestCommand = RequestSyntaxEngine.GetRequestCommand(mawsRequest);
            var requestAction  = RequestSyntaxEngine.GetRequestAction(mawsRequest);
            var requestOption  = RequestSyntaxEngine.GetRequestOption(mawsRequest);

            switch(requestCommand)
            {
                case "InpatientAdmissionDate":
                    InpatientAdmissionDate.ExecuteAction(sentOptionObject, requestAction, requestOption);
                    break;

                default:
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
             */

            RequestSyntaxEngine.ForceTest();
        }
    }
}
