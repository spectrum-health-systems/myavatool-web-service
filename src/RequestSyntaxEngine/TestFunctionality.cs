/* PROJECT: RequestSyntaxEngine (https://github.com/aprettycoolprogram/RequestSyntaxEngine)
 *    FILE: RequestSyntaxEngine.TestFunctionality.cs
 * UPDATED: 6-30-2021-10:05 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using System.Reflection;

namespace RequestSyntaxEngine
{
    public class TestFunctionality
    {
        /// <summary>
        /// Test RequestSyntaxEngine functionality.
        /// </summary>
        public static void Force()
        {
            var mawsRequest = "ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear";
            var logMessage  = $"MAWS Request: {mawsRequest}{Environment.NewLine}" +
                              $"MAWS Command: {RequestComponent.GetCommand(mawsRequest)}{Environment.NewLine}" +
                              $"MAWS Action: {RequestComponent.GetAction(mawsRequest)}{Environment.NewLine}" +
                              $"MAWS Option: {RequestComponent.GetOption(mawsRequest)}";

            Logger.Timestamped.WriteToFile("TESTING", Assembly.GetExecutingAssembly().GetName().Name, logMessage);
        }
    }
}
