# Development Notes


## Exception closed dispensing

### Process
* Fast Dose Dispensing form
* If Number of Outstanding Take Out Bottles >= 1
  * Get the content of the Dispense History field
  * Get the historical dates
  * Loop through the historical dates and see if any match the Dispense Date
    * All dates, or a specific number of dates?
  * If yes, error
    * If no, continue

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

### Next steps:
* Christine: Admission or Admission (Outpatient) form?