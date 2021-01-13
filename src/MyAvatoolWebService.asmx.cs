/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 1-13-2021-10:03 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* =====================
 * ABOUT THIS SOURCECODE
 * =====================
 *
 * THIS IS THE DEVELOPMENT BRANCH
 * ------------------------------
 * This sourcecode is for the development branch of MAWS v1.0.
 *
 * You should definately be using the MAWS main branch:
 *
 *  https://github.com/spectrum-health-systems/myavatool-web-service/tree/main
 *
 * THE COMMENTS
 * ------------
 * I've tried to make this sourcecode as human-readable as possible, but since other organizations may use MAWS I've
 * decided to heavily comment everything as well. I know this goes against best practice, however since Netsmart doesn't
 * do the best job of making everything *they* do transparent, I want to make it sure that *my* code is as clear as
 * possible as to what it does, and how it does it.
 *
 * If you fork MAWS for your own development, please do not remove the original comments (and add nice, detailed comments
 * for any functionality you add!).
 *
 * THE MANUAL
 * ----------
 * I recommend that you read the MAWS manual:
 *
 *  https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual.md
 *
 * I spent alot of time working on the manual, and update it with each release of MAWS. It covers pretty much anything
 * you need to know about MAWS.
 */

using System.Web.Services;

using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    /// <summary>Summary description for MyAvatoolWebService</summary>
    /// <remarks>Required for MAWS. Do not remove.</remarks>
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
            /* The version number should be the same as the version being developed.
             */
            return "VERSION 1.0";
        }

        /// <summary>Performs an MAWS action.</summary>
        /// <param name="sentOptionObject">The OptionObject2 object sent from myAvatar.</param>
        /// <param name="action">          The MAWS action perform.</param>
        /// <returns>A completed OptionObject2 that MAWS will return to myAvatar.</returns>
        /// <remarks>This method is required by myAvatar. Do not remove.</remarks>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
        {
            /* The main function of MAWS is to perform an "action" (i.e., a MAWS method call) using data that is received
             * from myAvatar via an OptionObject2.
             *
             * Each "action" has a class with the same name. For example, the "VerifyInpatientAdmissionDate" action is
             * performed by methods in the "VerifyInpatientAdmissionDate.cs" class.
             *
             * To perform an "action", you'll need to create a ScriptLink event in myAvatar that passes both an "action"
             * and an OptionObject2 to MAWS.
             *
             * For more information about creating ScriptLink events, please see the MAWS manual:
             *
             *  https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual.md
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

        public static OptionObject2 MethodName(OptionObject2 sentOptionObject)
        {
            return new OptionObject2();
        }
    }
}