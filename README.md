# SimplSharpTools

A collection of utility classes for use in SIMPL# libraries, including:

- `Platform` for determining if the code is running on Crestron hardware or another platform.

- `Logger` for writing messages to the Crestron log if the code is running on Crestron hardware.

- `ConsoleDebugger` for printing debugging messages to the Crestron Console on Crestron hardware or standard console on other platforms.

- `SPlusBool` for working with `ushort` values to/from SIMPL+ that are used as booleans.


## Add from Github packages

1. In Visual Studio, go to _Tools > Nuget Package Manager > Package Manager Settings_

2. Select _Package Sources_ from the list on the left side

3. Click the `+` button near the top-right corner

4. Select the newly created package source entry in the list and set the `Name` and `Source` fields (at the bottom of the settings window) to `GitHub (fasteddy516)` and `https://nuget.pkg.github.com/fasteddy516/index.json`, then click `OK`.

5. When asked to authenticate, use your GitHub username and a GitHub Personal Access Token (with `read: packages` enabled)

6. Now when you navigate to _Tools > Nuget Package Manager > Manage Nuget Packages for Solution..._ you should be able to select _GitHub (fasteddy516)_ from the _Package Source_ dropdown in the top-right corner of the window.  If you select the _Browse_ tab you should see packagaes published to my GitHub package registry.


## Add From a Local Feed

1. If you don't already have a local nuget feed set up, create a folder on your machine for local nuget packages.  I typically use   
   `%USERPROFILE%\source\nuget` as that puts it close to where Visual Studio likes to place my Git repositories by default.
   
2. Place [`SimplSharpTools.X.Y.Z.nupkg`](https://github.com/fasteddy516/SimplSharpTools/releases/latest) in the nuget folder
   
3. In Visual Studio, go to _Tools > Nuget Package Manager > Package Manager Settings_

   a. Select _Package Sources_ from the list on the left side

   b. Click the `+` button near the top-right corner

   c. Select the newly created package source entry in the list and set the `Name` and `Source` fields (at the bottom of the settings window) to `Local Feed` and the path to your nuget folder, then click `OK`.

   d. Now when you navigate to _Tools > Nuget Package Manager > Manage Nuget Packages for Solution..._ you should be able to select _Local Feed_ from the _Package Source_ dropdown in the top-right corner of the window.  If you select the _Browse_ tab you should see any packages you've placed in the nuget folder.


## Building From Source

To build the nuget package from source, you'll first have to build the Visual Studio 2022 solution in _Release_ configuration (not _Debug_).  After that, just run `nuget pack` in the solution root folder, which will generate `SimplSharpTools.X.Y.Z.nupkg`.  This can be added into another solution using the _Add From a Local Feed_ method outlined above.

If `nuget` is not installed on your machine, you can download it from [nuget.org](https://www.nuget.org/downloads) or use [Scoop installer](https://scoop.sh/) with the command `scoop install nuget`.  
