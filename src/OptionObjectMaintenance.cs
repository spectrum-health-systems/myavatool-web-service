/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.OptionObjectMaintenance.cs
 * UPDATED: 6-10-2021-3:40 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    public class OptionObjectMaintenance
    {
        /// <summary>
        /// Confirms various fields in an OptionObject2015 object are populated.
        /// </summary>
        /// <returns>An OptionObject2015 object with all required fields populated.</returns>
        public static OptionObject2015 FinalizeObject(OptionObject2015 sentOptionObject, OptionObject2015 workingOptionObject, bool finalizeRecommended = true, bool finalizeNotRecommended = false)
        {
            /* myAvatar requires that a completed OptionObject2015 object be returned. This method will make sure that
             * all of the fields of an OptionObject2015 object that are not explicitly set are populated with the
             * original values in "sentOptionObject".
             */
            var finalizedOptionObject = new OptionObject2015();

            FinalizeRequiredFields(sentOptionObject, finalizedOptionObject);

            if(finalizeRecommended)
            {
                FinalizeRecommendedFields(sentOptionObject, workingOptionObject, finalizedOptionObject);
            }

            if(finalizeNotRecommended)
            {
                FinalizeNonRecommendedFields(sentOptionObject, finalizedOptionObject);
            }

            return finalizedOptionObject;
        }

        /// <summary>
        /// Confirms the required fields for a valid OptionObject2015 object are populated.
        /// </summary>
        /// <returns>An OptionObject2015 object with all required fields populated.</returns>
        private static void FinalizeRequiredFields(OptionObject2015 sentOptionObject, OptionObject2015 finalizedOptionObject)
        {
            finalizedOptionObject.EntityID = sentOptionObject.EntityID;
            finalizedOptionObject.Facility = sentOptionObject.Facility;
            finalizedOptionObject.NamespaceName = sentOptionObject.NamespaceName;
            finalizedOptionObject.OptionId = sentOptionObject.OptionId;
            finalizedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;
            finalizedOptionObject.ServerName = sentOptionObject.ServerName;
            finalizedOptionObject.SystemCode = sentOptionObject.SystemCode;
            //Logger.WriteToTimestampedFile($"[DEBUG-0056]OptionObjectMaintenance.FinalizeRequiredFields()", $"{finalizedOptionObject.EntityID} - {finalizedOptionObject.Facility} - {finalizedOptionObject.NamespaceName} - {finalizedOptionObject.OptionId} - {finalizedOptionObject.ParentNamespace} - {finalizedOptionObject.ServerName} - {finalizedOptionObject.SystemCode}");

        }
        /// <summary
        /// Confirms the recommended fields for a valid OptionObject2015 object are populated.
        /// </summary>
        /// <returns>An OptionObject2015 object with all recommended fields populated.</returns>
        private static void FinalizeRecommendedFields(OptionObject2015 sentOptionObject, OptionObject2015 workingOptionObject, OptionObject2015 finalizedOptionObject)
        {
            finalizedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
            finalizedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
            finalizedOptionObject.OptionUserId = sentOptionObject.OptionUserId;

            // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use the
            // data that exists in the sentOptionObject.
            if(workingOptionObject.ErrorCode >= 1)
            {
                finalizedOptionObject.ErrorCode = workingOptionObject.ErrorCode;
                finalizedOptionObject.ErrorMesg = workingOptionObject.ErrorMesg;
            }
            else
            {
                finalizedOptionObject.ErrorCode = sentOptionObject.ErrorCode;
                finalizedOptionObject.ErrorMesg = sentOptionObject.ErrorMesg;
            }
            //Logger.WriteToTimestampedFile($"[DEBUG-0081]OptionObjectMaintenance.FinalizeRecommendedFields()", $"{finalizedOptionObject.EpisodeNumber} - {finalizedOptionObject.OptionStaffId} - {finalizedOptionObject.OptionUserId} - {finalizedOptionObject.ErrorCode} - {finalizedOptionObject.ErrorMesg}");
        }

        /// Confirms the non-recommended fields for a valid OptionObject2015 object are populated.
        /// </summary>
        /// <returns>An OptionObject2015 object with all required fields populated.</returns>
        private static void FinalizeNonRecommendedFields(OptionObject2015 sentOptionObject, OptionObject2015 completedOptionObject2)
        {
            //Logger.WriteToTimestampedFile($"[DEBUG-0090]OptionObjectMaintenance.FinalizeNonRecommendedFields()", $"This shouldn't happen!");
            completedOptionObject2.Forms = sentOptionObject.Forms;
        }
    }
}