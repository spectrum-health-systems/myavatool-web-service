/* PROJECT: Test (https://github.com/aprettycoolprogram/Test)
 *    FILE: Test.Existing.cs
 * UPDATED: 6-30-2021-10:05 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;

namespace Test
{
    public class Existing
    {
        /// <summary>
        /// Force testing of various MAWS components.
        /// </summary>
        /// <param name="testFunctionality"></param>
        public static void Force(Dictionary<string, string> mawsSettings)
        {
            if(mawsSettings["TestRequestSyntaxEngine"] == "true")
            {
                RequestSyntaxEngine.TestFunctionality.Force();
            }

            if(mawsSettings["TestInptAdmitDate"] == "true")
            {
                //InptAdmitDate.ExecuteAction(new OptionObject2015(), "InptAdmitDate-ComparePreAdmitToAdmit");
            }
        }
    }
}
