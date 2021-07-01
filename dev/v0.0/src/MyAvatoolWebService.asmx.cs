using NTST.ScriptLinkService.Objects;

using System.Web.Services;

namespace MyAvatoolWebService
{
    /// <summary>Summary description for MyAvatoolWebService</summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. [System.Web.Script.Services.ScriptService]
    public class MyAvatoolWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
        {
            switch(action)
            {
                case "doSomething":
                    return MethodName(sentOptionObject);

                default:
                    break;
            }
            return sentOptionObject;
        }

        public static OptionObject2 MethodName(OptionObject2 sentOptionObject)
        {
            return new OptionObject2();
        }
    }
}