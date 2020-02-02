# LoggerMicroservice
A .NET Core web api logger microservice that logs an id, message and date time stamp to a text file

- Implement a LoggingController with post method that uses a static logger utility class to call the relevant logger service
- Publish the .NET core web api project to IIS using the 'Publish to Folder' option under the "C:\inetpub\wwwroot\Logger" local path

	Setup specific binding for the website (for example to port 5001) as indicated below and use an application pool under the .NET CLR version of “No Managed Code“. Since IIS only works as a reverse proxy, it isn’t actually executing any .NET code. 
	
	![Screenshot](https://github.com/tapashya/LoggerMicroservice/blob/master/IISConfigurationForMicroservice.PNG)
	
- Use Postman tool to test post calls to the web api microservice using the port used in the step above as indicated

	![Screenshot](https://github.com/tapashya/LoggerMicroservice/blob/master/Postman.PNG)
	
- Setup a console app that sends log requests to the microservice. Refer to use of port and url setup based on IIS config above
	
	![Screenshot](https://github.com/tapashya/LoggerMicroservice/blob/master/TestSuccessConsoleApp.PNG)
