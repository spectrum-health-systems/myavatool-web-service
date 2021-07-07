/* PROJECT: TheOptionObject (https://github.com/aprettycoolprogram/TheOptionObject)
 *    FILE: TheOptionObject.Finalize.cs
 * UPDATED: 7-1-2021-8:46 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace TheOptionObject
{
    public class Finalize
    {
        public static Dictionary<string, string> theOptionObjectSetting;

        /// <summary>
        /// Confirms various fields in an OptionObject2015 object are populated.
        /// </summary>
        /// <returns>An OptionObject2015 object with all required fields populated.</returns>
        public static OptionObject2015 WhichComponents(OptionObject2015 sentOptionObject, OptionObject2015 workingOptionObject, bool finalizeRecommended = true, bool finalizeNotRecommended = false)
        {
            /* myAvatar requires that a completed OptionObject2015 object be returned. This method will make sure that
             * all of the fields of an OptionObject2015 object that are not explicitly set are populated with the
             * original values in "sentOptionObject".
             */
            theOptionObjectSetting = Settings.GetSettings();

            Logger.Timestamped.LogEvent(theOptionObjectSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, "In WhichComponents.");

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

            var finalizeRequiredFieldsMessage = $"FinalizeRequiredFields values:{Environment.NewLine}" +
                                                $"finalizedOptionObject.EntityID={finalizedOptionObject.EntityID}{Environment.NewLine}" +
                                                $"finalizedOptionObject.Facility={finalizedOptionObject.Facility}{Environment.NewLine}" +
                                                $"finalizedOptionObject.NamespaceName={finalizedOptionObject.NamespaceName}{Environment.NewLine}" +
                                                $"finalizedOptionObject.OptionId={finalizedOptionObject.OptionId}{Environment.NewLine}" +
                                                $"finalizedOptionObject.ParentNamespace={finalizedOptionObject.ParentNamespace}{Environment.NewLine}" +
                                                $"finalizedOptionObject.ServerName={finalizedOptionObject.ServerName}{Environment.NewLine}" +
                                                $"finalizedOptionObject.SystemCode={finalizedOptionObject.SystemCode}";

            Logger.Timestamped.LogEvent(theOptionObjectSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, finalizeRequiredFieldsMessage);
        }

        /// <summary>
        /// Confirms the recommended fields for a valid OptionObject2015 object are populated.
        /// </summary>
        /// <returns>An OptionObject2015 object with all recommended fields populated.</returns>
        private static void FinalizeRecommendedFields(OptionObject2015 sentOptionObject, OptionObject2015 workingOptionObject, OptionObject2015 finalizedOptionObject)
        {
            finalizedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
            finalizedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
            finalizedOptionObject.OptionUserId = sentOptionObject.OptionUserId;

            // If the workingOptionObject has data, use that to complete the completedOptionObject. Otherwise, use the
            // data that exists in the sentOptionObject.
            if(workingOptionObject.ErrorCode >= 1)
            {
                finalizedOptionObject.ErrorCode = workingOptionObject.ErrorCode;
                finalizedOptionObject.ErrorMesg = workingOptionObject.ErrorMesg;
                Logger.Timestamped.LogEvent(theOptionObjectSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, "ErrorCode >= 1");
            }
            else
            {
                finalizedOptionObject.ErrorCode = sentOptionObject.ErrorCode;
                finalizedOptionObject.ErrorMesg = sentOptionObject.ErrorMesg;
                Logger.Timestamped.LogEvent(theOptionObjectSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, "ErrorCode = 1");
            }

            var finalizeRecommendedFieldsMessage = $"FinalizeRequiredFields values:{Environment.NewLine}" +
                                                   $"finalizedOptionObject.EpisodeNumber={finalizedOptionObject.EpisodeNumber}{Environment.NewLine}" +
                                                   $"finalizedOptionObject.OptionStaffId={finalizedOptionObject.OptionStaffId}{Environment.NewLine}" +
                                                   $"finalizedOptionObject.OptionUserId={finalizedOptionObject.OptionUserId}{Environment.NewLine}" +
                                                   $"finalizedOptionObject.ErrorCode={finalizedOptionObject.ErrorCode}{Environment.NewLine}" +
                                                   $"finalizedOptionObject.ErrorMesg={finalizedOptionObject.ErrorMesg}";

            Logger.Timestamped.LogEvent(theOptionObjectSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, finalizeRecommendedFieldsMessage);
        }

        /// Confirms the non-recommended fields for a valid OptionObject2015 object are populated.
        /// </summary>
        /// <returns>An OptionObject2015 object with all required fields populated.</returns>
        private static void FinalizeNonRecommendedFields(OptionObject2015 sentOptionObject, OptionObject2015 completedOptionObject2)
        {
            //Logger.WriteToTimestampedFile($"[DEBUG-0090]OptionObjectMaintenance.FinalizeNonRecommendedFields()", $"This shouldn't happen!");
            completedOptionObject2.Forms = sentOptionObject.Forms;
            Logger.Timestamped.LogEvent(theOptionObjectSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, "Uh oh! This shouldn't have happened!");
        }
    }
}
