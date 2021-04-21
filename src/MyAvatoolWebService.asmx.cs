/* PROJECT: MyAvatoolWebService (https://github.com/spectrum-health-systems/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 4-21-2021-10:43 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program, All Rights reserved
 */

/**********************************************************************************************************************************
 *                                 >>> WARNING: THIS IS THE MAWS DEVELOPMENT BRANCH <<<                                           *
 **********************************************************************************************************************************
 *                                                                                                                                *
 * Unless I have forgotten to update this comment, you are looking at v0.8 of the MAWS development branch. You can confirm this   *
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
 *                                                                                                                                *
 *********************************************************************************************************************************/

/* =====================
 * ABOUT THIS SOURCECODE
 * =====================
 *
 * -----------------
 * THERE IS A MANUAL
 * -----------------
 * The MAWS Manual is updated with each release:
 *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual.md
 *
 * --------------------------------
 * YEAH, THERE ARE ALOT OF COMMENTS
 * --------------------------------
 * I've tried to make this sourcecode as human-readable as possible, but since other organizations may use MAWS I've
 * decided to heavily comment everything as well. I know this goes against best practice, however since Netsmart doesn't
 * do the best job of making everything *they* do transparent, I want to make it sure that *my* code is as clear as
 * possible as to what it does, and how it does it.
 *
 * Each of the three different types of comments in MAWS start differently.
 *
 *  /// XML comments used by Visual Studio
 *   // Short comments intended to give additional information about a block of code.
 *   /* Narrative comments when sourcecode concepts need to be explained in more detail.
 *
 * When possible, I link to the relevent parts of the MAWS manual.
 *
 * Please do not remove any of the sourcecode comments, and if you fork MAWS for your own development, please and add
 * your own.
 */

/* ================
 * ABOUT THIS CLASS
 * ================
 * MyAvatoolWebService.asmx.cs contains twp methods that myAvatar requires all custom web services to have:
 *
 *  - GetVersion(): Returns the web service version information
 *  -  RunScript(): Executes web service functionality
 *
 * For more information about these required methods, please see the MAWS manual:
 *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-custom-myavatar-web-services.md#adding-required-methods
 */

using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    /// <summary>
    /// Summary description for MyAvatoolWebService.
    /// </summary>
    /// <remarks>Required by myAvatar. Do not remove.</remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MyAvatoolWebService : WebService
    {
        /// <summary>Returns the MAWS version string.</summary>
        /// <returns>The MAWS version string (e.g., "VERSION 1.0").</returns>
        /// <remarks>This method is required by myAvatar. Do not remove.</remarks>
        [WebMethod]
        public string GetVersion()
        {
            /* For detailed information about GetVersion(), please see the MAWS manual:
             *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual.md
             */
            return "VERSION 1.0";
        }

        /// <summary>Performs an MAWS request</summary>
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <param name="mawsRequest">      The MAWS request to perform (e.g., "InptAdmitDate-VerifyPreAdmin")</param>
        /// <returns>A completed OptionObject2 that MAWS will return to myAvatar.</returns>
        /// <remarks>This method is required by myAvatar. Do not remove.</remarks>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject2, string mawsRequest)
        {
            /* For detailed information about RunScript(), please see the MAWS manual:
             *  https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual.md
             */
            var workingOptionObject2 = new OptionObject2();

            /* Let's have a quick description of this code block here, and more in-depth in the manual.
             */
            if(mawsRequest.Contains("InptAdmitDate"))
            {
                workingOptionObject2 = InptAdmitDate.Parser(sentOptionObject2, mawsRequest);
            }
            else if(mawsRequest.Contains("SubPolicyNumber"))
            {
                //completedOptionObject2 = SubPolicyNumber(sentOptionObject2, mawsRequest);
            }
            else if(mawsRequest.Contains("NewWebServiceCommand-01"))
            {
                //completedOptionObject2 = NewWebServiceCommand-02(sentOptionObject2, mawsRequest);
            }
            else if(mawsRequest.Contains("NewWebServiceCommand-02"))
            {
                //completedOptionObject2 = NewWebServiceCommand-02(sentOptionObject2, mawsRequest);
            }
            else
            {
                workingOptionObject2 = sentOptionObject2;
            }

            // TODO completed OO2 stuff here?
            OptionObject2 completedOptionObject2 = OptionObjectMaintenance.Complete(sentOptionObject2, workingOptionObject2, true,false );

            return completedOptionObject2;
        }
    }
}