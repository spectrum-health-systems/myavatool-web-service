# MAWS Changelog

<details>
<summary>
Version 1.0

* New Requests
    * InptAdmitDate.ComparePreAdmitToAdmit<br>
    * Dose.VerifyPercentage
* New functionality<br>
    * Logging<br>
    * Testing platform

</summary>

## Version 0.10
> Dose command functionality

## Version 0.9
> Implementing OptionObject2015

#### v0.9.21179.1515 (2021-06-28)
* `FIXED` Fixed returning the OptionObject

#### v0.9.21179.1312 (2021-06-28)
* `ADDED` Added Dose in switch statement, for testing Dose functionlity

#### v0.9.21172.1617 (2021-06-21)
* `INFO` Final v0.9 release

#### v0.9.21172.1316 (2021-06-21)
* `INFO` Code/comment/documentation updates/cleanup
* `REMOVED` MyAvatoolWebService.ForceTest()
* `ADDED` Testing.cs
* `ADDED` Testing.Force()
* `MODIFIED` MAWS Request commands/actions/options are now converted to lowercase prior to being returned by RequestSyntaxEngine.cs
* `MODIFIED` Maintenance.ConfirmLogDirectory() -> Maintenance.ConfirmLogDirectory()

#### v0.9.21172.1210 (2021-06-21)
* `INFO` Code/comment/documentation updates/cleanup

#### v0.9.21171.1735 (2021-06-20)
* `MODIFIED` Added [DEBUG] prefix to log files
* `MODIFIED` Added [SYSTEM] prefix to log files

#### v0.9.21171.1731 (2021-06-20)
* `ADDED` Error logging for invalid commands
* `ADDED` Error logging for invalid InptAdmitDate.cs actions
* `ADDED` Error logging for invalid Dose.cs actions

#### v0.9.21171.1719 (2021-06-20)
* `INFO` Code/comment cleanup (lots of undocumented changes to *InpatientAdmissionDate* to bring it in-line with the new framwork)
* `MODIFIED` Renamed *InpatientAdmissionDate* -> *InptAdmitDate*
* `MODIFIED` Removed *GetRequestAction()* and *GetRequestOption()* from *MyAvatoolWebService.asmx.cs* so the scope is tightened up a bit.
* `ADDED` /Resources/Log/
* `ADDED` Maintenance.cs
* `ADDED` Maintenance.CreateLogDirectory()
* `ADDED` Logger.cs
* `ADDED` Logger.WriteToTimestampedFile()
* `ADDED` Dose.cs
* `ADDED` Dose.ForceTest()
* `ADDED` Dose.VerifyPercentage()
* `ADDED` Dose.VerifyPercentage_Testing()
* `MODIFIED` Convert actions/options to lowercase

#### v0.9.21170.2311 (2021-06-19)
* `INFO` Re-implemented the *InpatientAdmissionDate* command
* `ADDED` InpatientAdmissionDate.cs
* `ADDED` RequestSyntaxEngine.ForceTest()

#### v0.9.21170.2044 (2021-06-19)
* `INFO` Built-in (simplistic!) testing works.
* `ADDED` MyAvatoolWebService.ForceTest()
* `ADDED` RequestSyntaxEngine.ForceTest()

#### v0.9.21170.1739 (2021-06-19)
* `INFO` Documentation updates

#### v0.9.21170.1726 (2021-06-19)
* `INFO` Documentation updates
* `MODIFIED` Started the change to the MAWS Request Syntax Engine

#### v0.9.21170.1628 (2021-06-19)
* `INFO` Code/comment/documentation changes

#### v0.9.21161.1940 (2021-06-10)
* `ADDED` OptionObjectMaintenance.cs
* `ADDED` OptionObjectMaintenance.FinalizeObject()
* `ADDED` OptionObjectMaintenance.FinalizeRequiredFields()
* `ADDED` OptionObjectMaintenance.FinalizeNonRequiredFields()

#### v0.9.21161.1854 (2021-06-10)
* `INFO` Code and comment cleanup

#### v0.9.21161.1834 (2021-06-10)
* `INFO` Version refresh

#### v0.9.21161.1831 (2021-06-10)
* `ADDED` MyAvatoolWebService.GetVersion()
* `ADDED` MyAvatoolWebService.RunScript()
* `ADDED` MyAvatoolWebService.MethodName()

#### v0.9.21161.1816 (2021-06-10)
* `INFO` Added the NTST.ScriptLinkService.Objects project to the solution
* `MODIFIED` MAWS Manual updates

#### v0.9.21161.1749 (2021-06-10)
* `INFO` Framework commit

## Version 0.8
> Finalizing documentation/comments.

#### v0.8.21111.1535 (2021-04-21)
* `ADDED` /Resources/Dev/sourcecode-information.md
* `RENAME` /Resources/Dev/current-versions.md -> /Resources/Dev/developent-information.md

#### v0.8.21111.1434 (2021-04-21)
* `ADDED` /Resources/Dev/current-versions.md

## Version 0.7
> Updating documentation/comments.

## Version 0.6
> Updating documentation/comments.

## Version 0.5
> Updating documentation/comments.
 
## Version 0.4
> Updating documentation/comments.

## Version 0.3
> Updating documentation/comments.

## Version 0.2
> Moving functionality from the Avatar Web Service.

#### v0.2.21014.1544 (2021-01-14)
* `ADDED` OptionObjectMaintenance.cs
* `ADDED` OptionObjectMaintenance.Complete()
* `ADDED` OptionObjectMaintenance.CompleteRequired()
* `ADDED` OptionObjectMaintenance.CompleteRecommended()
* `ADDED` OptionObjectMaintenance.CompleteNotRecommended()
* `ADDED` Functionality to InptAdminDate.VerifyPreAdmitDate() so once the "typeOfAdmissionField" and "preAdmitToAdmissionDateField" fields are found, MAWS stops looking through the sentOptionObject2. This should speed things up in some cases.
* `MODIFIED` Refactored detailed error messages in InptAdminDate.VerifyPreAdmitDate() with string interpolation.

#### v0.2.21014.1544 (2021-01-14)
* `ADDED` InptAdminDate.Parser() method
* `ADDED` InptAdminDate.VerifyPreAdmitDate() method
* `MODIFIED` Requests in the RunScript() method now uses "workingOptionObject2" instead of "completedOptionObject2" because I want to make sure it's very clear as to what MAWS is sent ("sentOptionObject2"), what it works with ("workingOptionObject2"), and what it returns to myAvatar ("completedOptionObject2").
* `RENAMED` "InptAdminDate.cs" to "InptAdmitDate.cs" because this request will do things with the inpatient *admission* date, and the "Admin" abbreviation indicates *administration*.
* `RENAMED` "action" to "mawsRequest" because going forward ScriptLink events will be passing a "request-action" (e.g., "InptAdmitDate-VerifyPreAdmitDate")
* `UPDATED` Documentation

#### v0.2.21014.1425 (2021-01-14)
* `REMOVED` Local methods to pre-process an action (i.e., "MyAvatoolWebService.asmx.cs.InptAdminDate"). The pre-processing is now going to be done in the action class, in a method named "Parser()" (e.g., "InptAdminDate.Parser()").
* `UPDATED` Documentation

#### v0.2.21013.1802 (2021-01-13)
* `ADDED` InptAdminDate.cs class.
* `MODIFIED` Renamed "MyAvatoolWebService.asmx.cs.MethodName()" to "MyAvatoolWebService.asmx.cs.InptAdminDate()".
* `MODIFIED` Added "InptAdminDate" case to the switch statement in RunScript().
* `MODIFIED` Added "SubPolicyNumber" case to the switch statement in RunScript().

#### v0.2.0.0 (2021-01-13)
* `INFO` Initial commit of v0.2 branch.

## Version 0.1
> Updated blank template for MAWS, building on v0.0. It includes:

* `ADDED` MAWS.licenseheader file for use with the [License Header Manager](https://marketplace.visualstudio.com/items?itemName=StefanWenig.LicenseHeaderManager) extension.
* `MODIFIED` AssemblyInfo.cs with...uh...assembly information.
* `MODIFIED` Renamed *sentOptionObject* to *sentOptionObject2* so it's more inline with Netsmart's (wierd) naming conventions.

#### v0.1.21013.1420 - 0.1.21013.1712 (2021-01-13)
* `ADDED` MAWS.licenseheader file for use with the [License Header Manager](https://marketplace.visualstudio.com/items?itemName=StefanWenig.LicenseHeaderManager) extension.
* `MODIFIED` AssemblyInfo.cs with...uh...assembly information.
* `MODIFIED` Renamed *sentOptionObject* to *sentOptionObject2* so it's more inline with Netsmart's (wierd) naming conventions.

## Version 0.0 (2021-01-12)
> Blank MAWS template which was built following the steps in the MAWS [manual](doc/man/manual-custom-myavatar-web-services.)

#### v0.0.0.0 (2021-01-12)
* `INFO` This is a blank MAWS template.

</details>

***

* `INFO`
* `ADDED`
* `MODIFIED`
* `RENAMED`
* `UPDATED`
* `DEPRECIATED`
* `REMOVED`