/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Compare.cs
 * UPDATED: 7-9-2021-8:57 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace Dose
{
    internal class Compare
    {
        public static OptionObject2015 Percentage(OptionObject2015 sentOptionObject, Dictionary<string, string> doseSetting)
        {
            var logSetting   = doseSetting["Logging"].ToLower();
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Location: Dose.Verify.Percentage()");

            const string dosageOneFieldId           = "107";
            const string lastOrderScheduledFieldId  = "142";

            var currentDose = 0.0;
            var lastOrderScheduledText = "";

            //var percentDifference = 0.0;

            var foundDosageOneFieldId          = false;
            var foundLastOrderScheduledFieldId = false;
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Finished setting up variables");

            /* We will loop through each field of every form in sentOptionObject2, and do something special if we land
             * on the "dosageOneFieldId" or "lastOrderScheduledFieldId".
             */
            foreach(FormObject form in sentOptionObject.Forms)
            {
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "In form loop.");
                foreach(FieldObject field in form.CurrentRow.Fields)
                {
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"In field loop. {foundDosageOneFieldId},{foundLastOrderScheduledFieldId}");
                    switch(field.FieldNumber)
                    {
                        case dosageOneFieldId:
                            currentDose = int.Parse(field.FieldValue);                                              // TODO Convert.ToInt()?
                            foundDosageOneFieldId = true;
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found dosage field.");
                            break;

                        case lastOrderScheduledFieldId:
                            lastOrderScheduledText = field.FieldValue;
                            foundLastOrderScheduledFieldId = true;
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found last order field.");
                            break;

                        default:
                            LogEvent.Timestamped(logSetting, "ERROR", assemblyName, "Required fields not found.");
                            break;
                    }

                    /* If we've found everything we need, we'll stop searching for stuff.
                     */
                    if(foundDosageOneFieldId && foundLastOrderScheduledFieldId)
                    {
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found both fields, but not done.");
                        break;
                    }
                }
                if(foundDosageOneFieldId && foundLastOrderScheduledFieldId)
                {
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found both fields, exiting loops.");
                    break;
                }
            }

            var errMsgBody = string.Empty;
            var errMsgCode = 0;
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "1");

            // 1. Parse the lastOrderScheduledText and get the milligrams
            // 2. Check what the percentage difference between the current does and the last dose

            var previousDosagePrefix = doseSetting["PreviousDosagePrefix"];
            var previousDosageSuffix = doseSetting["PreviousDosageSuffix"];
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "2");

            var liners = lastOrderScheduledText.Split('\n');

            var needLine = liners[1];

            var test = needLine.Replace($"{previousDosagePrefix}", "");
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"3: {needLine}, {test}");

            var test2 = test.Replace(previousDosageSuffix, "");
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"4: {test2}");

            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Current doseage: {currentDose}, Last Order: {lastOrderScheduledText}, Previous dosage! {test2}");

            var previousDose = Convert.ToDouble(test2);

            var percentDifference = currentDose/previousDose;

            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"currDose: {currentDose}, prevDose: {previousDose}, percentDifference: {percentDifference}");

            var maxPercentIncrease = Convert.ToDouble(doseSetting["PercentageMax"]);

            if(percentDifference >= maxPercentIncrease)
            {
                errMsgBody = $"WARNING\nThe percentage increas is too high! ({percentDifference}%)";
                errMsgCode = 1;
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Too high! ({percentDifference}%/{maxPercentIncrease}%)");
            }
            else
            {
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Just fine! ({percentDifference}%/{maxPercentIncrease}%)");
            }

            var doseOptionObject2015 = new OptionObject2015();

            if(errMsgCode != 0)
            {
                doseOptionObject2015.ErrorCode = errMsgCode;
                doseOptionObject2015.ErrorMesg = errMsgBody;

                /* Uncomment this line to overide the "nice" error message with detailed information users don't need to
                 * see, which may be usefull when testing.
                 */
                //verifyAdmitDateOptionObject2015.ErrorMesg = $"[ERROR]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
            }

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

            // Log this event


            return doseOptionObject2015;
        }
    }
}
