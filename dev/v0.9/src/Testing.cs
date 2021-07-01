/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Testing.cs
 * UPDATED: 6-21-2021-8:29 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Testing functionality for MAWS.
 *
 * Development notes/comments can be found at the end of this class.
 */

namespace MyAvatoolWebService
{
    public class Testing
    {
        /// <summary>
        /// Force testing of various MAWS components.
        /// </summary>
        /// <param name="testFunctionality"></param>
        public static void Force(string testFunctionality)
        {
            switch(testFunctionality)
            {
                case "requestSyntaxEngine":
                    RequestSyntaxEngine.ForceTest();
                    break;

                case "inptAdmitDate":
                    InptAdmitDate.ForceTest();
                    break;

                case "all":
                    RequestSyntaxEngine.ForceTest();
                    InptAdmitDate.ForceTest();
                    break;

                case "none":
                    break;

                default:
                    break;
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