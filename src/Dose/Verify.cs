/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Verify.cs
 * UPDATED: 7-7-2021-9:55 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace Dose
{
    internal class Verify
    {
        public static OptionObject2015 Percentage(OptionObject2015 sentOptionObject, Dictionary<string, string> doseSetting)
        {
            Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"1");
            const string dosageOneFieldId           = "107";
            const string lastOrderScheduledFieldId  = "142";

            const int maxPercentIncrease   = 10;

            var currentDose = 0;
            var lastOrderScheduledText = "";

            var percentageDifference = 0;

            var foundDosageOneFieldId          = false;
            var foundLastOrderScheduledFieldId = false;

            /* We will loop through each field of every form in sentOptionObject2, and do something special if we land
             * on the "dosageOneFieldId" or "lastOrderScheduledFieldId".
             */
            foreach(FormObject form in sentOptionObject.Forms)
            {
                Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"2");
                foreach(FieldObject field in form.CurrentRow.Fields)
                {
                    Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"3");
                    switch(field.FieldNumber)
                    {
                        case dosageOneFieldId:
                            Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"4");
                            currentDose = int.Parse(field.FieldValue);                                              // TODO Convert.ToInt()?
                            foundDosageOneFieldId = true;
                            break;

                        case lastOrderScheduledFieldId:
                            Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"5");
                            lastOrderScheduledText = field.FieldValue;
                            foundLastOrderScheduledFieldId = true;
                            break;

                        default:
                            break;
                    }

                    /* If we've found everything we need, we'll stop searching for stuff.
                     */
                    if(foundDosageOneFieldId && foundLastOrderScheduledFieldId)
                    {
                        Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"6");
                        break;
                    }
                }
            }

            Logger.Timestamped.LogEvent("trace", "TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"7");
            var errMsgBody = string.Empty;
            var errMsgCode = 0;

            // 1. Parse the lastOrderScheduledText and get the milligrams
            // 2. Check what the percentage difference between the current does and the last dose

            if(percentageDifference >= maxPercentIncrease)
            {
                errMsgBody = "WARNING\nThe percentage increas is too high! (X%)";
                errMsgCode = 1;
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

            Logger.Timestamped.LogEvent(doseSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, "At end");

            return doseOptionObject2015;
        }

        public static OptionObject2015 Percentage_Testing(OptionObject2015 sentOptionObject, Dictionary<string, string> doseSetting)
        {
            return new OptionObject2015();
        }

        ///// <summary>
        ///// Verifies that a client's current medication dose is not more than a percentage increase.
        ///// </summary>
        ///// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        ///// <returns>An OptionObject2 object with the data.</returns>
        //private static OptionObject2015 VerifyPercentage(OptionObject2015 sentOptionObject2015)
        //{
        //    //const string dosageOneFieldId           = "107";
        //    //const string lastOrderScheduledFieldId  = "142";

        //    //const int maxPercentIncrease   = 10;

        //    //var currentDose = 0;
        //    //var lastOrderScheduledText = "";

        //    //var percentageDifference = 0;

        //    //var foundDosageOneFieldId          = false;
        //    //var foundLastOrderScheduledFieldId = false;

        //    ///* We will loop through each field of every form in sentOptionObject2, and do something special if we land
        //    // * on the "dosageOneFieldId" or "lastOrderScheduledFieldId".
        //    // */
        //    //foreach(FormObject form in sentOptionObject2015.Forms)
        //    //{
        //    //    foreach(FieldObject field in form.CurrentRow.Fields)
        //    //    {
        //    //        switch(field.FieldNumber)
        //    //        {
        //    //            case dosageOneFieldId:
        //    //                currentDose = int.Parse(field.FieldValue);                                              // TODO Convert.ToInt()?
        //    //                foundDosageOneFieldId = true;
        //    //                break;

        //    //            case lastOrderScheduledFieldId:
        //    //                lastOrderScheduledText = field.FieldValue;
        //    //                foundLastOrderScheduledFieldId = true;
        //    //                break;

        //    //            default:
        //    //                break;
        //    //        }

        //    //        /* If we've found everything we need, we'll stop searching for stuff.
        //    //         */
        //    //        if(foundDosageOneFieldId && foundLastOrderScheduledFieldId)
        //    //        {
        //    //            break;
        //    //        }
        //    //    }
        //    //}

        //    //var errMsgBody = string.Empty;
        //    //var errMsgCode = 0;

        //    //// 1. Parse the lastOrderScheduledText and get the milligrams
        //    //// 2. Check what the percentage difference between the current does and the last dose

        //    //if(percentageDifference >= maxPercentIncrease)
        //    //{
        //    //    errMsgBody = "WARNING\nThe percentage increas is too high! (X%)";
        //    //    errMsgCode = 1;
        //    //}

        //    var verifyAdmitDateOptionObject2015 = new OptionObject2015();

        //    //if(errMsgCode != 0)
        //    //{
        //    //    verifyAdmitDateOptionObject2015.ErrorCode = errMsgCode;
        //    //    verifyAdmitDateOptionObject2015.ErrorMesg = errMsgBody;

        //    //    /* Uncomment this line to overide the "nice" error message with detailed information users don't need to
        //    //     * see, which may be usefull when testing.
        //    //     */
        //    //    //verifyAdmitDateOptionObject2015.ErrorMesg = $"[ERROR]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
        //    //}

        //    ///* When this block of code is uncommented, a pop-up with detailed information will be displayed when the
        //    // * errMsgCode is "0", meaning no issues were found, and the form will being submitted normally.
        //    // *
        //    // * This is  useful when debugging, but normally it should be commented out.
        //    // */
        //    ////if (errMsgCode == 0)
        //    ////{
        //    ////    verifyAdmitDateOptionObject2.ErrorCode = 4;
        //    ////    verifyAdmitDateOptionObject2.ErrorMesg = "[DEBUG]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
        //    ////}

        //    //// Log this event
        //    //var logFileContent = "text goes here";
        //    //Logger.WriteToTimestampedFile("Dose.VerifyPercentage", logFileContent);

        //    return verifyAdmitDateOptionObject2015;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="sentOptionObject2015"></param>
        ///// <returns></returns>
        //private static OptionObject2015 VerifyPercentage_Testing(OptionObject2015 sentOptionObject2015)
        //{
        //    var verifyAdmitDateOptionObject2015 = new OptionObject2015();

        //    return verifyAdmitDateOptionObject2015;
        //}
        ///// <summary>
        /////
        ///// </summary>
        //public static void ForceTest()
        //{
        //    // No way to do this, currently.
        //}
    }
}
