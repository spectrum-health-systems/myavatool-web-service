/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Compare.cs
 * UPDATED: 7-19-2021-4:25 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Logic for the Compare action of the Dose command.
 */

using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
using System.Reflection;
using Utility;

namespace Dose
{
    internal class Compare
    {
        public static OptionObject2015 Percentage(OptionObject2015 sentOptionObject, Dictionary<string, string> doseSetting)
        {
            string logSetting = doseSetting["Logging"].ToLower();
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Location: Dose.Verify.Percentage()");

            const string dosageOneFieldId          = "107";
            const string lastOrderScheduleFieldId = "142";
            double currentDose                     = 0.0;
            string lastOrderScheduleText          = "";
            bool foundDosageOneFieldId             = false;
            bool foundLastOrderScheduleFieldId    = false;
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Finished setting up variables");

            /* We will loop through each field of every form in sentOptionObject2, and do something special if we land
             * on the "dosageOneFieldId" or "lastOrderScheduledFieldId".
             */
            foreach (FormObject form in sentOptionObject.Forms)
            {
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"In form loop.");
                foreach (FieldObject field in form.CurrentRow.Fields)
                {
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"In field loop [field #{field.FieldNumber}]. Dosage field found: {foundDosageOneFieldId} - Last order field found: {foundLastOrderScheduleFieldId}");
                    switch (field.FieldNumber)
                    {
                        case dosageOneFieldId:
                            LogEvent.Timestamped(logSetting, "TEMP", assemblyName, "TEMP");
                            currentDose           = double.Parse(field.FieldValue);
                            LogEvent.Timestamped(logSetting, "TEMP", assemblyName, "TEMP");
                            foundDosageOneFieldId = true;
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found dosage field.");
                            break;

                        case lastOrderScheduleFieldId:
                            lastOrderScheduleText         = field.FieldValue;
                            foundLastOrderScheduleFieldId = true;
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found last order field.");
                            break;

                        default:
                            LogEvent.Timestamped(logSetting, "ERROR", assemblyName, "Required fields not found.");
                            break;
                    }

                    /* If we've found everything we need, we'll stop searching for stuff.
                     */
                    if (foundDosageOneFieldId && foundLastOrderScheduleFieldId)
                    {
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found both fields, but not done.");
                        break;
                    }
                }

                if (foundDosageOneFieldId && foundLastOrderScheduleFieldId)
                {
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found both fields, exiting loops.");
                    break;
                }
            }

            string errMsgBody = string.Empty;
            int errMsgCode    = 0;
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Error message/code initialized.");

            // 1. Parse the lastOrderScheduledText and get the milligrams
            // 2. Check what the percentage difference between the current does and the last dose

            string previousDosagePrefix = doseSetting["PreviousDosagePrefix"];
            string previousDosageSuffix = doseSetting["PreviousDosageSuffix"];
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "2");

            string[] lastOrderedSchedulLines = lastOrderScheduleText.Split('\n');

            string lastScheduledDosage = "";

            foreach (string line in lastOrderedSchedulLines)
            {
                if (line.Contains(previousDosagePrefix) && line.Contains(previousDosageSuffix))
                {
                    lastScheduledDosage = line.Replace($"{previousDosagePrefix}", "");
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Removing prefix: {lastScheduledDosage}");

                    lastScheduledDosage = lastScheduledDosage.Replace(previousDosageSuffix, "");
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Removing suffix: {lastScheduledDosage}");
                }
            }
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Current doseage: {currentDose}, Last Order: {lastOrderScheduleText}, Previous dosage: {lastScheduledDosage}");

            double previousDose = Convert.ToDouble(lastScheduledDosage);
            OptionObject2015 doseOptionObject = new OptionObject2015
            {
                ErrorCode = 0,
                ErrorMesg = ""
            };
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Initialzied doseOptionObject");

            if (currentDose != previousDose)
            {
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Current dose is different than previous dose.");

                double percentDifference = currentDose / previousDose;
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Current doseage: {currentDose}, Previous doseage: {previousDose}, Percentage difference: {percentDifference}");

                double maxPercentIncrease = Convert.ToDouble(doseSetting["PercentageMax"]);

                if (percentDifference >= maxPercentIncrease)
                {
                    doseOptionObject.ErrorCode = 1;
                    doseOptionObject.ErrorMesg = $"WARNING\nThe percentage increase is too high! ({percentDifference}%)";
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Percentage increase is too high: ({percentDifference}%/{maxPercentIncrease}%)");
                }
                else
                {
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Percentage increase within threashold: ({percentDifference}%/{maxPercentIncrease}%)");
                }
            }
            else
            {
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Current dose is same as previous dose.");
            }

            //if (errMsgCode != 0)
            //{
            //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Error code {doseOptionObject.ErrorCode}: {doseOptionObject.ErrorMesg}...more info soon.");
            //}
            //else
            //{
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Error code {doseOptionObject.ErrorCode}: {doseOptionObject.ErrorMesg}...more info soon.");
           //}

            var doseOptionObject2 = TheOptionObject.Finalize.WhichComponents(sentOptionObject, doseOptionObject);

            /* When this block of code is uncommented, a pop-up with detailed information will be displayed when the
             * errMsgCode is "0", meaning no issues were found, and the form will being submitted normally.
             *
             * This is  useful when debugging, but normally it should be commented out.
             */
            //if (errMsgCode == 0)
            //{
            //    verifyAdmitDateOptionObject2.ErrorCode = 4;
            //    verifyAdmitDateOptionObject2.ErrorMesg = "[DEBUG]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
            //}

            string doseOptionObject2Values = $"doseOptionObject2:{Environment.NewLine}" +
                                                   $"sentOptiObject.EntityID = [{doseOptionObject2.EntityID}]{Environment.NewLine}" +
                                                   $"sentOptionObject.Facility = [{doseOptionObject2.Facility}]{Environment.NewLine}" +
                                                   $"sentOptionObject.NamespaceName = [{doseOptionObject2.NamespaceName}]{Environment.NewLine}" +
                                                   $"sentOptionObject.OptionId = [{doseOptionObject2.OptionId}{Environment.NewLine}" +
                                                   $"sentOptionObject.ParentNamespace = [{doseOptionObject2.ParentNamespace}]{Environment.NewLine}" +
                                                   $"sentOptionObject.ServerName = [{doseOptionObject2.ServerName}]{Environment.NewLine}" +
                                                   $"sentOptionObject.SystemCode = [{doseOptionObject2.SystemCode}]{Environment.NewLine}" +
                                                   $"sentOptionObject.EpisodeNumber = [{doseOptionObject2.EpisodeNumber}]{Environment.NewLine}" +
                                                   $"sentOptionObject.OptionStaffId = [{doseOptionObject2.OptionStaffId}]{Environment.NewLine}" +
                                                   $"sentOptionObject.OptionUserId = [{doseOptionObject2.OptionUserId}]{Environment.NewLine}" +
                                                   $"sentOptionObject.ErrorCode = [{doseOptionObject2.ErrorCode}]{Environment.NewLine}" +
                                                   $"sentOptionObject.ErrorMesg = [{doseOptionObject2.ErrorMesg}]";
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, doseOptionObject2Values);



            return doseOptionObject2;
        }
    }
}
