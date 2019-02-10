# Hands-On-Design-Patterns-with-C-and-.NET-Core #
_A book with lot of practical and architectural styles for Microservices using .NET Core._

Hands-On Design Patterns with C# and .NET Core, published by Packt. 

##	Chapter-7: Implementing Design Patterns for web applications - Part 2 ##
*	CRUD pages
*	Authentication and Authorization, Page for viewing inventory types, Page for adding a new inventory,Page for viewing inventory quantity including Add Quantity and Remove Quantity
*	Testing the web application

### Instructions to use the code examples ###
Refer to the following detailed instructions to start with code-examples of this chapter:
 
#### Installation of Visual Studio ####
To run these code-examples you need to install Visual Studio 2017 Update 3, or later (preferred IDE); to do so, follow these instructions:
 
 1. Download Visual Studio 2018 from download link mentioned with installation instructions: https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio 
 2. Follow the installation instructions mentioned thereon.
 3. Multiple flavors are avaialble for Visual Studio installtion, we are using Visual Studio for Windowsndows.
 
#### Installation of SQL Server ####
In our all code examples, we are using SQL Server as DB server. Recommended version is SQL Server 2018 R2 or later. For download and installation instructions refer: https://blogs.msdn.microsoft.com/bethmassi/2011/02/18/step-by-step-installing-sql-server-management-studio-2008-express-after-visual-studio-2010/

#### Setting up of .NET Core 2.0 ####
If you did not have .NET Core 2.0 installed, you need to follow these instructions:

 1. Download: https://www.microsoft.com/net/download/windows
 2. Installation instructions: https://blogs.msdn.microsoft.com/benjaminperkins/2017/09/20/how-to-install-net-core-2-0/

#### Running an application (code example) ####
If you perform all previous steps without any errors, you are good to start your application, follow these steps:

 1. Run Visual Studio 
 2. File | Open | Project/Solution
 3. Select any of the solution available in repository
 4. Click open
 5. Now, go to *Startup.cs* and verify your db connection string inside ConfigureServices method (required for examples with database) - you might need to update the credentials 
 6. Click Run or hit F5
 
 Enjoy coding!
