﻿# MAWS FRAMEWORK COMPONENT DEVELOPMEN

**CONTENTS**<br>
[REQUEST SYNTAX ENGINE](#request-syntax-engine)<br>
[Functionality](#functionality)<br>

## Request Syntax Engine

<table>
  <tr>
    <th>COMPONENT NAME</th>
    <td>ReqEng</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>The logic that parses a MAWS Request</td>
  </tr>
    <th>DETAILS</th>
    <td>A MAWS Request is comprised of multiple components, which the MAWS Request Syntax Engine parses to determine what actions/commands need to be completed.</td>
  </tr>
    <th>STATUS</th>
    <td>In Progress - v2.0</td>
  </tr>
    <th>MAWS RELEASE</th>
    <td>v0.9</td>
  </tr>
</table>

Originally a MAWS Request was a single "command", e.g., "VerifyInpatientAdmissionDate". In order to make MAWS more customizable, I decided to allow a MAWS Request to be more complex, consisting of a MAWS "command" and a command "action". The MAWS Request Syntax Engine is the component that parses a MAWS Request, and breaks it down into its seperate parts so MAWS can do what it needs to do.

### ReqEng v2.0
I've changed the way that MAWS requests are passed/executed. Instead of passing an *action* to `MyAvatoolWebService.RunScript()`, a *mawsRequest* (e.g., "InptAdmitDate-VerifyPreAdmin") is passed. That is then parsed (using the `-` delimiter) into the following:
1. A MAWS *command* (e.g., "InptAdmitDate")
2. A MAWS *action* (e.g., "VerifyPreAdmin")

### ReqEng v1.0
Original syntax stuff. Very simple. Not documented.

### Testing platform
<table>
  <tr>
    <th>NAME</th>
    <td>TestPlat</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Ability to test/develop new functionality using the same codebase that is deployed to production.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD</td>
  </tr>
    <th>STATUS</th>
    <td>In Progress</td>
  </tr>
    <th>TARGET RELEASE</th>
    <td>v0.9</td>
  </tr>
</table>

#### TestPlat proposal
New/existing MAWS functionality should be able to be developed/modified without over-complicating the testing of said functionality. The idea here is to embed testing code into the production codebase, and access that when testing. When testing is complete, the verified code is copied to the production codebase.

This is an ongoing project which will span multiple MAWS versions.

#### TestPlat v0.1
I've changed the way that MAWS requests are passed/executed:
* Instead of passing an *action* to `MyAvatoolWebService.RunScript()`, a *mawsRequest* (e.g., "InptAdmitDate-VerifyPreAdmin") is passed. That is then parsed (using the `-` delimiter) into the following:
1. A MAWS *command* (e.g., "InptAdmitDate")
2. A MAWS *action* (e.g., "VerifyPreAdmin")

### External logging
<table>
  <tr>
    <th>NAME</th>
    <td>ExtLog</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Logging functionality.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD</td>
  </tr>
    <th>STATUS</th>
    <td>In Progress</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>v0.9</td>
  </tr>
</table>

#### ExtLog proposal
MAWS should log stuff, for example:
* When a specific function is called
* Values of a specific function
* Who called it

Also, maybe include metrics where we can see how often/how many times a specific function is called.

#### ExtLog v0.1
TBD

### External settings
<table>
  <tr>
    <th>NAME</th>
    <td>ExtSet</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Store settings outside of MAWS.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD</td>
  </tr>
    </tr>
    <th>STATUS</th>
    <td>In Progress</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>v0.9</td>
  </tr>
</table>

#### ExtSet proposal
Settings should be stored in a file outside of MAWS.

#### ExtSet v0.1
TBD

## FUNCTIONALITY: COMMANDS

### Dosage-VerifyPercentIncrease

<table>
  <tr>
    <th>NAME</th>
    <td>DoseCheck</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Verify that the current medication dose does not exceed specific parameters.</td>
  </tr>
    <th>DETAILS</th>
    <td>Confirm that the current medication dose:
1. Does not exceed X% of the previous dose<br>
AND/OR
2. Does not exceed X(mg) of the previous dose<br>
AND
3. Does not exceed X(mg)</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>FORM: Quick Medication Order FIELD: "Dosage 1(mg)" FIELD_ID: 107<br>
    FORM: Quick Medication Order FIELD: "Last order scheduled" FIELD_ID: 142<br>
    FORM: Quick Medication Order FIELD: "Single Dosage radio button" FIELD_ID: 106</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>v0.9</td>
  </tr>
</table>

#### DoseCheck proposal
This functionality will end up being relatively complex, so we will be building it out in chunks. We will start out simple, and add complexity with each version.

#### DoseCheck v0.1
TBD

### InptAdmitDate

<table>
  <tr>
    <th>NAME</th>
    <td>InptAdmitDate
</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Does various things with the Inpatient Admission Date</td>
  </tr>
    <th>DETAILS</th>
    <td>Confirm that the current medication dose:
1. Does not exceed X% of the previous dose<br>
AND/OR
2. Does not exceed X(mg) of the previous dose<br>
AND
3. Does not exceed X(mg)</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>FORM: Quick Medication Order FIELD: "Dosage 1(mg)" FIELD_ID: 107<br>
    FORM: Quick Medication Order FIELD: "Last order scheduled" FIELD_ID: 142<br>
    FORM: Quick Medication Order FIELD: "Single Dosage radio button" FIELD_ID: 106</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>v0.9</td>
  </tr>
</table>

#### InptAdmitDate proposal
Th

#### InptAdmitDate v0.1
TBD


## FUNCTIONALITY: COMMANDS