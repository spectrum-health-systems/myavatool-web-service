# MAWS: Roadmap

## FRAMEWORK

### MAWS GUI
<table>
  <tr>
    <th>NAME</th>
    <td>MAWSGUI</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>A GUI for MAWS.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD</td>
  </tr>
    </tr>
    <th>STATUS</th>
    <td>---</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>TBD</td>
  </tr>
</table>

A GUI control panel for MAWS

## FUNCTIONALITY

### IdCheck

<table>
  <tr>
    <th>NAME</th>
    <td>IdCheck</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Verify that the current client is who they say they are.</td>
  </tr>
    <th>DETAILS</th>
    <td>This isn't easy, and there are probably better 3rd-party solutions, so the idea here is to do something simple, like require staff to enter the last 4 digits of a SSN.</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>TBD</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>TBD</td>
  </tr>
</table>

### SiteClosure

<table>
  <tr>
    <th>NAME</th>
    <td>SiteClosure</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Ensure clients don't get additional medication when a site is closed due to an emergency.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD.</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>
      FORM: Fast Dose Dispensing FIELD: "Dispensing History field" FIELD_ID: 10008<br>
      FORM: Fast Dose Dispensing FIELD: "Dispensing Date field" FIELD_ID: 10007
    </td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>TBD</td>
  </tr>
</table>

Field 10008 is a scrolling text field.
Field 10007 is a date field.

On the Fast Dose Dispensing form:
* Get the content of the Dispense History field
* Get the historical dates
* Loop through the historical dates and see if any match the Dispense Date
  * All dates, or a specific number of dates?

If yes: error
If no: continue

Dispensing History field = scrolling text field (10008) Dispensing Date field = date field (10007)

### SubscriberPolicyNumberWhitespace

<table>
  <tr>
    <th>NAME</th>
    <td>SubscriberPolicyNumberWhitespace</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Check the input for subscriber policy number in Cross Episode Financial Eligibility for leading/trailing whitespace. If a policy number has a leading/trailing whitespace this could fail a file.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD.</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>TBD</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>TBD</td>
  </tr>
</table>

This is a text field that can be either numeric or alphanumeric. The data element number is 263. If we could warn the user or ideally trim the leading/trailing spaces that would be ideal. 

### VerifyDayOfWeek

<table>
  <tr>
    <th>NAME</th>
    <td>VerifyDayOfWeek</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Verify that it is a specific day of the week.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD.</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>TBD</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>TBD</td>
  </tr>
</table>

### BatchUserDeactivate

<table>
  <tr>
    <th>NAME</th>
    <td>BatchUserDeactivate</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Deactivate a list of myAvatar users.</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD.</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>TBD</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>TBD</td>
  </tr>
</table>

### PreAdmissionEpisodeEditedForAdmission

<table>
  <tr>
    <th>NAME</th>
    <td>PreAdmissionEpisodeEditedForAdmission</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>TBD</td>
  </tr>
    <th>DETAILS</th>
    <td>TBD.</td>
  </tr>
  <tr>
    <th>FORMS/FIELDS</th>
    <td>TBD</td>
  </tr>
  <tr>
    <th>TARGET RELEASE</th>
    <td>TBD</td>
  </tr>
</table>

Admission (Outpatient)
Choose a PA episode > Edit
If the Preadmit/Admission date is empty, don't do anything
If the Preadmit/Admission date == system date, don't do anything
If the Preadmit/Admission date != system date:
Warn user to modify date
Warn again!

## OTHER
* Confirm all references to *OptionObject2* are replaced with *OptionObject2015*

* OptionObjectMaintenance.cs
    * Do we/should we to return the "finalizedOptionObject" from each method? Currently we don't, and things work, but it may be clearer if we break things down a bit
    * Where did we get required/recommended/notrecommended from?
    * OptionObjectMaintenance.Finalize()
        * This method, and the methods it calls, should be more efficient. Currently it relies on brute force.
        * Maybe do the work with a "workerOptionObject", then at the end copy that over to "finalizedOptionObject"

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

* documentation
    * other projects
    * OO2

* Other abbreviations:
    * Outpatient = outpt 

* Do the $"{}" thing with strings

* Update docs with standard ids