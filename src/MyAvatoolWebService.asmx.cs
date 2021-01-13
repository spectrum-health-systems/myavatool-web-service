/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 1-13-2021-10:38 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* =====================
 * ABOUT THIS SOURCECODE
 * =====================
 *
 * THIS IS THE MAWS VERSION 0.1 BRANCH
 * -----------------------------------
 * This sourcecode is for MAWS v0.1, a more complete blank template for MAWS, building on v0.0. It includes comments and
 * some minor naming convention changes.
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
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <param name="action">           The MAWS action perform.</param>
        /// <returns>A completed OptionObject2 that MAWS will return to myAvatar.</returns>
        /// <remarks>This method is required by myAvatar. Do not remove.</remarks>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject2, string action)
        {
            /* The main function of MAWS is to perform an "action" (i.e., a MAWS method call) using data that is received
             * from myAvatar via an OptionObject2.
             *
             * The "MyAvatoolWebService.asmx.cs.RunScript()" method is the receiver of both the OptionObject2, and the
             * requested action.
             *
             * Within MAWS, each "action" has:
             *
             *  1. A method in MyAvatoolWebService.asmx.cs, used to do any necessary pre-processing
             *  2. A seperate class in MAWS, used to do the actual work for the action
             *
             * For example, if you call the "VerifyInpatientAdmissionDate" action, the following occurs:
             *
             *  1. The MyAvatoolWebService.asmx.cs.RunScript() method receives both the OptionObject2, and
             *     the "VerifyInpatientAdmissionDate" action
             *  2. The "MyAvatoolWebService.asmx.cs.VerifyInpatientAdmissionDate()" method is called, passing the
             *     OptionObject2 object, as well as any necessary parameters
             *  3. The "MyAvatoolWebService.asmx.cs.VerifyInpatientAdmissionDate()" method does any necessary
             *     pre-processing
             *  4. The "MyAvatoolWebService.asmx.cs.VerifyInpatientAdmissionDate()" method calls
             *     the "MyAvatoolWebService.VerifyInpatientAdmissionDate.cs.<method-name>() method, which does the work
             *     requested by the action
             * 5.
             *
             * performed by methods in the "VerifyInpatientAdmissionDate.cs" class.
             *
             * To perform an "action", you'll need to create a ScriptLink event in myAvatar that passes both an "action"
             * and an OptionObject2 to MAWS.
             *
             * For more information about creating ScriptLink events, please see the MAWS manual:
             *
             *  https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual.md
             */

            /* This switch statement will call the appropriate "action" method call.
             *
             * If the requested action is not one of the supported methods, the OptionObject2 is returned without any
             * changes being made.
             */
            switch(action)
            {
                case "doSomething":
                    return MethodName(sentOptionObject2);

                default:
                    break;
            }

            return sentOptionObject2;
        }

        /// <summary>This is a method call for a MAWS "action".</summary>
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <returns>A completed OptionObject2.</returns>
        public static OptionObject2 MethodName(OptionObject2 sentOptionObject2)
        {
            /* While MAWS "actions" are completed by a seperate class, the "action" first passed to a local method in the
             * event there is pre-processing to be done.
             */
            return new OptionObject2();
        }
    }
}