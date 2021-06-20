# MAWS Development

[ABOUT THE SOURCECODE](#about-the-sourcecode)<br>
[MAWS FRAMEWORK COMPONENTS](#maws-framework-components)<br>
[MAWS REQUESTS](#maws-requests)<br>

## ABOUT THE SOURCECODE
> The current [production](https://github.com/spectrum-health-systems/MyAvatoolWebService/tree/main) version is: Not released

> The current [development](https://github.com/spectrum-health-systems/MyAvatoolWebService/tree/development) version is: v0.9.x.x

### Code comments
MAWS is heavily commented.

I've tried to make this sourcecode as human-readable as possible, but since other organizations may use MAWS I've decided to heavily comment everything as well. I know this goes against best practice, however since Netsmart doesn't do the best job of making everything *they* do transparent, I want to make it sure that *my* code is as clear as possible as to what it does, and how it does it.

Each of the three different types of comments in MAWS start differently.
 
* `///` XML comments used by Visual Studio
* `//` Short comments intended to give additional information about a block of code.
* `/*...*/` Narrative comments when sourcecode concepts need to be explained in more detail.
 
When possible, I link to the relevent parts of the [MAWS Manual](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual.md).
 
Please do not remove any of the sourcecode comments, and if you fork MAWS for your own development, please and add your own.


### Read the manual!
The [MAWS Manual](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual.md) is updated with each release.


## MAWS FRAMEWORK COMPONENTS
[RequestSyntaxEngine](#RequestSyntaxEngine)<br>
[TestPlatform](#TestPlatform)<br>
[ApplicationLog](#ApplicationLog)<br>
[ExternalSetting](#ExternalSetting)<br>

## RequestSyntaxEngine
| DESCRIPTION | STATUS | RELEASE |
|:----------- |:------ |:------- |
| Parses MAWS Requests | In Progress | v1.0 (MAWS 0.9) |

### RequestSyntaxEngine v1.0
Originally a MAWS Request was a single "command", e.g., "VerifyInpatientAdmissionDate".

In order to make MAWS more customizable, I decided to allow a MAWS Request to be more complex. With v2.0 of the Syntax Engine, a MAWS Request consists of the following:
1. A MAWS *command* (e.g., "InptAdmitDate")
2. A MAWS *action* (e.g., "VerifyPreAdmin")

It's also possible that the MAWS request will contain:
3. A MAWS *option* (e.g., "Testing")

The commands/actions/options are seperated by a `-` delimiter. So a complete MAWS request will look like "InptAdmitDate-VerifyPreAdmin<-option>". The MAWS Request Syntax Engine is the component that parses a MAWS Request, and breaks it down into its seperate parts so MAWS can do what it needs to do.

In addition, v2.0 will have an external list of valid commands/actions/options that will be verified by the RequestSyntaxEngine.

For more information on making MAWS Requests, see the manual.

## TestPlatform
| DESCRIPTION | STATUS | RELEASE |
|:----------- |:------ |:------- |
| Easier functionality testing | In Progress | v1.0 (MAWS 0.9) |

#### TestPlatform v1.0
New/existing MAWS functionality should be able to be developed/modified without over-complicating the testing of said functionality. The idea here is to embed testing code into the production codebase, and access that when testing. When testing is complete, the verified code is copied to the production codebase.

## ApplicationLog
| DESCRIPTION | STATUS | RELEASE |
|:----------- |:------ |:------- |
| Application logging | In Progress | v1.0 (MAWS 0.9) |

#### ApplicationLog v1.0
MAWS should log stuff, for example:
* When a specific function is called
* Values of a specific function
* Who called it

Also, maybe include metrics where we can see how often/how many times a specific function is called.

### ExternalSetting
| DESCRIPTION | STATUS | RELEASE |
|:----------- |:------ |:------- |
| MAWS settings are stored externally | In Progress | v1.0 (MAWS 0.9) |

#### ExternalSetting v1.0
Settings should be stored in a file outside of MAWS, so they can be easily viewed and modified.

### EfficientSearch
| DESCRIPTION | STATUS | RELEASE |
|:----------- |:------ |:------- |
| More efficient search logic | TBD | TBD |

#### EfficientSearch v0.1
The current search method is really inefficient. Once all the needed data has been found, we should exit the search.

### MAWSGUI
| DESCRIPTION | STATUS | RELEASE |
|:----------- |:------ |:------- |
| A GUI for MAWS | TBD | TBD |

#### MAWSGUI v1.0
TBD

# MAWS REQUESTS

**CONTENTS**<br>
[Dose](#Dose)<br>

## Dose
| DESCRIPTION | STATUS | RELEASE |
|:----------- |:------ |:------- |
| The `Dose` command | In Progress | v1.0 (MAWS 0.9) |

Verify that the current medication dose does not exceed specific parameters.

### Dose v1.0
| ACTION | DESCRIPTION | STATUS |
|:------ |:----------- |:------ |
| WithinPercentIncrease | Verify the current medication (in mg) does not exceed a specific percentage increase from the previous dose | In Progress |
| WithinMilligramIncrease | Verify the current medication (in mg) does not exceed a specific milligram increase from the previous dose | In Progress |
| LessThanMilligrams | Verify the current medication (in mg) does not exceed a specific number of milligrams | In Progress |
| WithinParameters | Verify the current medication (in mg) does not exceed a specific number of milligrams | In Progress |

This command will verify that the current medication dose:
1. Does not exceed X% of the previous dose<br>
AND/OR
2. Does not exceed X(mg) of the previous dose<br>
AND
3. Does not exceed X(mg)

Originally a MAWS Request was a single "command", e.g., "VerifyInpatientAdmissionDate".

In order to make MAWS more customizable, I decided to allow a MAWS Request to be more complex. With v2.0 of the Syntax Engine, a MAWS Request consists of the following:
1. A MAWS *command* (e.g., "InptAdmitDate")
2. A MAWS *action* (e.g., "VerifyPreAdmin")

The command and action are seperated by a `-` delimiter. So a complete MAWS request will look like "InptAdmitDate-VerifyPreAdmin". The MAWS Request Syntax Engine is the component that parses a MAWS Request, and breaks it down into its seperate parts so MAWS can do what it needs to do.

For more information, see the manual.


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