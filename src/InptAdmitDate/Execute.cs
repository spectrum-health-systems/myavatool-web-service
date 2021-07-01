/* PROJECT: InptAdmitDate (https://github.com/aprettycoolprogram/InptAdmitDate)
 *    FILE: InptAdmitDate.Execute.cs
 * UPDATED: 7-1-2021-6:57 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NTST.ScriptLinkService.Objects;

namespace InptAdmitDate
{
    public class Execute
    {
        public static Dictionary<string, string> InptAdmitDateSetting;

        /// <summary>
        /// Executes a MAWS action for the InptAdmitDate command.
        /// </summary>
        /// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">         The MAWS Request string.</param>
        /// <returns>A completed OptionObject2015.</returns>
        public static OptionObject2015 Action(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            InptAdmitDateSetting = Settings.GetSettings();

            var mawsAction                = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
            var mawsOption                = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
            Logger.Timestamped.LogEvent(InptAdmitDateSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Execute InptAdmitDate Action: {mawsAction} [Option={mawsOption}]");

            var inptAdmitDateOptionObject = new OptionObject2015();

            switch(mawsAction)
            {
                case "comparepreadmittoadmit":
                    Logger.Timestamped.LogEvent(InptAdmitDateSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Executing InptAdmitDate Action: comparepreadmittoadmit [Option={mawsOption}]");
                    inptAdmitDateOptionObject = mawsOption == "testing"
                        ? Compare.PreAdmitToAdmit_Testing(sentOptionObject2015, InptAdmitDateSetting)
                        : Compare.PreAdmitToAdmit(sentOptionObject2015, InptAdmitDateSetting);
                    break;

                default:
                    Logger.Timestamped.LogEvent(InptAdmitDateSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Invalid InptAdmitDate Action: \"{mawsAction}\"");
                    break;
            }

            return inptAdmitDateOptionObject;
        }

    }
}
