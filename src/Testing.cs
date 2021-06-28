/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Testing.cs
 * UPDATED: 6-25-2021-12:51 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Testing functionality for MAWS.
 *
 * Development notes/comments can be found at the end of this class.
 */

using System.Collections.Generic;
using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    public class Testing
    {
        /// <summary>
        /// Force testing of various MAWS components.
        /// </summary>
        /// <param name="testFunctionality"></param>
        public static void Functionality(MyAvatoolWebService thisService, Dictionary<string, string> mawsSettings)
        {
            if(mawsSettings["TestRequestSyntaxEngine"] == "true")
            {
                RequestSyntaxEngine.TestFunctionality.Force();
            }

            if(mawsSettings["TestInptAdmitDate"] == "true")
            {
                thisService.RunScript(new OptionObject2015(), "InptAdmitDate-ComparePreAdmitToAdmit");
                //InptAdmitDate.ForceTest();
            }
        }
    }
}

/* DEVELOPMENT NOTES
 * =================
 *
 * - For information about this sourcecode, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
 */