


## INPATIENT ADMISSION DATE
The current version of MAWS supports the following `InptAdmitDate` commands: 
### VerifyPreAdmitDate
Verify that the Inpatient Admission Date is the same as the system current date.

This method verifies that an existing Pre-Admission date is the same as the system date.

Here is how it works:
* When a completed Admission form is submitted, we check to if the "Admission Type" is "Pre-Admission".
* If the "Admission Type" is set to  "Pre-Admission" and the "Pre-Admission Date" is not the same as the system date, a pop-up will notify the user that they need to modify the Pre-Admission Date field  to equal the system time, and the user will be returned to the form to modify the Pre-Admission Date.
* If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the same as the system date, the form is submitted normally.


            /* These are the valid Error Codes that can be used with myAvatar:
             *  1: Returns an Error Message and stops further processing of scripts (if set)
             *  2: Returns an Error Message with OK/Cancel buttons (further scripts are stopped if Cancelled)
             *  3: Returns an Error Message with OK button
             *  4: Returns an Error Message with Yes/No buttons (further scripts are stopped if No)
             *  5: Returns a URL to be opened in a new browser
             *
             * We are interested in Error Codes 1 and 4, the default being Error Code 1.
             *
             * Use Error Code 1 if you want to force the user to fix the date issue prior to submitting the form. Keep
             * in mind that when using this Error Code, the form cannot be submitted until the Pre-Admission Date
             * matches the system date.
             *
             * Use Error Code 4 to allow the user to ignore the date issue, and submit the form with different dates.
             */