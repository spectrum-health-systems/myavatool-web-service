# MAWS Roadmap

## **v1.0**
* Functionality:
    v1: New Functionality
        * Dose
            * Single dose only
            * Force Methadone (liquid)
            * Force Recurring order type
            * Dose.VerifyPercentageDifference functionality
            * Dose.VerifyMilligramsDifference functionality
            * Dose.VerifyMilligramsTotal functionality
* Settings functionality:
    * v1: External settings
    * Settings files allow for blank lines
    * Trailing blank lines in settings files are handled correctly
    * Log directory
* Logging
    * v1: Logging
    * Fix RequestSyntaxEngine logging
    * Test logging with pauses, to confirm we catch all logs
    * Archive logs
    * Don't confirm Logs/ exists every time a log file is written
    * Logs are stored in AppData/
    * Potentially put different logTypes in their own folder
* Testing
    * Full test of MAWS Command .DLL functionality (can update command logic without affecting other functionality)
* Sourcecode
    * Confirm proper access modifiers for methods
    * Figure out a better way to do stand-alone testing
    * Confirm all references to *OptionObject2* are replaced with *OptionObject2015*
    * OptionObjectMaintenance.cs
        * Do we/should we to return the "finalizedOptionObject" from each method? Currently we don't, and things work, but it may be clearer if we break things down a bit
        * Where did we get required/recommended/notrecommended from?
        * OptionObjectMaintenance.Finalize()
            * This method, and the methods it calls, should be more efficient. Currently it relies on brute force.
            * Maybe do the work with a "workerOptionObject", then at the end copy that over to "finalizedOptionObject"
* Documentation
    * Update MAWS Manual
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
    * Explain why flat files are used over JSON
* Tests
    * Verify only specified log files are written (`Utility.LogEvent()`)


## **v1.1**
* Functionality:
    * v1.1: New Functionality
        * InptAdmitDate-ComparePreAdmitToAdmit functionality

## Queue

0.16 - Dose.Compare.Percentage()
0.17 - Dose.Compare.Milligrams()
0.18 - Dose.Compare.TotalMilligrams()
0.19 - Cleanup
        * Dose/dosage
        * Variable/class/method names across commands

* make sure strings have/don't have "$"
* Cleanup log messages
* Make sure 2015 isn't part of any variable names

* Logfiles can be out of order, consider ffffff

* Have a universal conf file
* What if currentDose (1 dose mg) = null/0?
* Get .conf name automatically by passing class name?

* Force single-dose
* Force Methadone (liquid)
* Force Recurring order type
* Verify that the prefix/suffix are correct

* Add Assembly version to the logfiles

* locking of users