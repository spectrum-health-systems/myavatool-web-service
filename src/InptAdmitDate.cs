/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.InptAdmitDate.cs
 * UPDATED: 6-20-2021-12:49 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

using System;
using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    public class InptAdmitDate
    {
        /// <summary>
        /// Executes a MAWS action for the InptAdmitDate command
        /// </summary>
        /// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">The MAWS request string.</param>
        /// <returns></returns>
        public static OptionObject2015 ExecuteAction(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            var inptAdmitDateOptionObject = new OptionObject2015();
            var requestAction             = RequestSyntaxEngine.GetRequestAction(mawsRequest).ToLower();
            var requestOption             = RequestSyntaxEngine.GetRequestOption(mawsRequest).ToLower();

            switch(requestAction)
            {
                case "comparepreadmittoadmit":
                    inptAdmitDateOptionObject = requestOption == "testing"
                        ? ComparePreAdmitToAdmit_Testing(sentOptionObject2015)
                        : ComparePreAdmitToAdmit(sentOptionObject2015);
                    break;

                default:
                    break;
            }

            return inptAdmitDateOptionObject;
        }

        /// <summary>
        /// Verifies that client's Pre-Admission date is the same as the system date.
        /// </summary>
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <returns>An OptionObject2 object with the data.</returns>
        /// <remarks>This method is called by the "InptAdmitDate-VerifyPreAdmitDate" mawsRequest.</remarks>
        private static OptionObject2015 ComparePreAdmitToAdmit(OptionObject2015 sentOptionObject2015)
        {
            // You may need to modify these values to match the fieldIDs for your organization.
            const int    preAdmissionHardcodedValue     = 3;
            const string typeOfAdmissionFieldId         = "44";
            const string preAdmitToAdmissionDateFieldId = "42";

            var typeOfAdmission                       = 0;
            var preAdmitToAdmissionDate               = new DateTime(1900, 1, 1);

            var foundTypeOfAdmissionField             = false;
            var foundPreAdmitToAdmissionDateField     = false;

            /* We will loop through each field of every form in sentOptionObject2, and do something special if we land
             * on the "typeOfAdmissionField" or "preAdmitToAdmissionDateField".
             */
            foreach(FormObject form in sentOptionObject2015.Forms)
            {
                foreach(FieldObject field in form.CurrentRow.Fields)
                {
                    switch(field.FieldNumber)
                    {
                        case typeOfAdmissionFieldId:
                            typeOfAdmission = int.Parse(field.FieldValue);                                              // TODO Convert.ToInt()?
                            foundPreAdmitToAdmissionDateField = true;
                            break;

                        case preAdmitToAdmissionDateFieldId:
                            preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);
                            foundTypeOfAdmissionField = true;
                            break;

                        default:
                            break;
                    }

                    /* If we've found everything we need, we'll stop searching for stuff.
                     */
                    if(foundPreAdmitToAdmissionDateField && foundTypeOfAdmissionField)
                    {
                        break;
                    }
                }
            }

            var systemDate = new DateTime(1900, 1, 1);                                                    // TODO Why not define this in the line below?
            systemDate = DateTime.Today;
            var errMsgBody = string.Empty;
            var errMsgCode = 0;

            /* If the "Admission Type" is set to "Pre-Admission" and the "Pre-Admission Date" is not the same as the
             * system date, the errMsgCode will be set to "1", and a pop-up will notify the user that they need to
             * modify the Pre-Admission Date field to equal the system time, and the user will be returned to the form
             * to modify the Pre-Admission Date.
             *
             * If you just want to warn the user that the "Pre-Admission Date" is not the same as the  system date (and
             * not force them to modify it), you can change the following line of code:
             *
             *  errMsgCode = 1;
             *
             * to:
             *
             *  errMsgCode = 4;
             *
             * If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the same
             * as the system date, the errMsgCode remains "0", and the form is submitted normally.
             */
            if(typeOfAdmission == preAdmissionHardcodedValue)
            {
                if(preAdmitToAdmissionDate != systemDate)
                {
                    errMsgBody = "WARNING\nThe client's pre-admission date does not match today's date!";
                    errMsgCode = 1;
                }
            }

            var verifyAdmitDateOptionObject2015 = new OptionObject2015();

            if(errMsgCode != 0)
            {
                verifyAdmitDateOptionObject2015.ErrorCode = errMsgCode;
                verifyAdmitDateOptionObject2015.ErrorMesg = errMsgBody;

                /* Uncomment this line to overide the "nice" error message with detailed information users don't need to
                 * see, which may be usefull when testing.
                 */
                verifyAdmitDateOptionObject2015.ErrorMesg = $"[ERROR]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
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
            var logFileContent = $"preAdmissionHardcodedValue={preAdmissionHardcodedValue}{Environment.NewLine}" +
                                 $"typeOfAdmissionFieldId={typeOfAdmissionFieldId}{Environment.NewLine}" +
                                 $"preAdmitToAdmissionDateFieldId={preAdmitToAdmissionDateFieldId}{Environment.NewLine}" +
                                 $"typeOfAdmission={typeOfAdmission}{Environment.NewLine}" +
                                 $"preAdmitToAdmissionDate={preAdmitToAdmissionDate}{Environment.NewLine}" +
                                 $"foundTypeOfAdmissionField={foundTypeOfAdmissionField}{Environment.NewLine}" +
                                 $"foundPreAdmitToAdmissionDateField={foundPreAdmitToAdmissionDateField}{Environment.NewLine}" +
                                 $"errMsgBody={verifyAdmitDateOptionObject2015.ErrorMesg}{Environment.NewLine}" +
                                 $"errMsgCode={verifyAdmitDateOptionObject2015.ErrorCode}{Environment.NewLine}";
            Logger.WriteToTimestampedFile("InptAdmitDate.ComparePreAdmitToAdmit", logFileContent);

            return verifyAdmitDateOptionObject2015;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sentOptionObject2015"></param>
        /// <returns></returns>
        private static OptionObject2015 ComparePreAdmitToAdmit_Testing(OptionObject2015 sentOptionObject2015)
        {
            var verifyAdmitDateOptionObject2015 = new OptionObject2015();

            // This is a placeholder method in the event that ComparePreAdmitToAdmit() is modified. IF that's the case,
            // copy the contents of ComparePreAdmitToAdmit() here.

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