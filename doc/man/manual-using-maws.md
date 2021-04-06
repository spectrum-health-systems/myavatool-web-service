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

Each `mawsRequest` is formatted like so: `%action%-%command%`

## EXAMPLES

* The `InptAdmitDate-VerifyPreAdmitDate` request verifies that a clients pre-admission date is the same as the system date. The request **action** is `InptAdmitDate`, and the request **command** is `VerifyPreAdmitDate`. 

* The `SubPolicyNumber-TrimWhitespace` removes leading/trailing whitespace from a subscriber policy number. The request **action** is `SubPolicyNumber`, and the request **command** is `TrimWhitespace`. 

### Actions are classes
Each `mawsRequest` action has a corresponding sourcecode class with the same name.

For example, any `InptAdmitDate` actions will be handled by the *InptAdmitDate.cs* class.

### Commands are methods
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
[INPATIENT ADMISSION DATE](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-inpt-admit-date.md)<br>
* [`InptAdmitDate-VerifyPreAdmitDate`](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-inpt-admit-date.md#verifypreadmitdate)

* [SUBSCRIBER POLICY NUMBER](#https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual-sub-policy-number.md#trimwhitespace)
* `SubPolicyNumber-TrimWhitespace`

***

<h4 align="center">

  [INTRODUCTION](manual-introduction.md)&nbsp;&bull;&nbsp;[HOSTING MAWS](manual-hosting-maws.md)&nbsp;&bull;&nbsp;[IMPORTING MAWS](manual-importing-maws.md)&nbsp;&bull;&nbsp;USING MAWS&nbsp;&bull;&nbsp;[CUSTOM MYAVATAR™ WEB SERVICES](manual-custom-myavatar-web-services.md)

</h4>