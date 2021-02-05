/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 2-4-2021-10:08 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* =====================
 * ABOUT THIS SOURCECODE
 * =====================
 *
 * -----------------------------------
 * THIS IS THE MAWS VERSION 0.2 BRANCH
 * -----------------------------------
 * This sourcecode is for MAWS v0.2, focusing on moving functionality from the Avatar Web Service:
 *  https://github.com/spectrum-health-systems/Avatool-Web-Service
 *
 * You should definately be using the MAWS main branch in production environments:
 *  https://github.com/spectrum-health-systems/myavatool-web-service/tree/main
 *
 * ------------------
 * THERE IS A MANUAL!
 * ------------------
 * I spend alot of time working on the manual, and update it with each release of MAWS:
 *  https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual.md
 *
 * ---------------------
 * A NOTE ABOUT COMMENTS
 * ---------------------
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

using System.Web.Services;

using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    /// <summary>Summary description for MyAvatoolWebService</summary>
    /// <remarks>Required by myAvatar. Do not remove.</remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MyAvatoolWebService : WebService
    {
        /// <summary>Returns the MAWS version string.</summary>
        /// <returns>The MAWS version string (e.g., "Version 1.0").</returns>
        /// <remarks>This method is required by myAvatar. Do not remove.</remarks>
        [WebMethod]
        public string GetVersion()
        {
            /* For detailed information about GetVersion(), please see the MAWS manual:
             *  https://
             */
            return "VERSION 1.0";
        }

        /// <summary>Performs an MAWS action.</summary>
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <param name="mawsRequest">      The MAWS action perform (e.g., "InptAdmitDate-VerifyPreAdmin")</param>
        /// <returns>A completed OptionObject2 that MAWS will return to myAvatar.</returns>
        /// <remarks>This method is required by myAvatar. Do not remove.</remarks>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject2, string mawsRequest)
        {
            /* For detailed information about RunScript(), please see the MAWS manual:
             *  https:
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