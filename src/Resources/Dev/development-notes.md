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
    <td>FORM: Quick Medication Order FIELD: Dosage 1(mg) FIELD_ID: 107<br>
    FORM: Quick Medication Order FIELD: Dosage 1(mg) FIELD_ID: 107<br>
    FORM: Quick Medication Order FIELD: Dosage 1(mg) FIELD_ID: 107</td>
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