# MAWS Roadmap

## **v1.0**
* New functionality:
    * Dose.VerifyPercentageDifference functionality
    * Dose.VerifyMilligramsDifference functionality
    * Dose.VerifyMilligramsTotal functionality
* Settings functionality:
    * Settings files allow for blank lines
    * Trailing blank lines in settings files are handled correctly
    * log directory
* Logging
    * Fix RequestSyntaxEngine logging
    * Test logging with pauses, to confirm we catch all logs
    * Archive logs
    * Don't confirm Logs/ exists every time a log file is written
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

## **v1.1**
* InptAdmitDate-ComparePreAdmitToAdmit functionality

## Queue









* Last dose always the same verbage? Always the same spacing?
* What if we just look at what was before "mg"
* Different verbage/text for other medications?
* Do we need to compartmentalize Methadone -vs- Bup -vs- whatever?
* Force single dose for now?
* int enough, or do we need double?