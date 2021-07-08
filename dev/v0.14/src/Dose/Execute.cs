/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Execute.cs
 * UPDATED: 7-7-2021-11:57 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Determines which MAWS Action to execute for the Dose Command.
 */

using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace Dose
{
    public class Execute
    {
        public static Dictionary<string, string> DoseSetting;

        /// <summary>
        /// Executes a MAWS action for the Dose command.
        /// </summary>
        /// <param name="sentOptionObject">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">     The MAWS Request string.</param>
        /// <returns>A completed OptionObject2015.</returns>
        public static OptionObject2015 Action(OptionObject2015 sentOptionObject, string mawsRequest)
        {
            Dictionary<string, string>  doseSetting = AppSettings.FromKeyValuePairFile(@"C:\MAWS\Dose.settings");
            var logSetting                          = doseSetting["Logging"].ToLower();
            var assemblyName                        = Assembly.GetExecutingAssembly().GetName().Name;
            var mawsAction                          = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
            var mawsOption                          = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Execute Dose Action: {mawsAction} Option: {mawsOption}]");

            var doseOptionObject = new OptionObject2015();

            switch(mawsAction)
            {
                case "verifypercentage":
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Executing Dose Action: VerifyPercentage [{mawsAction}] [Option: {mawsOption}]");
                    Compare.Percentage(sentOptionObject, doseSetting);
                    break;

                default:
                    LogEvent.Timestamped(logSetting, "ERROR", assemblyName, $"Invalid Dose Action: \"{mawsAction}\"");
                    break;
            }

            return doseOptionObject;
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 */