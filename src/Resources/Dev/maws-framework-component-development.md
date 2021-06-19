# MAWS FRAMEWORK COMPONENT DEVELOPMENT

**CONTENTS**<br>
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

The command and action are seperated by a `-` delimiter. So a complete MAWS request will look like "InptAdmitDate-VerifyPreAdmin". The MAWS Request Syntax Engine is the component that parses a MAWS Request, and breaks it down into its seperate parts so MAWS can do what it needs to do.

For more information, see the manual.

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
