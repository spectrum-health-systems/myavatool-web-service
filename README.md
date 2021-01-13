<!--
  GitHub repository template (b210103)
  https://github.com/APrettyCoolProgram/my-development-environment/tree/master/templates/github/
-->
<h6 align="center">

  <img src="https://img.shields.io/badge/WARNING:-THIS%20IS%20BETA%20SOFTWARE-%23990000?style=for-the-badge">
  
</h6>

***

<h3 align="center">

  <img src="resources/asset/img/logo/maws-logo-800x150.png" alt="MyAvatool Web Service logo" width="800">
  <br>
  <br>
  A custom web service for Netsmart's myAvatar™ EHR
  <br>

</h3>

<h3 align="center">

  <img src="https://img.shields.io/badge/status-active-brightgreen">&nbsp;
  [![License](https://img.shields.io/github/license/spectrum-health-systems/myavatool-web-service)](https://www.apache.org/licenses/LICENSE-2.0)&nbsp;
  [![GitHub release](https://img.shields.io/github/v/release/spectrum-health-systems/myavatool-web-service)](https://github.com/spectrum-health-systems/myavatool-web-service/releases)&nbsp;
  [![Issues](https://img.shields.io/github/issues/spectrum-health-systems/myavatool-web-service)](https://github.com/spectrum-health-systems/myavatool-web-service/issues)&nbsp;
  [![Pulls](https://img.shields.io/github/issues-pr/spectrum-health-systems/myavatool-web-service)](https://github.com/spectrum-health-systems/myavatool-web-service/pulls)&nbsp;

</h3>

<h4 align="center">

  [MANUAL](doc/man/manual.md)&nbsp;&bull;&nbsp;[CHANGELOG](doc/changelog.md)&nbsp;&bull;&nbsp;[ROADMAP](doc/roadmap.md)&nbsp;&bull;&nbsp;[KNOWN ISSUES](doc/known-issues.md)&nbsp;&bull;&nbsp;[SUPPORT](doc/support.md)
  <br>

</h4>

<!-- The HTML indentations have to stay this way to work. -->
<table>
<tr>
<td img src="non-existant-spacer.png" alt="non-existant-spacer" width="1000" height="1">

  ### CONTENTS
  [ABOUT](#about)<br>
  [GETTING STARTED](#getting-started)<br>
  [INSTALLING](#installing)<br>
  [USING](#using)<br>
  [UPDATING](#updating)<br>
  [UNINSTALLING](#uninstalling)<br>
  [DEVELOPMENT](#development)<br>
  [ADDITIONAL INFORMATION](#additional-information)<br>

</td>
</tr>
</table>

# ABOUT
[Netsmart's myAvatar™](https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar) is a behavioral health EHR that offers a recovery-focused suite of solutions that leverage real-time analytics and clinical decision support to drive value-based care.

While myAvatar™ is a robust platform, like most things in life (except [Heroes of Might and Magic III](https://www.gog.com/game/heroes_of_might_and_magic_3_complete_edition)), it isn't perfect.

The good news is that myAvatar™ functionality can be extended via Netsmart's myAvatar™ Web Services, and/or custom web services that are written by myAvatar™ users.

The myAvatool Web Service (**MAWS**) is one such custom web service which includes various tools and utilities for myAvatar™ that aren't included in the official release, and provides a solid foundation for building additional functionality quickly and efficiently.

> **WARNING!** ***This is beta software!***

I'm working on getting MAWS v1.0 out the door, so for now this sourcecode in *very beta*.

If you are interested in the development of v1.0, please see the [development branch](https://github.com/spectrum-health-systems/myavatool-web-service/tree/development-v1.0).

If you are looking for something to use right now, check out the [Avatool Web Service](https://github.com/spectrum-health-systems/Avatool-Web-Service) (the precursor to MAWS).

## FEATURES
* Several built-in tools and utilities for use with myAvatar™
* A solid foundation to build additional custom tools and utilities

## REQUIREMENTS
* A location to host the Avatool Web Service which meets the following requirements:
  * .NET Framework 4.6+ installed
  * Access to your myAvatar™ environments from the Avatool Web Service via HTTPS

### Read the manual!
Hey now, I spent alot of time working on the MAWS [manual](doc/man/manual.md), so please take a look. I update the manual with each new release of MAWS, and it covers pretty much anything you need to know about MAWS (as well as some general myAvatar™ custom web services stuff).

# GETTING STARTED
### Before you begin
* Verify you have met the [requirements](#requirements).
* Read the MAWS [manual](doc/man/manual.md)!

# INSTALLING
### Windows
The Avatool Web Service isn't *installed* so much as it is *published*.

The current method of publishing the web service is to just copy the entire project to where it is being hosted. Future versions of the Avatool Web Service will utilize the publishing functionality of Visual Studio.

For more information about installing/publishing MAWS, please read the MAWS [manual](doc/man/manual-hosting-maws.md).

#### Other operating systems
Since MAWS used the .NET Framework, I'm pretty sure it's only compatible with the Windows operating system.

# USING
Please read the MAWS [manual](doc/man/manual.md) for information on using MAWS.

# UPDATING
Please read the MAWS [manual](doc/man/manual.md) for information on updating MAWS.

# UNINSTALLING
Please read the MAWS [manual](doc/man/manual.md) for information on uninstalling MAWS.

# DEVELOPMENT
MAWS is developed by [A Pretty Cool Program](https://aprettycoolprogram.com) and these [contributors](doc/contributors.md), using these [third-party resources](built-with.md).

You can find the current development branch of MAWS [here](https://github.com/spectrum-health-systems/myavatool-web-service/tree/development-v1.0).

To contribute to the development branch of MAWS, please see our [contributing guidelines](doc/contributing.md).

# ADDITIONAL INFORMATION
* [Acknowledgements](doc/acknowledgements.md)
* [Related projects](doc/related-projects.md)
* [Additional reading](doc/additional-reading.md)

***

<!-- DEVELOPMENT FOOTER -->
[![GitHub release date](https://img.shields.io/github/release-date/spectrum-health-systems/myavatool-web-service)](https://github.com/spectrum-health-systems/myavatool-web-service/releases)&nbsp;![Release downloads](https://img.shields.io/github/downloads/spectrum-health-systems/myavatool-web-service/total)&nbsp;![Language count](https://img.shields.io/github/languages/count/spectrum-health-systems/myavatool-web-service)&nbsp;
![Top language](https://img.shields.io/github/languages/top/spectrum-health-systems/myavatool-web-service)&nbsp;
![Repository size](https://img.shields.io/github/repo-size/spectrum-health-systems/myavatool-web-service)&nbsp;
[![Developed by](https://img.shields.io/badge/developed%20by-a%20pretty%20cool%20program-17806D)](https://aprettycoolprogram.com)&nbsp;
[![Feedback](https://img.shields.io/badge/feedback@aprettycoolprogram.com-17806D)](mailto:feedback@aprettycoolprogram.com)&nbsp;
[![GitHub](https://img.shields.io/github/followers/aprettycoolprogram.svg?label=GitHub&style=social)](https://github.com/aprettycoolprogram)&nbsp;
[![Twitter](https://img.shields.io/twitter/follow/aprettycoolprog.svg?label=Twitter&style=social)](https://twitter.com/aprettycoolprog)&nbsp;
[![Repository built using](https://img.shields.io/badge/README%20built%20using-a%20pretty%20cool%20README%20template-17806D.svg)](https://github.com/APrettyCoolProgram/my-development-environment/tree/development/templates/github)