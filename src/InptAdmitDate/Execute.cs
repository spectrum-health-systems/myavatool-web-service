/* PROJECT: InptAdmitDate (https://github.com/aprettycoolprogram/InptAdmitDate)
 *    FILE: InptAdmitDate.Execute.cs
 * UPDATED: 7-8-2021-10:42 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Determines which MAWS Action to execute for the InptAdmitDate Command.
 */

using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace InptAdmitDate
{
    public class Execute
    {
        //public static Dictionary<string, string> InptAdmitDateSetting;

        /// <summary>
        /// Executes a MAWS action for the InptAdmitDate command.
        /// </summary>
        /// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">         The MAWS Request string.</param>
        /// <returns>A completed OptionObject2015.</returns>
        public static OptionObject2015 Action(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            Dictionary<string, string>  inptAdmitDateSetting = AppSettings.FromKeyValuePairFile("InptAdmitDate.settings");
            var logSetting                                   = inptAdmitDateSetting["Logging"].ToLower();
            var assemblyName                                 = Assembly.GetExecutingAssembly().GetName().Name;
            var mawsAction                                   = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
            var mawsOption                                   = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Execute InptAdmitDate Action: {mawsAction} Option: {mawsOption}]");

            // DEPRECIATED
            //InptAdmitDateSetting = Settings.GetSettings();
            //var mawsAction                = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
            //var mawsOption                = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
            //Logger.Timestamped.LogEvent(InptAdmitDateSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Execute InptAdmitDate Action: {mawsAction} [Option={mawsOption}]");

            var inptAdmitDateOptionObject = new OptionObject2015();

            switch(mawsAction)
            {
                case "comparepreadmittoadmit":
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Executing InptAdmitDate Action: ComparePreAdmitToAdmit [{mawsAction}] [Option: {mawsOption}]");
                    Compare.PreAdmitToAdmit(sentOptionObject2015, inptAdmitDateSetting);
                    break;

                default:
                    LogEvent.Timestamped(logSetting, "ERROR", assemblyName, $"Invalid InptAdmitDate Action: \"{mawsAction}\"");
                    break;
            }

            return inptAdmitDateOptionObject;
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 */