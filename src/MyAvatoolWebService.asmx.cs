﻿/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 1-13-2021-11:27 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* =====================
 * ABOUT THIS SOURCECODE
 * =====================
 *
 * -----------------------------------
 * THIS IS THE MAWS VERSION 0.1 BRANCH
 * -----------------------------------
 * This sourcecode is for MAWS v0.1, a more complete blank template for MAWS, building on v0.0. It includes comments,
 * documentation changes, and some minor code/naming convention changes.
 *
 * You should definately be using the MAWS main branch:
 *
 *  https://github.com/spectrum-health-systems/myavatool-web-service/tree/main
 *
 * ------------------
 * THERE IS A MANUAL!
 * ------------------
 * I spend alot of time working on the manual, and update it with each release of MAWS. It covers pretty much anything
 * you need to know about MAWS. I recommend you read it!
 *
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
 *  1. ///
 *     XML comments used by Visual Studio
 *
 *  2. //
 *     Short comments intended to give additional information about a block of code.
 *
 *  3. /*
 *     Narrative comments when sourcecode concepts need to be explained in more detail.
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
            /* For detailed information about RunScript(), please see the MAWS manual:
             * https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual-maws-calls.md#runscript
             */

            /* This switch statement calls the appropriate "action" method call, which will return an updated
             * OptionObject2 object that is returned to myAvatar.
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
            /* For detailed information about RunScript(), please see the MAWS manual:
             * https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual-maws-calls.md#<method-name>
             */

            /* While MAWS "actions" are completed by a seperate class, the "action" first passed to a local method in the
             * event there is pre-processing to be done.
             */
            return new OptionObject2();
        }
    }
}