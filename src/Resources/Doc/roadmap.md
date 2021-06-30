# MAWS Roadmap

## Version 0.xx
> Compartmentalized DLLs

## Version 0.11
> Dose command functionality


    * ComparePreAdmitToAdmit(OptionObject2015 sentOptionObject2015)

            const int    preAdmissionHardcodedValue     = 3;
            const string typeOfAdmissionFieldId         = "44";
            const string preAdmitToAdmissionDateFieldId = "42";

            var typeOfAdmission                       = 0;
            var preAdmitToAdmissionDate               = new DateTime(1900, 1, 1);

            var foundTypeOfAdmissionField             = false;
            var foundPreAdmitToAdmissionDateField     = false;

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

                    if(foundPreAdmitToAdmissionDateField && foundTypeOfAdmissionField)
                    {
                        break;
                    }
                }
            }

            var systemDate = new DateTime(1900, 1, 1);                                                    // TODO Why not define this in the line below?
            systemDate = DateTime.Today;

            var verifyAdmitDateOptionObject = new OptionObject2015
            {
                ErrorCode = 0,
                ErrorMsg = ""
            };

            if(typeOfAdmission == preAdmissionHardcodedValue)
            {
                if(preAdmitToAdmissionDate != systemDate)
                {
                    verifyAdmitDateOptionObject.ErrorCode = 1;
                    verifyAdmitDateOptionObject.ErrorMsg  = "WARNING\nThe client's pre-admission date does not match today's date!";
                }
            }

            if(errMsgCode != 0)
            {
                // LOG EVENT
            }

            /* When this block of code is uncommented, a pop-up with detailed information will be displayed when the
             * errMsgCode is "0", meaning no issues were found, and the form will being submitted normally.
             *
             * This is  useful when debugging, but normally it should be commented out.
             */
            //if (errMsgCode == 0)
            //{
            // LOG EVENT
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



* maws.settings file
    * allows blank lines
    * blank line at end stripped
    * log directory

* log maintenance


* Figure out a way to confirm that "/MAWS/Logs/" and "/MAWS/maws.settings" exists just one time, not every time

* Confirm all references to *OptionObject2* are replaced with *OptionObject2015*

* OptionObjectMaintenance.cs
    * Do we/should we to return the "finalizedOptionObject" from each method? Currently we don't, and things work, but it may be clearer if we break things down a bit
    * Where did we get required/recommended/notrecommended from?
    * OptionObjectMaintenance.Finalize()
        * This method, and the methods it calls, should be more efficient. Currently it relies on brute force.
        * Maybe do the work with a "workerOptionObject", then at the end copy that over to "finalizedOptionObject"

* documentation
    * other projects
    * OO2

* Other abbreviations:
    * Outpatient = outpt 

* Why not JSON?

* Allow "ForceTest" to be sent to force testing/logging

* Notes on logging

* Put [DEBUG] and [ERROR] logs in their own folder?

* Do the $"{}" thing with strings

* Manual
  * How to test functionality while developing via ForceTest()
  * Update docs with standard ids
  * manual-hosting-maws.md
    * instruction on where to put the files/how to publish
    * updating MAWS
    * Disabling MAWS
    * has to be https
  * Update manual to reflect the local methods being removed.
      * Main asmx is just the required methods now
      * All actions are external classes
  * InptAdmitDate.cs
      * Parser, DefineFieldIds, etc all under main

* Test:
    * Passing an invalid command/action/option