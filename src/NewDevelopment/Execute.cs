﻿/* PROJECT: NewDevelopment (https://github.com/aprettycoolprogram/NewDevelopment)
 *    FILE: NewDevelopment.Execute.cs
 * UPDATED: 7-19-2021-1:32 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* New functionality development.
 */

using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;
using Utility;

namespace NewDevelopment
{
    public class Execute
    {
        //public static Dictionary<string, string> newDevelopmentSetting;

        /// <summary>
        /// Executes a MAWS action for the NewDevelopment command.
        /// </summary>
        /// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">         The MAWS Request string.</param>
        /// <returns>A completed OptionObject2015.</returns>
        public static OptionObject2015 Action(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            Dictionary<string, string>  newDevelopmentSetting = AppSettings.FromKeyValuePairFile("NewDevelopment.conf");
            string logSetting                                 = newDevelopmentSetting["Logging"].ToLower();
            string assemblyName                               = Assembly.GetExecutingAssembly().GetName().Name;
            string mawsAction                                 = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
            string mawsOption                                 = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Execute NewDevelopment Action: {mawsAction} Option: {mawsOption}]");

            OptionObject2015 doseOptionObject = new OptionObject2015();

            switch (mawsAction)
            {
                case "NewFuntionality01":
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Executing Dose Action: NewFuntionality01 [{mawsAction}] [Option: {mawsOption}]");
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
 * I'll put some notes here soon detailing how this is used.
 */