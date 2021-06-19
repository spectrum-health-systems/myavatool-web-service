# MAWS: Development Notes

## FUNCTIONALITY: CURRENT DEVELOPMENT

| NAME | DESCRIPTION |
| ---- | ----------- |
| DoseCheck | Verify that the current medication dose is within specific boundries |


### DoseCheck

<table>
  <tr>
    <th>Fruit</th>
    <td>Banana</td>
  </tr>
  <tr>
    <th>Vegetable</th>
    <td>Carrot</td>
  </tr>
</table>




This functionality will end up being relatively complex, so we will be building it out in chunks. We will start out simple, and add complexity with each version.

Confirm that the current medication dose:

1. Does not exceed X% of the previous dose
AND/OR
2. Does not exceed Xmg of the previous dose
AND
3. Does not exceed Xmg


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