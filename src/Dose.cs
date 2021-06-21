/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.Dose.cs
 * UPDATED: 6-21-2021-8:52 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Dose command logic
 *
 * Development notes/comments can be found at the end of this class.
 */

using System;
using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    public class Dose
    {
        /// <summary>
        /// Executes a MAWS action for the InptAdmitDate command.
        /// </summary>
        /// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">The MAWS request string.</param>
        /// <returns></returns>
        public static OptionObject2015 ExecuteAction(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            var doseOptionObject = new OptionObject2015();
            var requestAction    = RequestSyntaxEngine.GetRequestAction(mawsRequest).ToLower();
            var requestOption    = RequestSyntaxEngine.GetRequestOption(mawsRequest).ToLower();

            switch(requestAction)
            {
                case "verifypercentage":
                    doseOptionObject = requestOption == "testing"
                        ? VerifyPercentage_Testing(sentOptionObject2015)
                        : VerifyPercentage(sentOptionObject2015);
                    break;

                default:
                    // Log this event
                    var logFileContent = $"[ERROR]{Environment.NewLine}" +
                                         $"request action \"{requestAction}\" is not valid.{Environment.NewLine}";
                    Logger.WriteToTimestampedFile("[ERROR]Dose.ExecuteAction", logFileContent);
                    break;
            }

            return doseOptionObject;
        }

        /// <summary>
        /// Verifies that a client's current medication dose is not more than a percentage increase.
        /// </summary>
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <returns>An OptionObject2 object with the data.</returns>
        private static OptionObject2015 VerifyPercentage(OptionObject2015 sentOptionObject2015)
        {
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
            foreach(FormObject form in sentOptionObject2015.Forms)
            {
                foreach(FieldObject field in form.CurrentRow.Fields)
                {
                    switch(field.FieldNumber)
                    {
                        case dosageOneFieldId:
                            currentDose = int.Parse(field.FieldValue);                                              // TODO Convert.ToInt()?
                            foundDosageOneFieldId = true;
                            break;

                        case lastOrderScheduledFieldId:
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
                        break;
                    }
                }
            }

            var errMsgBody = string.Empty;
            var errMsgCode = 0;

            // 1. Parse the lastOrderScheduledText and get the milligrams
            // 2. Check what the percentage difference between the current does and the last dose

            if(percentageDifference >= maxPercentIncrease)
            {
                errMsgBody = "WARNING\nThe percentage increas is too high! (X%)";
                errMsgCode = 1;
            }

            var verifyAdmitDateOptionObject2015 = new OptionObject2015();

            if(errMsgCode != 0)
            {
                verifyAdmitDateOptionObject2015.ErrorCode = errMsgCode;
                verifyAdmitDateOptionObject2015.ErrorMesg = errMsgBody;

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
            var logFileContent = "text goes here";
            Logger.WriteToTimestampedFile("Dose.VerifyPercentage", logFileContent);

            return verifyAdmitDateOptionObject2015;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sentOptionObject2015"></param>
        /// <returns></returns>
        private static OptionObject2015 VerifyPercentage_Testing(OptionObject2015 sentOptionObject2015)
        {
            var verifyAdmitDateOptionObject2015 = new OptionObject2015();

            return verifyAdmitDateOptionObject2015;
        }
        /// <summary>
        ///
        /// </summary>
        public static void ForceTest()
        {
            // No way to do this, currently.
        }
    }
}

/* DEVELOPMENT NOTES
 * =================
 *
 * - For information about this sourcecode, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
 */