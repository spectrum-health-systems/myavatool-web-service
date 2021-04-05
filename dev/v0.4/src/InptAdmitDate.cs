/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.InptAdmitDate.cs
 * UPDATED: 2-4-2021-10:08 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* For detailed information about the InptAdmitDate class, please see the MAWS manual:
 *  https://
 */

using System;

using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    /// <summary></summary>
    public class InptAdmitDate
    {
        /// <summary></summary>
        /// <param name="sentOptionObject2"></param>
        /// <param name="mawsRequest">      </param>
        /// <returns></returns>
        public static OptionObject2 Parser(OptionObject2 sentOptionObject2, string mawsRequest)
        {
            /* This method parses.
             *
             * For detailed information about InptAdmitDate.Parser(), please see the MAWS manual:
             *  https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual-maws-calls.md#inptadmitdate
             */

            var inptAdmitDateOptionObject2 = new OptionObject2();

            if(mawsRequest.Contains("-VerifyPreAdmitDate"))
            {
                inptAdmitDateOptionObject2 = VerifyPreAdmitDate(sentOptionObject2);
            }
            else
            {
                // Logic for other things.
            }

            return inptAdmitDateOptionObject2;
        }

        /// <summary>Verifies that client's Pre-Admission date is the same as the system date.</summary>
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <returns>An OptionObject2 object with the data.</returns>
        /// <remarks>This method is called by the "InptAdmitDate-VerifyPreAdmitDate" mawsRequest.</remarks>
        private static OptionObject2 VerifyPreAdmitDate(OptionObject2 sentOptionObject2)
        {
            /* For detailed information about InptAdmitDate.VerifyPreAdmitDate(), please see the MAWS manual:
             *  https://
             */

            /* You will need to modify these values to match the fieldIDs for your organization.
             */
            const int    preAdmission                 = 3;
            const string typeOfAdmissionField         = "44";
            const string preAdmitToAdmissionDateField = "42";

            var typeOfAdmission                       = 0;
            var preAdmitToAdmissionDate               = new DateTime(1900, 1, 1);

            var foundTypeOfAdmissionField             = false;
            var foundPreAdmitToAdmissionDateField     = false;

            /* We will loop through each field of every form in sentOptionObject2, and do something special if we land on
             * the "typeOfAdmissionField" or "preAdmitToAdmissionDateField".
             */
            foreach(FormObject form in sentOptionObject2.Forms)
            {
                foreach(FieldObject field in form.CurrentRow.Fields)
                {
                    switch(field.FieldNumber)
                    {
                        case typeOfAdmissionField:
                            typeOfAdmission = int.Parse(field.FieldValue);                                               // TODO Convert.ToInt()?
                            foundPreAdmitToAdmissionDateField = true;
                            break;

                        case preAdmitToAdmissionDateField:
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

            var systemDate = new DateTime(1900, 1, 1);                                                     // TODO Why not define this in the line below?
            systemDate = DateTime.Today;
            var errMsgBody = string.Empty;
            var errMsgCode = 0;

            /* If the "Admission Type" is set to "Pre-Admission" and the "Pre-Admission Date" is not the same as the
             * system date, the errMsgCode will be set to "1", and a pop-up will notify the user that they need to modify
             * the Pre-Admission Date field to equal the system time, and the user will be returned to the form to modify
             * the Pre-Admission Date.
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
            if(typeOfAdmission == preAdmission)
            {
                if(preAdmitToAdmissionDate != systemDate)
                {
                    errMsgBody = "WARNING\nThe client's pre-admission date does not match today's date!";
                    errMsgCode = 1;
                }
            }

            var verifyAdmitDateOptionObject2 = new OptionObject2();

            if(errMsgCode != 0)
            {
                verifyAdmitDateOptionObject2.ErrorCode = errMsgCode;
                verifyAdmitDateOptionObject2.ErrorMesg = errMsgBody;

                /* Uncomment this line to overide the "nice" error message with detailed information users don't need to
                 * see, which may be usefull when testing.
                 */
                verifyAdmitDateOptionObject2.ErrorMesg = $"[ERROR]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
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

            return verifyAdmitDateOptionObject2;
        }
    }
}