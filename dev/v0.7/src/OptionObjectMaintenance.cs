/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.OptionObjectMaintenance.cs
 * UPDATED: 2-4-2021-10:07 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* For detailed information about the OptionObjectMaintenance class, please see the MAWS manual:
 *  https://
 */

using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    public class OptionObjectMaintenance
    {
        /// <summary>Completes an OptionObject2 object so it can be returned to myAvatar successfully.</summary>
        /// <returns>A completed OptionObject2 object.</returns>
        public static OptionObject2 Complete(OptionObject2 sentOptionObject, OptionObject2 workingOptionObject, bool completeRecommended, bool completeNotRecommended)
        {
            /* For detailed information about the OptionObjectMaintenance.Complete() method, please see the MAWS manual:
             *  https://
             */

            var completedOptionObject2 = new OptionObject2();

            /* This method will make sure that all of the fields of an OptionObject2 object that are not explicitly set
             * are set to whatever the original values in "sentOptionObject" were. This ensures that the OptionObject2
             * that is returned to Avatar contains the required information. Currently this is done using brute force,
             * but eventually it will be accomplished with a loop.
             */

            CompleteRequired(sentOptionObject, completedOptionObject2);

            if(completeRecommended)
            {
                CompleteRecommended(sentOptionObject, workingOptionObject, completedOptionObject2);
            }

            if(completeNotRecommended)
            {
                CompleteNotRecommended(sentOptionObject, completedOptionObject2);
            }

            return completedOptionObject2;
        }

        private static void CompleteRequired(OptionObject2 sentOptionObject, OptionObject2 completedOptionObject2)
        {
            // Since these fields MUST be explicitly set prior to returning the OptionObject2, they are always set. If
            // these fields are null when returned to Avatar, the script will fail.
            completedOptionObject2.EntityID = sentOptionObject.EntityID;
            completedOptionObject2.Facility = sentOptionObject.Facility;
            completedOptionObject2.NamespaceName = sentOptionObject.NamespaceName;
            completedOptionObject2.OptionId = sentOptionObject.OptionId;
            completedOptionObject2.ParentNamespace = sentOptionObject.ParentNamespace;
            completedOptionObject2.ServerName = sentOptionObject.ServerName;
            completedOptionObject2.SystemCode = sentOptionObject.SystemCode;
        }

        private static void CompleteRecommended(OptionObject2 sentOptionObject, OptionObject2 workingOptionObject, OptionObject2 completedOptionObject2)
        {
            // Since it is recommended that these be explicitly set prior to returning the OptionObject2, they should
            // always be set by passing "true" as the value for the "recommended" argument. The if statement does its
            // best job to catch any invalid argument values.

            completedOptionObject2.EpisodeNumber = sentOptionObject.EpisodeNumber;
            completedOptionObject2.OptionStaffId = sentOptionObject.OptionStaffId;
            completedOptionObject2.OptionUserId = sentOptionObject.OptionUserId;

            // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use the
            // data that exists in the sentOptionObject.
            if(workingOptionObject.ErrorCode >= 1)
            {
                completedOptionObject2.ErrorCode = workingOptionObject.ErrorCode;
                completedOptionObject2.ErrorMesg = workingOptionObject.ErrorMesg;
            }
            else
            {
                completedOptionObject2.ErrorCode = sentOptionObject.ErrorCode;
                completedOptionObject2.ErrorMesg = sentOptionObject.ErrorMesg;
            }
        }

        private static void CompleteNotRecommended(OptionObject2 sentOptionObject, OptionObject2 completedOptionObject2)
        {
            // Since it is recommended that these NOT BE explicitly set prior to returning the OptionObject2, avoid
            // setting them by passing "false" as the value for the "recommended" argument. Generally, if these fields
            // contain data when returned to myAvatar, this script will fail. The if statement does its best job to
            // catch any invalid argument values.

            completedOptionObject2.Forms = sentOptionObject.Forms;
        }
    }
}