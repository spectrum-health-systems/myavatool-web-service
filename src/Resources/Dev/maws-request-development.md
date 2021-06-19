# MAWS REQUEST DEVELOPMENT

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