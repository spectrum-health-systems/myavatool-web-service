# Deploying MAWS to IIS

## Deploying a clean copy

### Using Visual Studio 2019
1. Load the MyAvatoolWebService.sln
2. Clean the solution
3. Rebuild the solution.
4. Copy the these files to the IIS folder that hosts MAWS:
```
\src\AppData\*
\src\bin\*
\src\MyAvatoolWebService.asmx
\src\MyAvatoolWebService.asmx.cs
\src\packages.CONFIG
\src\Web.CONFIG
\src\Web.Debug.CONFIG
\src\Web.Release.CONFIG
```
5. Verify you can get to the WSDL. If you can't, verify that "Directory Browsing" is enabled for the folder that hosts MAWS in the IIS manager.
6. If there were any modifications to the MAWS .conf files, copy those to the IIS server