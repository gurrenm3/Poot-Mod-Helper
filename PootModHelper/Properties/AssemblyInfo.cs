using MelonLoader;
using PootModHelper;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(MyMod.modName)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct(MyMod.modName)]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Melonloader stuff
[assembly: MelonInfo(typeof(MyMod), MyMod.modName, MyMod.modVersion, MyMod.modAuthor)]
[assembly: MelonGame("XSEED Games _ Marvelous USA, Inc.", "STORY OF SEASONS Pioneers of Olive Town")]

[assembly: MelonColor(ConsoleColor.Blue)]
[assembly: MelonPriority(-1000)]
[assembly: AssemblyInformationalVersion(MyMod.modVersion)]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("0fa5b80e-d499-4971-980c-3d1447bea75f")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(MyMod.modVersion)]
[assembly: AssemblyFileVersion(MyMod.modVersion)]
