using NTST.ScriptLinkService.Objects;

namespace RequestSyntaxEngine
{
    public class ParseRequest
    {
        public static OptionObject2015 ExecuteCommand(OptionObject2015 sentOptionObject, string mawsRequest)
        {
            var mawsCommand = RequestComponent.GetCommand(mawsRequest);

            var completedOptionObject = new OptionObject2015();

            //Logger.Timestamped.WriteToFile($"[DEBUG]MyAvatoolWebService.asmx.cs.RunScript()", $"[0062] MAWS Request: {mawsRequest} MAWS Command: {mawsCommand}");

            switch(mawsCommand)
            {
                case "inptadmitdate":
                    //Logger.WriteToTimestampedFile($"[DEBUG]MyAvatoolWebService.asmx.cs.RunScript()", $"[0067] MAWS Request: {mawsRequest} MAWS Command: {requestCommand}");
                    //- SOON - completedOptionObject = InptAdmitDate_old.ExecuteAction(sentOptionObject, mawsRequest);
                    break;

                case "dose":
                    //Logger.WriteToTimestampedFile($"[DEBUG]MyAvatoolWebService.asmx.cs.RunScript()", $"[0072] MAWS Request: {mawsRequest} MAWS Command: {requestCommand}");
                    // - SOON - completedOptionObject = Dose.ExecuteAction(sentOptionObject, mawsRequest);
                    break;

                default:
                    //Logger.WriteToTimestampedFile($"[ERROR]MyAvatoolWebService.asmx.cs.RunScript()", $"[0077] Request command \"{requestCommand}\" is not valid.");
                    break;
            }

            return completedOptionObject;

        }





    }
}
