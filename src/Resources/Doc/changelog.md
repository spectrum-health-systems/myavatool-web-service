# MAWS Changelog

<details>
<summary>
Version 1.0

* New MAWS Requests:
    * Dose-VerifyPercentage
    * Dose-VerifyMilligrams
    * Dose-VerifyTotal
* New MAWS functionality:
    * Logging
    * External settings

</summary>

## Version 0.15
* Foundational work on Dose functionality.

#### v0.15.21200.1703 (2021-07-19)
* `INFO` Final v0.15
##### Dose
* `INFO` Dose.Compare.Percentage() works.

#### v0.15.21200.1632 - 0.15.21200.1639 (2021-07-19)
* `INFO` Clean build for testing.

#### v0.15.21200.1627 (2021-07-19)
* `INFO` Clean build for testing.
##### Dose
* `ADDED` formLoopCount and fieldLoopCount for debugging purposes.

#### v0.15.21200.1537 (2021-07-19)
* `INFO` Clean build for testing.

#### v0.15.21200.1526 (2021-07-19)
* `INFO` Clean build for testing.
* `FIXED` Putting the AssemblyVersion in the logfile contents was causing an issued. Roadmapped.

#### v0.15.21200.1526 (2021-07-19)
* `INFO` Clean build for testing.

#### v0.15.21200.1509 (2021-07-19)
* `INFO` Clean build for testing.
* `FIXED` *.settings* files were not renamed to *.conf* in the sourcecode. Duh.

#### v0.15.21200.1455 (2021-07-19)
* `INFO` Clean build for testing.
* `ADDED` AppData/Configuration/

##### Utility
* `MODIFIED` WriteToFile() -> WriteTimestampedFile()

#### v0.15.21200.1324 - v0.15.21200.1344 (2021-07-19)
* `INFO` A test for comment length (not project related)

#### v0.15.21200.1316 (2021-07-19)
* `INFO` Code/comment cleanup
* `MODIFIED` Setting file extension is now *.conf*, since *.settings* was causing an issue with Visual Studio thinking it was a settings file.
* `ADDED` AppData/Configuration/

#### v0.15.21196.1319 (2021-07-15)
* `INFO` Code/comment cleanup
* `ADDED` AppData/
* `ADDED` AppData/Logs/

#### v0.15.21190.1333 (2021-07-09)
* `REMOVED` Logger project
* `REMOVED` Test project
* `REMOVED` MyAvatoolWebService.Settings.cs
##### Dose
* `MODIFIED` Percentages are now calculated as doubles.
##### Utility
* `MODIFIED` AppSettings.FromKeyValuePair() paramater changed to fileName, this way we can force the path to be either the production or staging folder. 

#### v0.15.21189.2018 (2021-07-08)
* `INFO` Clean build for testing.

#### v0.15.21189.1853 (2021-07-08)
* `INFO` Clean build for testing.
* `ADDED` Basic Dose command functionality
* `MODIFIED` Renamed Dose.Verify.cs -> Dose.Compare.cs
* `ADDED` Settings for verifying dose information

#### v0.15.21189.1822 (2021-07-08)
* `INFO` Initial v0.15 version.
* `INFO` Archived v0.14.

***

## Version 0.14
* Code/comment/documentation cleanup in preparation for Dose command testing.

#### v0.14.21189.1822 (2021-07-08)
* `INFO` Final v0.14

#### v0.14.21189.1809 (2021-07-08)
* `INFO` Clean build for testing.

#### v0.14.21189.1758 (2021-07-08)
* `INFO` Clean build for testing.

#### v0.14.21189.1623 (2021-07-08)
* `INFO` Clean build for testing.

#### v0.14.21189.1622 (2021-07-08)
* `INFO` Code/comment/documentation cleanup.
##### Utility (previously Logger)
* `MODIFIED` AppSettings.FromKeyValuePair() now allows .settings files to have blank lines.
* `MODIFIED` LogEvent.WriteToFile() filename changed to make it easier to look at things in chronological order.

#### v0.14.21189.1423 (2021-07-08)
* `INFO` Code/comment/documentation cleanup.
* `MODIFIED` Logger.cs -> Utility.cs
##### Dose
* `REMOVED` Verify.Percentage_Testing.cs
* `REMOVED` Setting.cs (funcationality moved to Utility.AppSettings.cs)
##### InptAdmtDate
* `REMOVED` Compare.PreAdmitToAdmit_Testing.cs
* `REMOVED` Setting.cs (funcationality moved to Utility.AppSettings.cs)
##### Utility (previously Logger)
* `ADDED` Setting.cs
* `MODIFIED` Started migrating LogEvent code

#### v0.14.21188.1607 (2021-07-07)
* `WARN` This version doesn't work, I'm halfway through updating the logging functionality.
* `INFO` Code/comment/documentation cleanup.
* `MODIFIED` Moved the stand-alone testing logic out of GetVersion(), and put it in it's own method. Now there is a single `//TestFunctionality()' line that is commented out by default, since it actually breaks MAWS in production.
##### Logger
* `ADDED` LogEvent.cs
* `ADDED` LogEvent.Timestamped()
* `REMOVED` Timestamped.cs, functionality moved to Logger.LogEvent.cs
* `MODIFIED` Started migrating LogEvent code

#### v0.14.21188.1355 (2021-07-07)
* `INFO` Initial v0.14 version.
* `INFO` Archived v0.13.
* `INFO` Archived v0.12.
* `INFO` Archived v0.11.
* `INFO` Archived v0.10.
* `INFO` Cleaned up dev/ archives.

***

## Version 0.13
* This version was used to test for connectivity.

#### v0.13.21187.2038 (2021-07-06)
* `INFO` Clean build for testing.
* `MODIFIED` Removed custom lines in GetVersion().
* `MODIFIED` Fixed a few log comments.

#### v0.13.21183.1419 (2021-07-02)
* `INFO` Initial v0.13 version.

***

## Version 0.12
* Moved `InptAdmitDate.cs` and `Dose.cs` functionality out of the Command project. Don't know why I put them there in the first place, it goes against the whole compartmentalizing concept. Each MAWS command (e.g., "InptAdmitDate", "Dose") will now have it's own project.
* Each MAWS command (e.g., "InptAdmitDate", "Dose") has it's own settings file, which makes it easier to customize various functionality (e.g., logging) for a specific command.
* Logfiles are now more detailed, better organized, and you can specify which types of events you want to log (or disable logging completely).

#### v0.12.21183.1411 (2021-07-02)
* `INFO` Final 0.12 version deployed to production for testing.
* `MODIFIED` Confirmed all projects are set to v0.12.21183.1411 

#### v0.12.21183.0048 (2021-07-01)
* `INFO` Code/comment/documentation updates/cleanup
* `ADDED` Test case to the switch statement in RunScript()
##### RequestSyntaxEngine
* `MODIFIED` Logging functionality brought up to other project levels
* `REMOVED` ParseRequest.cs
##### NewDevelopment (previously TestFunctionality)
* `ADDED` Execute.cs
* `ADDED` Execute.Action()
* `ADDED` Settings.cs
* `ADDED` Settings.GetSettings()
* `REMOVED` Existing.cs
* `REMOVED` New.cs

#### v0.12.21182.2257 (2021-07-01)
* `INFO` Code/comment/documentation updates/cleanup
##### Dose
* `ADDED` .licenseheader file
##### InptAdmitDate
* `ADDED` .licenseheader file
##### TestFunctionality
* `ADDED` .licenseheader file

#### v0.12.21182.1839 (2021-07-01)
* `REMOVED` Command project
* `REMOVED` MyAvatoolWebService.Dose.cs
##### InptAdmitDate
* `ADDED` Compare.cs
* `ADDED` Compare.PreAdmitToAdmit()
* `ADDED` Execute.cs
* `ADDED` Execute.Action()
* `ADDED` Settings.cs
* `ADDED` Settings.GetSettings()
##### Logger
* `ADDED` Logfiles now have the .mawslog extension
##### Dose
* `ADDED` Exectute.cs
* `ADDED` Exectute.Action()
* `ADDED` Settings.cs
* `ADDED` Settings.GetSettings()
* `ADDED` Verify.cs
* `ADDED` Verify.Percentage()
* `ADDED` Verify.Percentage_Testing()

#### v0.12.21182.1554 (2021-07-01)
* `ADDED` Dose project.
* `ADDED` InptAdmitDate project.
##### Logger
* `INFO` You can now specifiy what type of events are logged.
* `ADDED` Logger.LogEvent().
* `MODIFIED` Logging functionality for MyAvatoolWebService project.
* `MODIFIED` Log filenames and syntax.

***

## Version 0.11

#### v0.11.21181.1709 (2021-06-30)
* `INFO` Final v0.11 version deployed to production for testing
* `ADDED` New project: Command.csproj
* `ADDED` New project: TheOptionObject.csproj
* `MODIFIED` Moved Test project to src/
##### Command
* `ADDED` InptAdmitDate.cs
* `ADDED` InptAdmitDate.ExecuteAction()
* `ADDED` InptAdmitDate.ComparePreAdmitToAdmit()
* `ADDED` InptAdmitDate.ComparePreAdmitToAdmit_Testing()
* `ADDED` TestFunctionality()
* `ADDED` TestFunctionality.ForceInptAdmitDate()
##### Logger
* `ADDED` 10,000/sec to the filename.
* `ADDED` 10ms pause after writing a file.
* `MODIFIED` Logger filename is more descriptive.
* `REMOVED` *verboseLog* parameter. In roadmap.
##### Test
* `ADDED` Existing.cs
* `ADDED` New.cs
##### TheOptionObject
* `ADDED` Finalize.cs
* `ADDED` Finalize.WhichComponents()
* `ADDED` Finalize.RequiredFields()
* `ADDED` Finalize.RecommendedFields()
* `ADDED` Finalize.NonRecommendedFields()

#### v0.11.21181.1407 (2021-06-30)
* `INFO` Code/comment/documentation updates/cleanup
* `MODIFIED` Moved Logger project to src/
* `FIXED` Project references.
* `ADDED` New project: Test.csproj
* `ADDED` *licenseheader* files
* `REMOVED` Testing.cs
##### Logger
* `ADDED` *verboseLog* parameter
##### Test
* `ADDED` Existing.cs
* `ADDED` Existing.Force()

#### v0.11.21181.1305 (2021-06-30)
* `INFO` Code/comment/documentation updates/cleanup
##### Logger
* `MODIFIED` Timestamped.WriteToFile(): *logMessage* is now an optional parameter, and defaults to "No log message defined".
* `MODIFIED` Minor changes to log output text.
* `MODIFIED` Renamed the "Caller" parameters to be more descriptive.

#### v0.11.21179.1755 (2021-06-28)
* `INFO` Groundwork for framework update
* `MODIFIED` Lots of logging updates
* `ADDED` New project: Dose.csproj
* `ADDED` New project: Logger.csproj
* `ADDED` New project: InptAdmitDate.csproj
* `ADDED` New project: RequestSyntaxEngine.csproj
* `REMOVED` Maintenance.cs
* `REMOVED` Logger.cs
##### Logger
* `ADDED` Timestamped.cs
* `ADDED` Timestamped.Maintenance()
* `ADDED` Timestamped.WriteToFile()
##### RequestSyntaxEngine
* `ADDED` ParseRequest.cs
* `ADDED` ParseRequest.ExecuteCommand()
* `ADDED` RequestComponent.cs
* `ADDED` RequestComponent.GetCommand()
* `ADDED` RequestComponent.GetAction()
* `ADDED` RequestComponent.GetOption()
* `ADDED` TestFunctionality.cs
* `ADDED` TestFunctionality.Force()

#### v0.11.21176.1652 (2021-06-28)
* `INFO` Initial v0.11 release.

***

## Version 0.10
> Focus on logging functionality and external settings

#### v0.10.21176.1652 (2021-06-25)
* `INFO` Code/comment/documentation updates/cleanup
* `FIXED` A completed OptionObject wasn't being passed back to Avatar.

#### v0.10.21176.1518 (2021-06-25)
* `INFO` Code/comment/documentation updates/cleanup
* `ADDED` Settings.cs
* `ADDED` Settings.GetSettings()
* `ADDED` Settings are now loaded from an external file
* `ADDED` "TestFunctionality" setting
* `MODIFIED` \MAWS\Log -> \MAWS\Logs
* `MODIFIED` Testing.Force() -> Testing.Functionality()

#### v0.10.21176.0200 (2021-06-25)
* `INFO` Initial v0.10 release

***

## Version 0.9
> Implementing OptionObject2015

#### v0.9.21179.1515 (2021-06-28)
* `FIXED` Fixed returning the OptionObject.

#### v0.9.21179.1312 (2021-06-28)
* `ADDED` Added Dose in switch statement, for testing Dose functionlity.

#### v0.9.21176.0200 (2021-06-25)
* `INFO` Final v0.9 release. Fixed a few things that impacted deployment.

#### v0.9.21172.1617 (2021-06-21)
* `INFO` Final v0.9 release (not the case, see above)

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

***

## Version 0.8
> Finalizing documentation/comments.

#### v0.8.21111.1535 (2021-04-21)
* `ADDED` /Resources/Dev/sourcecode-information.md
* `RENAME` /Resources/Dev/current-versions.md -> /Resources/Dev/developent-information.md

#### v0.8.21111.1434 (2021-04-21)
* `ADDED` /Resources/Dev/current-versions.md

***

## Version 0.7
> Updating documentation/comments.

***

## Version 0.6
> Updating documentation/comments.

***

## Version 0.5
> Updating documentation/comments.
 
***

## Version 0.4
> Updating documentation/comments.

***

## Version 0.3
> Updating documentation/comments.

***

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

***

## Version 0.1
> Updated blank template for MAWS, building on v0.0. It includes:

* `ADDED` MAWS.licenseheader file for use with the [License Header Manager](https://marketplace.visualstudio.com/items?itemName=StefanWenig.LicenseHeaderManager) extension.
* `MODIFIED` AssemblyInfo.cs with...uh...assembly information.
* `MODIFIED` Renamed *sentOptionObject* to *sentOptionObject2* so it's more inline with Netsmart's (wierd) naming conventions.

#### v0.1.21013.1420 - 0.1.21013.1712 (2021-01-13)
* `ADDED` MAWS.licenseheader file for use with the [License Header Manager](https://marketplace.visualstudio.com/items?itemName=StefanWenig.LicenseHeaderManager) extension.
* `MODIFIED` AssemblyInfo.cs with...uh...assembly information.
* `MODIFIED` Renamed *sentOptionObject* to *sentOptionObject2* so it's more inline with Netsmart's (wierd) naming conventions.

***

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