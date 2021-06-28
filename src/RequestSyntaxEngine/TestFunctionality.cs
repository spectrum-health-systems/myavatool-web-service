
using System;
using System.Diagnostics;
using System.Reflection;

namespace RequestSyntaxEngine
{
    public class TestFunctionality
    {
        /// <summary>
        /// Test MyAvatoolWebService.RequestSyntaxEngine.cs functionality.
        /// </summary>
        public static void Force()
        {
            var mawsRequest    = "ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear";

            var logMessage = $"MAWS Request: {mawsRequest}{Environment.NewLine}" +
                             $"MAWS Command: {RequestComponent.GetCommand(mawsRequest)}{Environment.NewLine}" +
                             $"MAWS Action: {RequestComponent.GetAction(mawsRequest)}{Environment.NewLine}" +
                             $"MAWS Option: {RequestComponent.GetOption(mawsRequest)}";

            Logger.Timestamped.WriteToFile("TESTING", Assembly.GetExecutingAssembly().GetName().Name, logMessage);
        }

    }
}
