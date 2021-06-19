/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 6-19-2021-1:39 PM
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
 * To make sure you are using the latest development branch version, check the /Resources/Dev/current-versions.md file:           *
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
        [WebMethod]
        public string GetVersion()
        {
            /* This is required by myAvatar. Do not remove!
             *
             * I'm leaving this as "VERSION 1.0" throughout the development of MAWS v1.0.
             */
            return "VERSION 1.0";
        }

        /// <summary>
        /// Performs an MAWS request.
        /// </summary>
        /// <param name="sentOptionObject">The OptionObject2015 object sent from myAvatar.</param>
        /// <param name="mawsRequest">     The MAWS request to perform (e.g., "InptAdmitDate-VerifyPreAdmin")</param>
        /// <returns>A completed OptionObject2 that MAWS will return to myAvatar.</returns>
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string mawsRequest)
        {
            /* This is required by myAvatar. Do not remove! The only changes to this method should be adding external methods to the switch statement.
             *
             * For information about how to perform a MAWS request from within myAvatar, please see:
             *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-using-maws.md
             */



            switch(action)
            {
                case "doSomething":
                    return MethodName(sentOptionObject);
                default:
                    break;
            }
            return sentOptionObject;
        }

        public static OptionObject2015 MethodName(OptionObject2015 sentOptionObject)
        {
            return new OptionObject2015();
        }
    }
}
