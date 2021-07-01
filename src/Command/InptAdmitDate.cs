using System;
using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace Command
{
    public class InptAdmitDate
    {
        ///// <summary>
        ///// Executes a MAWS action for the InptAdmitDate command.
        ///// </summary>
        ///// <param name="sentOptionObject2015">The original OptionObject2015 sent from myAvatar.</param>
        ///// <param name="mawsRequest">         The MAWS Request string.</param>
        ///// <returns>A completed OptionObject2015.</returns>
        //public static OptionObject2015 ExecuteAction(OptionObject2015 sentOptionObject2015, string mawsRequest)
        //{
        //    var mawsAction                = RequestSyntaxEngine.RequestComponent.GetAction(mawsRequest);
        //    var mawsOption                = RequestSyntaxEngine.RequestComponent.GetOption(mawsRequest);
        //    var inptAdmitDateOptionObject = new OptionObject2015();
        //    Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Execute InptAdmitDate Action: {mawsAction} [Option={mawsOption}]");

        //    switch(mawsAction)
        //    {
        //        case "comparepreadmittoadmit":
        //            Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"Executing InptAdmitDate Action: comparepreadmittoadmit [Option={mawsOption}]");
        //            inptAdmitDateOptionObject = mawsOption == "testing"
        //                ? ComparePreAdmitToAdmit_Testing(sentOptionObject2015)
        //                : ComparePreAdmitToAdmit(sentOptionObject2015);
        //            break;

        //        default:
        //            Logger.Timestamped.WriteToFile("ERROR", Assembly.GetExecutingAssembly().GetName().Name, $"Invalid InptAdmitDate Action: \"{mawsAction}\"");
        //            break;
        //    }

        //    return inptAdmitDateOptionObject;
        //}

        ///// <summary>
        ///// Verifies that client's Pre-Admission date is the same as the system date.
        ///// </summary>
        ///// <param name="sentOptionObject2">The OptionObject2015 object sent from myAvatar.</param>
        ///// <returns>An OptionObject2015 object with the data.</returns>
        ///// <remarks>This method is called by the "InptAdmitDate-ComparePreAdmitToAdmit" mawsRequest.</remarks>
        //private static OptionObject2015 ComparePreAdmitToAdmit(OptionObject2015 sentOptionObject)
        //{
        //    // You may need to modify these values to match the fieldIDs for your organization.
        //    const int    preAdmissionHardcodedValue     = 3;
        //    const string typeOfAdmissionFieldId         = "44";
        //    const string preAdmitToAdmissionDateFieldId = "42";

        //    var typeOfAdmission                       = 0;
        //    var preAdmitToAdmissionDate               = new DateTime(1900, 1, 1);

        //    var foundTypeOfAdmissionField             = false;
        //    var foundPreAdmitToAdmissionDateField     = false;

        //    Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"{ preAdmissionHardcodedValue} - { typeOfAdmissionFieldId} - { preAdmitToAdmissionDateFieldId} - { typeOfAdmission} - { preAdmitToAdmissionDate} - { foundTypeOfAdmissionField} - { foundPreAdmitToAdmissionDateField}");

        //    var completedAdmitDateOptionObject = new OptionObject2015();

        //    if(sentOptionObject.Forms == null)
        //    {
        //        Logger.Timestamped.WriteToFile("ERROR", Assembly.GetExecutingAssembly().GetName().Name, "sentOptionObject is null");
        //    }
        //    else
        //    {
        //        /* We will loop through each field of every form in sentOptionObject2, and do something special if we land
        //         * on the "typeOfAdmissionField" or "preAdmitToAdmissionDateField".
        //         */
        //        foreach(FormObject form in sentOptionObject.Forms)
        //        {
        //            foreach(FieldObject field in form.CurrentRow.Fields)
        //            {
        //                switch(field.FieldNumber)
        //                {
        //                    case typeOfAdmissionFieldId:
        //                        typeOfAdmission = int.Parse(field.FieldValue);                                              // TODO Convert.ToInt()?
        //                        foundPreAdmitToAdmissionDateField = true;
        //                        Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"{field.FieldNumber} - {typeOfAdmission} - {foundPreAdmitToAdmissionDateField}");
        //                        break;

        //                    case preAdmitToAdmissionDateFieldId:
        //                        preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);
        //                        foundTypeOfAdmissionField = true;
        //                        Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"{field.FieldNumber} - {preAdmitToAdmissionDate} - {foundTypeOfAdmissionField}");
        //                        break;

        //                    default:
        //                        Logger.Timestamped.WriteToFile("ERROR", Assembly.GetExecutingAssembly().GetName().Name, "No fields found.");
        //                        break;
        //                }

        //                /* If we've found everything we need, we'll stop searching for stuff.
        //                 */
        //                if(foundPreAdmitToAdmissionDateField && foundTypeOfAdmissionField)
        //                {
        //                    Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, "preAdmitToAdmissionDateField and typeOfAdmissionField fields found, exiting foreach...");
        //                    break;
        //                }
        //            }
        //        }

        //        //_ = new DateTime(1900, 1, 1);                                                    // TODO Why not define this in the line below?
        //        DateTime systemDate = DateTime.Today;

        //        var errMsgBody = string.Empty;
        //        var errMsgCode = 0;

        //        /* If the "Admission Type" is set to "Pre-Admission" and the "Pre-Admission Date" is not the same as the
        //         * system date, the errMsgCode will be set to "1", and a pop-up will notify the user that they need to
        //         * modify the Pre-Admission Date field to equal the system time, and the user will be returned to the form
        //         * to modify the Pre-Admission Date.
        //         *
        //         * If you just want to warn the user that the "Pre-Admission Date" is not the same as the  system date (and
        //         * not force them to modify it), you can change the following line of code:
        //         *
        //         *  errMsgCode = 1;
        //         *
        //         * to:
        //         *
        //         *  errMsgCode = 4;
        //         *
        //         * If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the same
        //         * as the system date, the errMsgCode remains "0", and the form is submitted normally.
        //         */
        //        if(typeOfAdmission == preAdmissionHardcodedValue)
        //        {
        //            if(preAdmitToAdmissionDate != systemDate)
        //            {
        //                Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, "Dates do not match.");
        //                errMsgBody = "WARNING\nThe client's pre-admission date does not match today's date!";
        //                errMsgCode = 1;
        //            }
        //        }

        //        var verifyAdmitDateOptionObject = new OptionObject2015
        //        {
        //            ErrorCode = errMsgCode,
        //            ErrorMesg = errMsgBody
        //        };

        //        if(errMsgCode != 0)
        //        {
        //            verifyAdmitDateOptionObject.ErrorCode = errMsgCode;
        //            verifyAdmitDateOptionObject.ErrorMesg = errMsgBody;

        //            /* Uncomment this line to overide the "nice" error message with detailed information users don't need to
        //             * see, which may be usefull when testing.
        //             */
        //            verifyAdmitDateOptionObject.ErrorMesg = $"[ERROR]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
        //        }

        //        Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"{verifyAdmitDateOptionObject.ErrorCode} - {verifyAdmitDateOptionObject.ErrorMesg}");

        //        /* When this block of code is uncommented, a pop-up with detailed information will be displayed when the
        //         * errMsgCode is "0", meaning no issues were found, and the form will being submitted normally.
        //         *
        //         * This is useful when debugging, but normally it should be commented out.
        //         */
        //        //if (errMsgCode == 0)
        //        //{
        //        //    verifyAdmitDateOptionObject2.ErrorCode = 4;
        //        //    verifyAdmitDateOptionObject2.ErrorMesg = "[DEBUG]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
        //        //}

        //        Logger.Timestamped.WriteToFile("DEBUG-TRACE", Assembly.GetExecutingAssembly().GetName().Name, $"{preAdmissionHardcodedValue} - {typeOfAdmissionFieldId} - {preAdmitToAdmissionDateFieldId} - {typeOfAdmission} - {preAdmitToAdmissionDate} - {foundTypeOfAdmissionField} - {foundPreAdmitToAdmissionDateField} - {verifyAdmitDateOptionObject.ErrorMesg} - {verifyAdmitDateOptionObject.ErrorCode}");

        //        completedAdmitDateOptionObject = TheOptionObject.Finalize.WhichComponents(sentOptionObject, verifyAdmitDateOptionObject, true, false);
        //    }

        //    return completedAdmitDateOptionObject;
        //}

        ///// <summary>
        ///// Verifies that client's Pre-Admission date is the same as the system date (TESTING VERSION)
        ///// </summary>
        ///// <param name="sentOptionObject2">The OptionObject2 object sent from myAvatar.</param>
        ///// <returns>An OptionObject2 object with the data.</returns>
        ///// <remarks>This method is used to test ComparePreAdmitToAdmit functionality.</remarks>
        //private static OptionObject2015 ComparePreAdmitToAdmit_Testing(OptionObject2015 sentOptionObject2015)
        //{
        //    return sentOptionObject2015;
        //}
    }
}
