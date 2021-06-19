# MAWS: Development Notes

## FRAMEWORK

### Testing platform
<table>
  <tr>
    <th>NAME</th>
    <td>Test platform</td>
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

We should be able to develop new/modify current MAWS functionality without over-complicating the testing of said functionality. The idea here is to embed testing code into the production codebase, and access that when testing. When testing is complete, the verified code is copied to the production codebase.

This is an ongoing project which will span multiple MAWS versions.

### External logging
<table>
  <tr>
    <th>NAME</th>
    <td>External logging</td>
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

MAWS should log stuff, for example:
* When a specific function is called
* Values of a specific function
* Who called it

Also, maybe include metrics where we can see how often/how many times a specific function is called.

### External settings
<table>
  <tr>
    <th>NAME</th>
    <td>External settings</td>
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

Settings should be stored in a file outside of MAWS

### Efficient looping
<table>
  <tr>
    <th>NAME</th>
    <td>Efficient looping</td>
  </tr>
  <tr>
    <th>DESCRIPTION</th>
    <td>Clean up the OptionObject search loop.</td>
  </tr>
    <th>DETAILS</th>
    <td>Looping through the OptionObject is currently very inefficient.</td>
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
  <tr>
    <th>TARGET RELEASE</th>
    <td>v0.9</td>
  </tr>
</table>

This functionality will end up being relatively complex, so we will be building it out in chunks. We will start out simple, and add complexity with each version.