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








*
* MAWS currently supports the following actions:
*
*      VerifyInpatientAdmissionDate: Verify that the Inpatient Admission Date is the same as the system current date.
*    