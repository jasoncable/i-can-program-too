# Reusable .NET Components

.NET has always provided a rich set of frameworks based on the .NET Framework.  Today, many of these are open source projects and available free of charge.  This is only a partial listing of some of the available frameworks for use in the .NET ecosystem.  Apologies in advance for any omissions.

## Frameworks on Frameworks

There are many packages that were developed by Microsoft and the Mono team \(now part of Microsoft\) that should be noted here.

### LINQ

Language integrated query \(LINQ\) is implemented partially in the C# language and partially in the .NET framework libraries.  It provides the ability to write queries against collections and databases.  There are two primary interfaces for writing LINQ queries.  The first allows for the writing of queries directly into the source files without the use of framework libraries and methods.  The second provides a fluent interface to perform most of the same operations.  The underlying technology of the implementation uses a concept called _expression trees_.

### System.Xml

Microsoft's .NET Framework development has always been extremely stringent in the area of consistently implementing APIs in a consistent manner.  Nulls and exceptions, for example, tend to be handled in a consistent manner throughout the entire framework.  Their goal was to create a comprehensive set of APIs that are used in the same manner.  The first API to break that standard was that of the technologies contained within `System.Xml`.  They were largely based on existing XML handling methods contained in the MSXML library.

`System.Xml` provides objects and methods for reading, writing, and manipulating XML.  XML may be read into a DOM, read/written quickly in the XmlReader/XmlWriter classes, transformed via the built-in XSLT library, and traversed using XPath.  Aside from LINQ, this author believes that the framework XML libraries have the highest learning curve.

### ADO.NET \(.NET Framework, Windows\)

ADO.NET is the traditional data access method for providing access to databases.  Available in the .NET Framework only, built-in database providers include ODBC, SQL Server, and Oracle Database.  ADO.NET is the successor to ADO, RDO, and ODBC as included in the MDAC.  There are a number of 3rd party providers for ADO.NET for just about any database that is in active development.

### ADO.NET \(.NET Core, Cross-platform\)

ADO.NET's features are available for SQL Server connections in .NET Core version 2.0 and greater.  The .NET Framework providers will generally not work unless they have been updated to do so.

### Entity Framework 6.x \(.NET Framework, .NET Core, Cross-platform\)

Entity Framework 6.x \(EF6\) is an object relational mapping \(ORM\) tool to make database access less time consuming and error prone.  It also provides a modern API closely integrated with LINQ.  Entity Framework translates data from databases, relational and other, to be transformed into queryable objects.  It also handles the translation from database data types to CLR types, as these are never 1-to-1.  Many providers are available for the Entity Framework to access various databases such as SQL Server, MySQL, and Sqlite.  The Entity Framework was not necessarily meant to replace ADO.NET, but to make it easier for .NET developers to create data-driven applications using familiar C#/.NET Framework concepts.  

EF6 supports two primary paths of database development.  The first involves creating the database, then using the EF6's code to generate C# classes that provide the interface between .NET and the database \("database-first"\).  In "code-first" development, one first designs the database as an object model using a mixture C# classes and attributes on classes and class members.  The second step is to execute a process to build the database from the object model that was created.

EF6 has been modified to work under both the .NET Framework and .NET Core.  The various providers are not guaranteed to run on both platforms.  As of this writing, no new features are planned for EF6, but there is a good chance that this will change, especially with the effort expended on porting EF6 to .NET Core.

### Entity Framework Core

Entity Framework Core \(EF Core\) is a re-write of Entity Framework 6.x.  It was meant to totally replace EF6 with a substantially similar API.  EF Core is primarily developed by the same team at Microsoft that developed EF6.  For .NET Core, the decision to scrap EF6 was made to streamline the development process, remove technical debt, increase performance, and ease provider development.  

As of this writing, some basic features such as being able to map database views to objects is still not supported.  It was de-prioritized to fixate on creating non-EF6 features such as the handling of SQL Server spatial data.  At this point, it is unknown when or if EF Core will reach feature parity with EF6.  As a stopgap measure to increase the porting of database-centric applications to .NET Core, EF6 was ported to .NET Core.

### ASP.NET \(.NET Framework, Windows\)

ASP.NET was Microsoft's first incarnation of .NET Development for the web.  It is still supported, but consider it deprecated.  New features have not been added in several years.  It was created as a replacement for "Classic" ASP.  You will still find websites that use file extensions of `.asp`.  These are Classic ASP.  Files ending in `.aspx` and `.asmx` refer to ASP.NET.  It is not recommended for new projects.

### ASP.NET MVC \(.NET Framework, .NET Core, Cross-platform\)

ASP.NET MVC \(MVC\) is the current framework used for server-side web application development.  It is a successor to ASP.NET.  MVC on the .NET Framework has not introduced new features in several years.  The .NET Core version adds rich new features that breathe life into the aging framework.  MVC is a design pattern called model-view-controller.  Other similar patterns can be used with ASP.NET MVC such as MVP and MVVM.

### WCF \(.NET Framework, Windows-only\)

Windows Communication Foundation \(WCF\) includes tools to build XML-based web services.  These are used to create APIs that are called over HTTP\(s\).  The common language of XML forms the foundation of an architectural idea called Service Oriented Architecture \(SOA\).  Its use in new applications has been supplanted by WebAPI.

### WebAPI \(.NET Framework, .NET Core, Cross-platform\)

WebAPI is the successor to WCF.  It provides much easier programming paradigm for messaging over HTTP\(s\).  WebAPI sits on top of ASP.NET MVC's backbone, using common concepts such as controllers.  It is able to accept and return messages in both JSON and XML formats.  WebAPI uses an automatic serialization mechanism to convert the JSON data into .NET objects.  Most basic .NET types are supported for serialization including arrays, generic lists, C# built-in types \(int, string, etc.\), `DateTime`s, `DateTimeOffset`s, and `Guid`s.

### SignalR \(.NET Framework, .NET Core, Cross-platform\)

SignalR is a very different product on .NET Framework and .NET Core.  The APIs are incompatible.  SignalR provides a means of _pushing_ data from a server _to_ a client such as a web browser.  Web browsers have always pulled data from and pushed data to web servers.  SignalR provides an asynchronous way of sending message.  It primarily uses the web standard called Web Sockets, which is supported by the current version of all major browsers.  SignalR may also be used to push data to Java web applications and Node.js applications.  SignalR is a part of the ASP.NET projects, both Framework and Core.

### WinForms \(.NET Framework, .NET Core, both Windows-only\)

WinForms is the classic platform for Windows GUI Application Development.  It is mature on the .NET Framework, is still supported, yet is not receiving many new features.  High-DPI support has recently be added.  It is perfectly good to use WinForms for new projects.  .NET Core 3.0 provides a pseudo-translation layer that allows it to be run under .NET Core.  WinForms is the successor to Visual Basic 6 GUI apps.  WinForms applications run on all versions of Windows.

### WPF \(.NET Framework, .NET Core, both Windows-only\)

Windows Presentation Foundation \(WPF\) is Microsoft's second generation framework for GUI development.  It uses an XML-based UI builder language called XAML.  It may be used for new development.  It was meant to be a successor to WinForms.  WPF applications run on all versions of Windows.

### UWP \(.NET Framework, Windows 8.1 and 10 based OSs only\)

The Universal Windows Platform \(UWP\) development SDK is the latest GUI development paradigm from Microsoft.  UWP applications only run on Windows 8.1, Windows 10, the defunct Windows Phone OSs, the Xbox One series, and Windows Server 2012 and up.  UWP has not gained the popularity that Microsoft has wished.  Its applications are primarily distributed through the Windows Store.  The "Universal" in UWP is meant to denote that applications written in this environment will run on all supported platforms.  For example, a calculator app written in UWP should run equally as well on Windows 10 and on the Xbox One X.

### Xamarin.Android \(Mono-based, simulator and Android devices\)

.NET development platform for Android devices.  This package uses Android's integrated UI components and has great access to the latest Android APIs.  Xamarin.Android apps can be developed, tested, built, and packaged in Visual Studio and Visual Studio for Mac.  It uses the Android SDK.

### Xamarin.iOS \(Mono-based, macOS with XCode required\)

.NET development platform for iOS, watchOS, and tvOS devices.  This package uses the OS's integrated UI components and has great access to the latest APIs.  Support for the latest OS is generally available within a few days of their release.  While Xamarin.iOS applications may be developed on Windows and macOS, access to a machine running macOS running XCode is required for building, debugging, previewing, and packaging apps.

### Xamarin.Forms \(Mono-based, Android and macOS rules apply\)

Xamarin.Forms is based on a dialect of the XAML that is used in WPF.  It provides cross-platform UI development for the iOS family, macOS, Windows UWP on Windows 10, GTK#, and WPF.  If your application is mostly a UI that accesses basic data and uses few algorithms, you may have as little as 10% reusable code between applications.  If your app is primarily driven by advanced data access and complex algorithms, as much as 90% of your code can be reused between platforms.  Xamarin.Forms does not have the best access to native UI elements or native APIs.  If you primarily target only iOS or only Android, it may be a better choice to use Xamarin.iOS or Xamarin.Android.

### Xamarin.Mac \(Mono-based, macOS only\)

Xamarin.Mac provides much of the same functional of Xamarin.iOS, except for macOS instead of iOS.

### Windows Compatibility Pack for .NET Core

This NuGet package enables Windows .NET Core developers to use APIs that are specific to Windows only.  It allows developers to easily port software that relies on things like WMI, the Windows Registry, the `System.Drawing` namespace \(based on GDI+\), etc.  Applications that use this package will only run on Windows.  This package, `Microsoft.Windows.Compatibility` is available on NuGet.

## The Reporting Gap

While we have seen many examples of technologies that do not translate from Windows to other operating systems, most of them can now be run under .NET Core.  The exception, as of this writing, continues to be in the area of reporting components.  All reporting libraries from Microsoft and the third-party .NET developers only support the .NET Framework.  This is because most use the `System.Drawing` namespace's classes two draw charts and graphs.  These rendering libraries all rely on a library called GDI+, which is only available on Windows.  Microsoft does have plans to develop a reporting library written in .NET Core, but it is not certain exactly when that will happen.  Until then, code written to create reports will have to run under the .NET Framework's runtime.

## Third-party .NET Developers

There are many companies that publish paid UI and other components.  This is not meant to be a comprehensive list.  Many of the following companies have been developing components for Windows-based development for close to 20 years.  Most provide UI controls and grid solutions for WinForms, WPF, UWP, ASP.NET, ASP.NET MVC, and JavaScript.

* DevExpress - <https://www.devexpress.com/>
* GrapeCity \(and formerly ComponentOne\) - <https://www.grapecity.com/>
* Progress \(and formerly Telerik\) - <https://www.progress.com/>
* SyncFusion - <https://www.syncfusion.com/>
* Infragistics - <https://www.infragistics.com/>

## NuGet

NuGet \(<https://www.nuget.org/>\) is a package repository for mostly free, mostly open source .NET reusable server and UI components.  NuGet is free to use and is built-in to Visual Studio and Visual Studio for Mac.  Many NuGet packages now support .NET Core and .NET Framework, especially since the introduction of .NET Standard.  While created an maintained by Microsoft, NuGet features APIs from mostly non-Microsoft developers.  NuGet is Microsoft's response to create a repository of reusable .NET software in the tradition of the first two package managers, CTAN and CPAN.  NPM is the JavaScript equivalent. Many other languages and environments have their own package repositories.

There is no cost to distribute your software via NuGet.  Packages can be created manually with `NuGet.exe` or from Visual Studio with some help from `NuGet.exe`.
