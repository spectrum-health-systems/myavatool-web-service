# MAWS Development
This document contains development information and notes.

### Read the manual!
The [MAWS Manual](https://github.com/spectrum-health-systems/MyAvatoolWebService/blob/main/doc/man/manual.md) is updated with each release.

[ABOUT THE SOURCECODE](#about-the-sourcecode)


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
