using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestSyntaxEngine
{
    public class RequestComponent
    {
        /// <summary>
        /// Returns the MAWS Request command.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "InptAdmitDate").</returns>
        public static string GetCommand(string mawsRequest)
        {
            var requestCommand = mawsRequest.Split('-')[0].ToLower();
            //Logger.WriteToTimestampedFile($"[DEBUG]RequestSyntaxEngine.GetRequestCommand()", $"[0025] MAWS Request: {mawsRequest} MAWS Command: {requestCommand}");

            return requestCommand;
        }

        /// <summary>
        /// Returns the MAWS Request action.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "ComparePreAdmitToAdmit").</returns>
        public static string GetAction(string mawsRequest)
        {
            var requestAction = mawsRequest.Split('-')[1].ToLower();
            //Logger.WriteToTimestampedFile($"[DEBUG]RequestSyntaxEngine.GetRequestAction()", $"[0038] MAWS Request: {mawsRequest} MAWS Action: {requestAction}");

            return mawsRequest.Split('-')[1].ToLower();
        }

        /// <summary>
        /// Returns the MAWS Request option.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "Testing") ["none"].</returns>
        public static string GetOption(string mawsRequest)
        {
            var requestOption = mawsRequest.Split('-').Length >= 3
                ? mawsRequest.Split('-')[2].ToLower()
                : "none";
            //Logger.WriteToTimestampedFile($"[DEBUG]RequestSyntaxEngine.GetRequestOption()", $"[0053] MAWS Request: {mawsRequest} MAWS Option: {requestOption}");

            return requestOption;
        }
    }
}
