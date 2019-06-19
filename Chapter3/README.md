# Hands-On-Design-Patterns-with-C-and-.NET-Core #
_A book with lot of practical and architectural styles for Microservices using .NET Core._

Hands-On Design Patterns with C# and .NET Core, published by Packt. 

##	Chapter-3: Inventory Application Overview ##
*	Project Kickoff and Requirements Gathering
*	Test Driven Development
*	Abstract Factory Design Pattern

### Instructions to use the code examples ###
Refer to the following detailed instructions to start with code-examples of this chapter:
 
#### Installation of Visual Studio ####
To run these code-examples you need to install Visual Studio; to do so, follow these instructions:
 
 1. Download Visual Studio from download link mentioned with installation instructions: https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019 
 2. Follow the installation instructions mentioned thereon.
 3. Multiple flavors are avaialble for Visual Studio installtion, we are using Visual Studio for Windowsndows.
 
#### Installation of SQL Server ####
In our all code examples, we are using SQL Server as DB server. Recommended version is SQL Server. For download and installation  refer: https://www.microsoft.com/en-au/sql-server/sql-server-downloads

#### Setting up of .NET Core 2.2 ####
If you did not have .NET Core 2.2 installed, you can install from the link: https://dotnet.microsoft.com/download/dotnet-core/2.2
 
#### Running an application (code example) ####
If you perform all previous steps without any errors, you are good to start your application, follow these steps:

 1. Run Visual Studio 
 2. File | Open | Project/Solution
 3. Select any of the solution available in repository
 4. Click open
 5. Now, go to *Startup.cs* and verify your db connection string inside `ConfigureServices` method (required for examples with database) - you might need to update the credentials `(Note: this step required for projects that are using Database.)`
 6. Click Run or hit F5
 
 Enjoy coding!
