/* PROJECT: InptAdmitDate (https://github.com/aprettycoolprogram/InptAdmitDate)
 *    FILE: InptAdmitDate.Compare.cs
 * UPDATED: 7-2-2021-10:19 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* Logic for the Compare action of the InptAdmitDate command.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace InptAdmitDate
{
    public class Compare
    {
        /// <summary>
        /// Verifies that client's Pre-Admission date is the same as the system date.
        /// </summary>
        /// <param name="sentOptionObject2">The OptionObject2015 object sent from myAvatar.</param>
        /// <returns>An OptionObject2015 object with the data.</returns>
        /// <remarks>This method is called by the "InptAdmitDate-ComparePreAdmitToAdmit" mawsRequest.</remarks>
        public static OptionObject2015 PreAdmitToAdmit(OptionObject2015 sentOptionObject, Dictionary<string, string> inptAdmitDateSetting)
        {
            var logSetting                                   = inptAdmitDateSetting["Logging"].ToLower();
            var assemblyName                                 = Assembly.GetExecutingAssembly().GetName().Name;

            // You may need to modify these values to match the fieldIDs for your organization.
            const int    preAdmissionHardcodedValue        = 3;
            const string typeOfAdmissionFieldId            = "44";
            const string preAdmitToAdmissionDateFieldId    = "42";
            var          typeOfAdmission                   = 0;
            var          preAdmitToAdmissionDate           = new DateTime(1900, 1, 1);
            var          foundTypeOfAdmissionField         = false;
            var          foundPreAdmitToAdmissionDateField = false;

            var initializedValuesMessage = $"InptAdmitDate.Compare.PreAdmitToAdmit() initial values:{Environment.NewLine}" +
                                           $"preAdmissionHardcodedValue={preAdmissionHardcodedValue}{Environment.NewLine}" +
                                           $"typeOfAdmissionFieldId={typeOfAdmissionFieldId}{Environment.NewLine}" +
                                           $"preAdmitToAdmissionDateFieldId={preAdmitToAdmissionDateFieldId}{Environment.NewLine}" +
                                           $"typeOfAdmission={typeOfAdmission}{Environment.NewLine}" +
                                           $"preAdmitToAdmissionDate={preAdmitToAdmissionDate}{Environment.NewLine}" +
                                           $"foundTypeOfAdmissionField={foundTypeOfAdmissionField}{Environment.NewLine}" +
                                           $"foundPreAdmitToAdmissionDateField={foundPreAdmitToAdmissionDateField}";
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, initializedValuesMessage);

            var completedAdmitDateOptionObject = new OptionObject2015();

            if(sentOptionObject.Forms == null)
            {
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "sentOptionObject is null");
            }
            else
            {
                /* 01 */
                foreach(FormObject form in sentOptionObject.Forms)
                {
                    foreach(FieldObject field in form.CurrentRow.Fields)
                    {
                        switch(field.FieldNumber)
                        {
                            case typeOfAdmissionFieldId:
                                typeOfAdmission = int.Parse(field.FieldValue);
                                foundPreAdmitToAdmissionDateField = true;
                                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found PreAdmitToAdmissionDateField.");
                                break;

                            case preAdmitToAdmissionDateFieldId:
                                preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);
                                foundTypeOfAdmissionField = true;
                                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Found TypeOfAdmissionField.");
                                break;

                            default:
                                LogEvent.Timestamped(logSetting, "ERROR", assemblyName, "Required fields not found.");
                                break;
                        }

                        if(foundPreAdmitToAdmissionDateField && foundTypeOfAdmissionField)
                        {
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "PreAdmitToAdmissionDateField and TypeOfAdmissionField fields found.");
                            break;
                        }
                    }

                    if(foundPreAdmitToAdmissionDateField && foundTypeOfAdmissionField)
                    {
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "PreAdmitToAdmissionDateField and TypeOfAdmissionField fields found.");
                        break;
                    }
                }

                //_ = new DateTime(1900, 1, 1);                                                    // TODO Why not define this in the line below?
                DateTime systemDate = DateTime.Today;

                var verifyAdmitDateOptionObject = new OptionObject2015
                {
                    ErrorCode = 0,
                    ErrorMesg = ""
                };
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Initialized verifyAdmitDateOptionObject.");

                //var errMsgBody      = "";
                //var errMsgCode      = 0;

                /* 02 */
                if(typeOfAdmission == preAdmissionHardcodedValue)
                {
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Client admission type is \"PreAdmit\".");
                    if(preAdmitToAdmissionDate != systemDate)
                    {
                        verifyAdmitDateOptionObject.ErrorCode = 1;
                        verifyAdmitDateOptionObject.ErrorMesg = "WARNING\nThe client's pre-admission date does not match today's date!";
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Client pre-admission date does not match today's date.");
                    }
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Client pre-admission date does match today's date.");
                }
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Client admission type is not \"PreAdmit\".");

                //var verifyAdmitDateOptionObject = new OptionObject2015
                //{
                //    ErrorCode = errMsgCode,
                //    ErrorMesg = errMsgBody
                //};
                //Logger.Timestamped.LogEvent(inptAdmitDateSetting["Logging"].ToLower(), "TRACE", Assembly.GetExecutingAssembly().GetName().Name, "Initialized verifyAdmitDateOptionObject.");

                if(verifyAdmitDateOptionObject.ErrorCode != 0)
                {
                    //verifyAdmitDateOptionObject.ErrorCode = errMsgCode;
                    //verifyAdmitDateOptionObject.ErrorMesg = errMsgBody;
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "errMsg code is not \"0\" ({errMsgCode})");
                }
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "errMsg code is \"0\"");

                var errorDetailsMessage = $"InptAdmitDate.Compare.PreAdmitToAdmit() errMsg details:{Environment.NewLine}" +
                                          $"ErrorCode={verifyAdmitDateOptionObject.ErrorCode}{Environment.NewLine}" +
                                          $"ErrorMesg={verifyAdmitDateOptionObject.ErrorMesg}";
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, errorDetailsMessage);

                /* When this block of code is uncommented, a pop-up with detailed information will be displayed when the
                 * errMsgCode is "0", meaning no issues were found, and the form will being submitted normally.
                 *
                 * This is useful when debugging, but normally it should be commented out.
                 */
                //if (errMsgCode == 0)
                //{
                //    verifyAdmitDateOptionObject2.ErrorCode = 4;
                //    verifyAdmitDateOptionObject2.ErrorMesg = "[DEBUG]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
                //}

                completedAdmitDateOptionObject = TheOptionObject.Finalize.WhichComponents(sentOptionObject, verifyAdmitDateOptionObject, true, false);
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Finalized OptionObject.");
            }
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Returning OptionObject.");

            return completedAdmitDateOptionObject;
        }
    }
}


/* =================
 * DEVELOPMENT NOTES
 * =================
 *
 * 01
*  We will loop through each field of every form in sentOptionObject2, and do something special if we land
* on the "typeOfAdmissionField" or "preAdmitToAdmissionDateField".
*
*
* 02
* If the "Admission Type" is set to "Pre-Admission" and the "Pre-Admission Date" is not the same as the
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
*
 */