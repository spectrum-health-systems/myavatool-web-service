<!--
  Software manual template (b210104)
  https://github.com/APrettyCoolProgram/my-development-environment/tree/master/templates/documentation
-->

<h1 align="center">

  <img src="../../resources/asset/img/logo/maws-logo-800x150.png" alt="myAvatar Web Service logo" width="800">
  <br>
  MANUAL
  <br>

</h1>

<h5 align="center">

  [ABOUT MAWS](manual.md)&nbsp;&bull;&nbsp;[HOSTING MAWS](manual-hosting-maws.md)&nbsp;&bull;&nbsp;[IMPORTING MAWS](manual-importing-maws.md)&nbsp;&bull;&nbsp;[SCRIPTLINK EVENTS](manual-scriptlink-events.md)&nbsp;&bull;&nbsp;MAWS CALLS&nbsp;&bull;&nbsp;[CUSTOM MYAVATAR WEB SERVICES](manual-custom-myavatar-web-services.md)

</h5>

***

# ABOUT MAWS METHOD CALLS
The main function of MAWS is to perform an `action` (i.e., a MAWS method call) using data that is received from myAvatar via an *OptionObject2*.
 
Each `action` has a *class* with the same name. For example, the `VerifyInpatientAdmissionDate` action is performed by methods in the *VerifyInpatientAdmissionDate.cs* class.

To perform an `action`, you'll need to create a ScriptLink event in myAvatar that passes both an "action" and an *OptionObject2* to MAWS. For more information about creating ScriptLink events, please see the MAWS [manual](manual-scriptlink-events).

# STANDARD METHODS
These are the standard methods that are required by myAvatar.

## GetVersion()
> This method is required by myAvatar, and cannot be removed from MAWS.

### What the `GetVersion()` method does:
* Returns the MAWS version string (e.g., "Version 1.0").

The version should be the same as the development branch. For example, if you are developing version 2.1 of MAWS, the `GetVersion()` method should return "Version 2.1", even if the actual version of the sourcecode is different.

## RunScript()
> This method is required by myAvatar, and cannot be removed from MAWS.

### What the `RunScript()` method does:
* Performs a MAWS action (e.g., "Version 1.0").

The `RunScript()` method is the only MAWS method that myAvatar works with directly. The `RunScript()` method both calls the action myAvatar requests, and returns the result of that action to myAvatar.

The `RunScript()` method receives an OptionObject2 object and an "action" string from myAvatar, then uses a switch statement to pass the OptionObject2 object and action to the local method that will process the action.

If an invalid action is passed, the the OptionObject2 is returned without any changes being made.

# ACTIONS
These are the valid actions that MAWS can do.

Each "action" has:
1. A method in MyAvatoolWebService.asmx.cs, used to do any necessary pre-processing
2. A seperate class in MAWS, used to do the actual work for the action For example, if you call the "VerifyInpatientAdmissionDate" action, the following occurs:
3. The MyAvatoolWebService.asmx.cs.RunScript() method receives both the OptionObject2, and the "VerifyInpatientAdmissionDate" action
4. The "MyAvatoolWebService.asmx.cs.VerifyInpatientAdmissionDate()" method is called, passing the OptionObject2 object, as well as any necessary parameters
5. The "MyAvatoolWebService.asmx.cs.VerifyInpatientAdmissionDate()" method does any necessary pre-processing
6. The "MyAvatoolWebService.asmx.cs.VerifyInpatientAdmissionDate()" method calls the "MyAvatoolWebService.VerifyInpatientAdmissionDate.cs.<method-name>() method, which does the work requested by the action

To perform an "action", you'll need to create a ScriptLink event in myAvatar that passes both an "action" and an OptionObject2 to MAWS.

For more information about creating ScriptLink events, please see the MAWS [manual](
https://github.com/spectrum-health-systems/myavatool-web-service/blob/main/doc/man/manual-scriptlink-events.md)

## VerifyInpatientAdmissionDate
Verify that the Inpatient Admission Date is the same as the system current date.

This method verifies that an existing Pre-Admission date is the same as the system date.

Here is how it works:
* When a completed Admission form is submitted, we check to if the "Admission Type" is "Pre-Admission".
* If the "Admission Type" is set to  "Pre-Admission" and the "Pre-Admission Date" is not the same as the system date, a pop-up will notify the user that they need to modify the Pre-Admission Date field  to equal the system time, and the user will be returned to the form to modify the Pre-Admission Date.
* If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the same as the system date, the form is submitted normally.