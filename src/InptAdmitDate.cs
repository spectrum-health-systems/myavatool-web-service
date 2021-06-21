/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.InptAdmitDate.cs
 * UPDATED: 6-21-2021-9:12 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* InptAdmitDate command logic.
 *
 * Development notes/comments can be found at the end of this class.
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
        /// <param name="mawsRequest">         The MAWS request string.</param>
        /// <returns></returns>
        public static OptionObject2015 ExecuteAction(OptionObject2015 sentOptionObject2015, string mawsRequest)
        {
            var inptAdmitDateOptionObject = new OptionObject2015();
            var requestAction             = RequestSyntaxEngine.GetRequestAction(mawsRequest);
            var requestOption             = RequestSyntaxEngine.GetRequestOption(mawsRequest);

            switch(requestAction)
            {
                case "comparepreadmittoadmit":
                    inptAdmitDateOptionObject = requestOption == "testing"
                        ? ComparePreAdmitToAdmit_Testing(sentOptionObject2015)
                        : ComparePreAdmitToAdmit(sentOptionObject2015);
                    break;

                default:
                    // Log this event
                    var logFileContent = $"[ERROR]{Environment.NewLine}" +
                                         $"request action \"{requestAction}\" is not valid.{Environment.NewLine}";
                    Logger.WriteToTimestampedFile("[ERROR]InptAdmitDate.ExecuteAction", logFileContent);
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
        /// Verifies that client's Pre-Admission date is the same as the system date (TESTING VERSION)
        /// </summary>
        /// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        /// <returns>An OptionObject2 object with the data.</returns>
        /// <remarks>This method is used to test ComparePreAdmitToAdmit functionality.</remarks>
        private static OptionObject2015 ComparePreAdmitToAdmit_Testing(OptionObject2015 sentOptionObject2015)
        {
            return sentOptionObject2015;
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
 * - MAWS Request commands/actions/options are converted to lowercase before we look at them. This way if the you put
 *   an incorrectly-cased MAWS Request in a form's ScriptLink event, it will still work when that request is submitted
 *   to MAWS. On the flip-side, it's a bit harder to read the code. Since the majority of the users will only see the
 *   myAvatar side of things, that's a tradeoff I'm ok making.
 *
 * - A "_Testing" postfix is applied to methods that are used to test functionality without impacting current
 *   functionality. I know that using underscores in methods isn't best practice, but this seems to be the best way to
 *   indicate a method is for testing only.
 *
 * - The original ComparePreAdmitToAdmit() method was written (and used in production) prior to the changes made to how
 *   MAWS Requests are handled. In theory, no other changes will need to be made to ComparePreAdmitToAdmit(), so there
 *   isn't a ComparePreAdmitToAdmit_Testing() method. But since the standart going forward will be for all methods to
 *   have a "_Testing" version, there is a placeholder ComparePreAdmitToAdmit_Testing() method that doesn't do anything.
 *
 *
 *
 * - For information about this sourcecode, please see:
 *      https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/development/src/Resources/Doc/development.md
 */