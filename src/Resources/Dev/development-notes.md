# MAWS: Development Notes

## FRAMEWORK

### Testing platform
<table>
  <tr>
    <th>NAME</th>
    <td>TestPlatform</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Ability to test/develop new functionality using the same codebase that is deployed to production.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD</td>
  </tr>
    </tr>
    <th>STATUS</th>
    <td>In Progress</td>
  </tr>
</table>

We should be able to develop new/modify current MAWS functionality without over-complicating the testing of said functionality. The idea here is to embed testing code into the production codebase, and access that when testing. When testing is complete, the verified code is copied to the production codebase.

This is an ongoing project which will span multiple MAWS versions.

### External logging
<table>
  <tr>
    <th>NAME</th>
    <td>ExternalLogging</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Logging functionality.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD</td>
  </tr>
    </tr>
    <th>STATUS</th>
    <td>In Progress</td>
  </tr>
</table>

MAWS should log stuff, for example:
* When a specific function is called
* Values of a specific function
* Who called it

Also, maybe include metrics where we can see how often/how many times a specific function is called.

### External settings
<table>
  <tr>
    <th>NAME</th>
    <td>ExternalSettings</td>
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
</table>

Settings should be stored in a file outside of MAWS

## FUNCTIONALITY

### DoseCheck

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
</table>




This functionality will end up being relatively complex, so we will be building it out in chunks. We will start out simple, and add complexity with each version.



## FUNCTIONALITY: UPCOMING DEVELOPMENT

## ID CHECK

## SITE CLOSURE

## SUBSCRIBER POLICY NUMBER WHITESPACE

## DAY OF WEEK VERFICATION

## BATCH USER DEACTIVATE






## Exception closed dispensing

### Process
* Fast Dose Dispensing form
* Get the content of the Dispense History field
* Get the historical dates
* Loop through the historical dates and see if any match the Dispense Date
  * All dates, or a specific number of dates?
* If yes, error
  * If no, continue

Dispensing History field = scrolling text field (10008)
Dispensing Date field = date field (10007)

### Test plan
*

### Next steps:
* Rebecca and Odete

## Christine's request
* Admission (Outpatient)
* Choose a PA episode > Edit
* If the Preadmit/Admission date is empty, don't do anything
* If the Preadmit/Admission date == system date, don't do anything
* If the Preadmit/Admission date != system date:
  * Warn user to modify date
  * Warn again!

### Test plan
*

### Next steps
* Christine: Admission or Admission (Outpatient) form?