/* PROJECT: RequestSyntaxEngine (https://github.com/aprettycoolprogram/RequestSyntaxEngine)
 *    FILE: RequestSyntaxEngine.TestFunctionality.cs
 * UPDATED: 7-15-2021-9:13 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Tests RequestSyntaxEngine functionality.
 */

using System;
using System.Reflection;
using Utility;

namespace RequestSyntaxEngine
{
    public class TestFunctionality
    {
        /// <summary>
        /// Test RequestSyntaxEngine functionality.
        /// </summary>
        public static void Force()
        {
            string mawsRequest = "ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear";
            string logMessage = $"MAWS Request: {mawsRequest}{Environment.NewLine}" +
                              $"MAWS Command: {RequestComponent.GetCommand(mawsRequest)}{Environment.NewLine}" +
                              $" MAWS Action: {RequestComponent.GetAction(mawsRequest)}{Environment.NewLine}" +
                              $" MAWS Option: {RequestComponent.GetOption(mawsRequest)}";
            LogEvent.Timestamped("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, logMessage);
        }
    }
}