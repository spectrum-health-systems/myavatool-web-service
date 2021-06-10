# MAWS: Roadmap

[ ] Confirm all references to *OptionObject2* are replaced with *OptionObject2015*

[ ] OptionObjectMaintenance.cs
    [ ] Do we/should we to return the "finalizedOptionObject" from each method? Currently we don't, and things work, but it may be clearer if we break things down a bit
    [ ] Where did we get required/recommended/notrecommended from?
    [ ] OptionObjectMaintenance.Finalize()
        [ ] This method, and the methods it calls, should be more efficient. Currently it relies on brute force.
        [ ] Maybe do the work with a "workerOptionObject", then at the end copy that over to "finalizedOptionObject"



* manual-hosting-maws.md
    * instruction on where to put the files/how to publish
    * updating MAWS
    * Disabling MAWS
    * has to be https

* Update manual to reflect the local methods being removed.
    * Main asmx is just the required methods now
    * All actions are external classes

* Man
    * InptAdmitDate.cs
        * Parser, DefineFieldIds, etc all under main

* Logging

* documentation
    * other projects
    * OO2

* Other abbreviations:
    * Outpatient = outpt 

* Do the $"{}" thing with strings