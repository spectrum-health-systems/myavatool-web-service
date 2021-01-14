/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.InptAdmitDate.cs
 * UPDATED: 1-14-2021-10:23 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* For detailed information about the InptAdmitDate class, please see the MAWS manual:
 *  https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual-maws-calls.md#inptadmitdate
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
            /* For detailed information about MyAvatoolWebService.InptAdmitDate.Parser(), please see the MAWS manual:
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

        /// <summary></summary>
        /// <param name="sentOptionObject2"></param>
        /// <returns></returns>
        private static OptionObject2 VerifyPreAdmitDate(OptionObject2 sentOptionObject2)
        {
            /* For detailed information about MyAvatoolWebService.InptAdmitDate.Parser(), please see the MAWS manual:
             *  https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual-maws-calls.md#inptadmitdate
             */

            const string typeOfAdmissionField         = "44";
            const string preAdmitToAdmissionDateField = "42";
            const int    preAdmission                 = 3;
            var typeOfAdmission                       = 0;
            var preAdmitToAdmissionDate               = new DateTime(1900, 1, 1);

            foreach(FormObject form in sentOptionObject2.Forms)
            {
                foreach(FieldObject field in form.CurrentRow.Fields)
                {
                    switch(field.FieldNumber)
                    {
                        case typeOfAdmissionField:
                            typeOfAdmission = int.Parse(field.FieldValue);                                               // TODO Convert.ToInt()?
                            break;

                        case preAdmitToAdmissionDateField:
                            preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);
                            break;

                        default:
                            break;
                    }
                }
            }

            var systemDate       = new DateTime(1900, 1, 1);                                               // TODO Why not define this in the line below?
            systemDate = DateTime.Today;
            var errorMessageBody = string.Empty;
            var errorMessageCode = 0;

            if(typeOfAdmission == preAdmission)
            {
                if(preAdmitToAdmissionDate != systemDate)
                {
                    errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date!";
                    errorMessageCode = 1;
                }
            }

            var verifyAdmitDateOptionObject2 = new OptionObject2();

            if(errorMessageCode != 0)
            {
                verifyAdmitDateOptionObject2.ErrorCode = errorMessageCode;
                verifyAdmitDateOptionObject2.ErrorMesg = errorMessageBody;

                //// DEBUGGING ONLY
                //returnOptionObject.ErrorCode = errorMessageCode;
                //returnOptionObject.ErrorMesg = "[ERROR]\nError Code: " + errorMessageCode + "Type of admission: " + typeOfAdmission + "\n" + "PreAdmit Date: " + preAdmitToAdmissionDate + "System Date: " + systemDate;
            }

            return verifyAdmitDateOptionObject2;
        }
    }
}