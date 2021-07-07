/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 6-30-2021-1:09 PM
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

using System.Collections.Generic;
using System.Reflection;
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
        public Dictionary<string, string> MawsSetting;

        /// <summary>
        /// Returns the MAWS version.
        /// </summary>
        /// <returns>The MAWS version (e.g., "VERSION 1.0").</returns>
        [WebMethod]
        public string GetVersion()
        {
            MawsSetting = Settings.GetSettings();

            if(MawsSetting["TestFunctionality"] == "true")
            {
                ForceTest(MawsSetting);
            }

            return "VERSION 1.0";
        }

        /// <summary>
        /// Performs an MAWS Request.
        /// </summary>
        /// <param name="sentOptionObject">The OptionObject2015 object sent from myAvatar.</param>
        /// <param name="mawsRequest">     The MAWS Request to perform (e.g., "InptAdmitDate-ComparePreAdmitToAdmit")</param>
        /// <returns>A completed OptionObject2015 that MAWS will return to myAvatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string mawsRequest)
        {
            Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Initial MAWS Request: {mawsRequest}");

            var completedOptionObject = new OptionObject2015();
            var mawsCommand           = RequestSyntaxEngine.RequestComponent.GetCommand(mawsRequest);
            Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"MAWS Command to be executed: {mawsCommand}");

            switch(mawsCommand)
            {
                case "inptadmitdate":
                    Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, "case: inptadmitdate");
                    completedOptionObject = Command.InptAdmitDate.ExecuteAction(sentOptionObject, mawsRequest);
                    break;

                case "dose":
                    Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, "case: dose");
                    // - SOON - completedOptionObject = Dose.ExecuteAction(sentOptionObject, mawsRequest);
                    break;

                default:
                    Logger.Timestamped.WriteToFile("ERROR", Assembly.GetExecutingAssembly().GetName().Name, $"Invalid MAWS Command: \"{mawsCommand} \".");
                    completedOptionObject = sentOptionObject;
                    break;
            }

            return completedOptionObject;
        }

        public void ForceTest(Dictionary<string, string> mawsSettings)
        {
            if(mawsSettings["TestMaws"] == "true")
            {
                var testOptionObject = new OptionObject2015();

                _ = RunScript(testOptionObject, "InptAdmitDate-action-option");
                _ = RunScript(testOptionObject, "Dose-action-option");
            }

            if(mawsSettings["TestRequestSyntaxEngine"] == "true")
            {
                RequestSyntaxEngine.TestFunctionality.Force();
            }

            if(mawsSettings["TestInptAdmitDate"] == "true")
            {
                Command.TestFunctionality.ForceInptAdmitDate();
            }
        }

    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 * - The goal with this class is to just have the "GetVersion()" and "RunScript()" methods, all other logic will be in a
 *   class that corresponds to the requstedCommand (e.g., "InptAdmitDate")
 *
 * - Both GetVersion() and RunScript() are required by myAvatar, so don't remove them.
 *
 * - I'm leaving the "VERSION" as "1.0" throughout development of v1.0.
 *
 * ------------
 * GetVersion()
 * ------------
 * - Injecting code into GetVersion() is probably a Bad Idea, but I wanted an easy way to test functionality without
 *   having to publish the web service every time I made a change.
 *
 *   Here is how you can test MAWS:
 *      1. Make sure you have the proper testing settings configured in maws.settings
 *      2. Run MAWS
 *      3. Click "GetVersion"
 *      4. Click the "Invoke" button
 *
 * -----------
 * RunScript()
 * -----------
 * - RunScript passes everything off to the RequestSyntaxEngine, so (hopefully) this class will never really change, and
 *   updates/addtional functionality can be added via DLL and making minor modifications to RequestSyntaxEngine.csproj.
 */