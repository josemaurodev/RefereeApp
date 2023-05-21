# RefereeApp
Neil Cummings Course C#

README OBJECTIVE:
    - Going to be write so I can understand what am I doing. 
    - It may help you run or understand this project too. 

COMMANDS: 
    - dotnet run: Starts the API.
    - dotnet watch run: Starts the api with the hotreload feature enabled.

FOLDERS:
    - Data
    - Entities: 
        - If this were MVC, the entities would be our Model. So here we specify all the models from the real world into C# classes.
    - Controller:
        - Where are the endpoints. When someone do an Http Request to our API, it will go to here. Basically, it will do whatever is described in the request endpoint. 
        - By convention, the controller for every Entities is the name of the entity, in plural, follewed by the world Controller. ex. User -> UsersController.
    - Properties: 
        - There is a file here called launchSetting.json. This is the file that first run in our API, all the info and configuration for it to begin to work is allocated here. 
        - If we have more than one PROFILE, it will choose automatically the first one to run. In my case, if I run the API with the dotnet run command, it will start on 
        http://localhost:5000, cause "api" is the first profile on the list. 
        - To make the HTTPS profile Work, you should go to CMD/Prompt -> certmgr.msc, then click on Personal > Certificates, delete all localhost certificates and then do the dotnet dev-certs https and dotnet dev-certs https --trust.
        - If youd did all properly, you could just run the command now, without the need to specify any profile. 

FILES:
    - RefereeAPI.csproj:
        - Where you got your Framework for .NET set. 
    - appsettings.Development:  
        - Where you get your configurations to run the api only in Devolopment mode, so you can't see it on production. 
    - appsetting: 
        - Your production environment configurations file.        
    - Program.cs: 
        - Your main entrypoint to the application. 


Nuget: 
    - You will need three different Nugest to run this application:
        - Microsoft.EntityframeWork.SqlLite
        - Microsoft.EntityframeWork.Design
            - If you'r in the VSCode you'r going to need to add on extension to be able to install this Nuget Packages. The one that I'm running myself is NuGet Gallery, from pcislo.
        - The third one you should install via "https://www.nuget.org/packages/dotnet-ef/", the .NET CLI(global) version.
