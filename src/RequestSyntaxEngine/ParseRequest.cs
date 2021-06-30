/* PROJECT: RequestSyntaxEngine (https://github.com/aprettycoolprogram/RequestSyntaxEngine)
 *    FILE: RequestSyntaxEngine.ParseRequest.cs
 * UPDATED: 6-30-2021-11:42 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace RequestSyntaxEngine
{
    public class ParseRequest
    {
        public static OptionObject2015 ExecuteCommand(OptionObject2015 sentOptionObject, string mawsRequest)
        {
            var mawsCommand = RequestComponent.GetCommand(mawsRequest);

            var completedOptionObject = new OptionObject2015();

            //Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, "MAWS Request to be parsed: {mawsRequest}\nMAWS Command to be executed: {mawsCommand}");

            //switch(mawsCommand)
            //{
            //    case "inptadmitdate":
            //        Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name);
            //        //completedOptionObject = Command.InptAdmitDate.ExecuteAction(sentOptionObject, mawsRequest);
            //        break;

            //    case "dose":
            //        Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name);
            //        // - SOON - completedOptionObject = Dose.ExecuteAction(sentOptionObject, mawsRequest);
            //        break;

            //    default:
            //        Logger.Timestamped.WriteToFile("ERROR", Assembly.GetExecutingAssembly().GetName().Name, "Invalid MAWS Request: \"{mawsRequest} \"");
            //        break;
            //}

            return completedOptionObject;
        }
    }
}
