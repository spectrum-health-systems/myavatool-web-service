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
  [ABOUT MAWS REQUESTS](#about-maws-requests)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[EXAMPLES](#examples)<br>
  [ACTIONS AND COMMANDS](#actions-and-commands)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[ACTIONS ARE CLASSES](#actions-are-classes)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[COMMANDS ARE METHODS](#commands-are-methods)<br>
  [HOW TO MAKE A MAWS REQUEST](#how-to-make-a-maws-request)<br>
  [MAWS REQUEST RESULTS](#maws-request-results)<br>
  [VALID MAWS REQUESTS](#valid-maws-requests)<br>

</td>
</tr>
</table>

# OVERVIEW
Once you have [hosted](manual-hosting-maws.md) MAWS and [imported](manual-importing-maws.md) it into your myAvatar™ environment, it's ready to use by making a `mawsRequest`.

# ABOUT MAWS REQUESTS
A `mawsRequest` consists of an `action` and a `command` for MAWS to perform against data received from myAvatar via an *OptionObject2*.

Each `mawsRequest` is formatted like so: `%action%-%command%`

## EXAMPLES

* The `InptAdmitDate-VerifyPreAdmitDate` request verifies that a clients pre-admission date is the same as the system date. The request **action** is `InptAdmitDate`, and the request **command** is `VerifyPreAdmitDate`. 

* The `SubPolicyNumber-TrimWhitespace` removes leading/trailing whitespace from a subscriber policy number. The request **action** is `SubPolicyNumber`, and the request **command** is `TrimWhitespace`. 

# ACTIONS AND COMMANDS
## ACTIONS ARE CLASSES
Each `mawsRequest` action has a corresponding sourcecode class with the same name.

For example, any `InptAdmitDate` actions will be handled by the *InptAdmitDate.cs* class.

## COMMANDS ARE METHODS
Each `mawsRequest` command has a corresponding method with the same name. This method can be found in the action's class sourcecode. 

For example, the `VerifyPreAdmitDate` **command** of the `InptAdmitDate` **action** would be processed by the *VerifyPreAdmitDate()* method in the *InptAdmitDate.cs* class.

# HOW TO MAKE A MAWS REQUEST
To perform an `mawsRequest`, you'll need to create a ScriptLink event in myAvatar that passes the request and an *OptionObject2* to MAWS. For more information about creating ScriptLink events, please see the MAWS [manual](manual-scriptlink-events).

# MAWS REQUEST RESULTS
A `mawsRequest` will result in one of the following:

1. Prompt the user to make a change within myAvatar
2. Warn the user about something
3. Optionally return modified data to myAvatar

# VALID MAWS REQUESTS
* [Inpatient Admission Date](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-request-inpt-admit-date.md)<br>
  * [`InptAdmitDate-VerifyPreAdmitDate`](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-request-inpt-admit-date.md#verifypreadmitdate)

* [Subscriber Policy Number](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-request-sub-policy-number.md)<br>
  * [`SubPolicyNumber-TrimWhitespace`](#https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-request-sub-policy-number.md#trimwhitespace)

***

<h4 align="center">

  [INTRODUCTION](manual-introduction.md)&nbsp;&bull;&nbsp;[HOSTING MAWS](manual-hosting-maws.md)&nbsp;&bull;&nbsp;[IMPORTING MAWS](manual-importing-maws.md)&nbsp;&bull;&nbsp;USING MAWS&nbsp;&bull;&nbsp;[CUSTOM MYAVATAR™ WEB SERVICES](manual-custom-myavatar-web-services.md)

</h4>