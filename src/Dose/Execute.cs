using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NTST.ScriptLinkService.Objects;

namespace Dose
{
    public class Execute
    {
        public static Dictionary<string, string> DoseSetting;

        /// <summary>
        /// Executes a MAWS action for the InptAdmitDate command.
        /// </summary>
        /// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">         The MAWS Request string.</param>
        /// <returns>A completed OptionObject2015.</returns>
        public static OptionObject2015 Action(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            DoseSetting = Settings.GetSettings();

            var mawsAction                = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
            var mawsOption                = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
            Logger.Timestamped.LogEvent(DoseSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Execute InptAdmitDate Action: {mawsAction} [Option={mawsOption}]");

            var inptAdmitDateOptionObject = new OptionObject2015();

            switch(mawsAction)
            {
                case "verifypercentage":
                    Logger.Timestamped.LogEvent(DoseSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Executing InptAdmitDate Action: comparepreadmittoadmit [Option={mawsOption}]");
                    inptAdmitDateOptionObject = mawsOption == "testing"
                        ? Verify.Percentage_Testing(sentOptionObject2015, DoseSetting)
                        : Verify.Percentage(sentOptionObject2015, DoseSetting);
                    break;

                default:
                    Logger.Timestamped.LogEvent(DoseSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Invalid InptAdmitDate Action: \"{mawsAction}\"");
                    break;
            }

            return inptAdmitDateOptionObject;
        }
    }
}
