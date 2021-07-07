/* PROJECT: NewDevelopment (https://github.com/aprettycoolprogram/NewDevelopment)
 *    FILE: NewDevelopment.Execute.cs
 * UPDATED: 7-1-2021-8:46 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace NewDevelopment
{
    public class Execute
    {
        public static Dictionary<string, string> newDevelopmentSetting;

        /// <summary>
        /// Executes a MAWS action for the NewDevelopment command.
        /// </summary>
        /// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">         The MAWS Request string.</param>
        /// <returns>A completed OptionObject2015.</returns>
        public static OptionObject2015 Action(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            newDevelopmentSetting = Settings.GetSettings();

            var mawsAction = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
            var mawsOption = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
            Logger.Timestamped.LogEvent(newDevelopmentSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Execute NewDevelopment Action: {mawsAction} [Option={mawsOption}]");

            var newDevelopmentOptionObject = new OptionObject2015();

            switch(mawsAction)
            {
                default:
                    Logger.Timestamped.LogEvent(newDevelopmentSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Invalid NewDevelopment Action: \"{mawsAction}\"");
                    break;
            }

            return newDevelopmentOptionObject;
        }
    }
}