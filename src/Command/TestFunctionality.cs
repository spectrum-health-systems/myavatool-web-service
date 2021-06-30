using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace Command
{
    public class TestFunctionality
    {
        public static void ForceInptAdmitDate()
        {
            Logger.Timestamped.WriteToFile("TESTING", Assembly.GetExecutingAssembly().GetName().Name);

            Command.InptAdmitDate.ExecuteAction(new OptionObject2015(), "InptAdmitDate-ComparePreAdmitToAdmit");
        }
    }
}
