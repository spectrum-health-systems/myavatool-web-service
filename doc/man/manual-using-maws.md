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

  MAWS v0.7&nbsp;&bull;&nbsp;Last updated: April 6th, 2021

</h5>

<h4 align="center">

  [INTRODUCTION](manual-introduction.md)&nbsp;&bull;&nbsp;[HOSTING MAWS](manual-hosting-maws.md)&nbsp;&bull;&nbsp;[IMPORTING MAWS](manual-importing-maws.md)&nbsp;&bull;&nbsp;USING MAWS&nbsp;&bull;&nbsp;[CUSTOM MYAVATAR™ WEB SERVICES](manual-custom-myavatar-web-services.md)

</h4>

***

<!-- The HTML indentations have to stay this way to work. -->
<table>
<tr>
<td img src="resources/asset/img/doc/readme/spacer.png" alt="blank-spacer" width="1000" height="1">

  ### CONTENTS
  [OVERVIEW](#using-overview)<br>
  [USING MICROSOFT IIS TO HOST MAWS](#using-microsoft-iis-to-host-maws)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[CREATING AN APPLICATION POOL](#creating-an-application-pool)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[CREATING A NEW SITE](#creating-a-new-site)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[INSTALLING THE ASP.NET ROLE](#installing-the-aspnet-role)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[DISABLING THE DEFAULT SITE](#disabling-the-default-site)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[ENABLING DIRECTORY BROWSING](#enabling-directory-browsing)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[VERIFYING THE NEW SITE](#verifying-the-new-site)<br>

</td>
</tr>
</table>

# OVERVIEW
Once you have [hosted](manual-hosting-maws.md) MAWS and [imported](manual-importing-maws.md) it into your myAvatar™ environment, it's ready to use by making a `mawsRequest`.

# ABOUT MAWS REQUESTS
A `mawsRequest` consists of an `action` and a `command` for MAWS to perform against data received from myAvatar via an *OptionObject2*.

A `mawsRequest` is formatted like so: `%action%-%command%`

For example, to verify that a clients pre-admission date is the same as the system date, you would make a `mawsRequest` of 
```
InptAdmitDate-VerifyPreAdmitDate
```
where `InptAdmitDate` is the request *action*, and `VerifyPreAdmitDate` is the request *command*. 
* To remove leading/trailing whitespace from a subscriber policy, you would make a `mawsRequest` of `SubPolicyNumber-TrimWhitespace`.

## `mawsRequest` actions are classes
Each `mawsRequest` action has a *class* with the same name.

For example, any `mawsRequest` concerning Inpatient Admission Dates ("InptAdmitDate") will be handled by the *InptAdmitDate.cs* class.

## `mawsRequest` commands are methods
Each *action class* contain *methods* that mirror the `mawsRequest` *commands*. For example, the following `mawsRequest`:

"InptAdmitDate-VerifyPreAdmitDate"

Would be carried out by the "VerifyPreAdmitDate()" method in the "InptAdmitDate.cs" class.








 then do one of the following:

1. Prompt the user to make a change within myAvatar
2. Warn the user about something
3. Optionally return modified data to myAvatar

### How a MAWS request relates to myAvatar
To perform an `mawsRequest`, you'll need to create a ScriptLink event in myAvatar that passes both an "action" and an *OptionObject2* to MAWS. For more information about creating ScriptLink events, please see the MAWS [manual](manual-scriptlink-events).

# ACTIONS AND COMMANDS


Here are some examples of a `mawsRequest`:
* Verify that a clients pre-admission date is the same as the system date (`InptAdmitDate-VerifyPreAdmitDate`).
* Remove leading/trailing whitespace from a subscriber policy number (`SubPolicyNumber-TrimWhitespace`)

## Actions are classes




# VALID MAWS REQUESTS
These are the valid `mawsRequest` that MAWS can do.

## Inpatient Admission Date (InptAdmitDate)
What
### VerifyPreAdmitDate (InptAdmitDate-VerifyPreAdmitDate)
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

***

<h4 align="center">

  [INTRODUCTION](manual-introduction.md)&nbsp;&bull;&nbsp;[HOSTING MAWS](manual-hosting-maws.md)&nbsp;&bull;&nbsp;[IMPORTING MAWS](manual-importing-maws.md)&nbsp;&bull;&nbsp;USING MAWS&nbsp;&bull;&nbsp;[CUSTOM MYAVATAR™ WEB SERVICES](manual-custom-myavatar-web-services.md)

</h4>