# CmpSurvey-


The purpose of this test application is to use sample survey test data to create a working Front end webapp solution which can be used to accomplish the following tasks:
1. Display the list of surveys which is obtained from the database
2. Select a survey out of the list of surveys to view all its questions and options 

## Live application
The application is also deployed on cloud and can be viewed in the following URL -> https://devant.azurewebsites.net/

## Launching the application - locally

Steps - Local development setup 

Environment setup
1. Install Visual studio 17 
2. Download application code using git command line tool -> git clone  <application git url>
3. Navigate inside the project structure and open the CompassSurveyTestApp.sln file in Visual Studio 

Database Setup
1. Install Microsoft SQL Server Management studio 
2. Create a local database server with the name -> (localdb)\ProjectsV13
3. Create a local database by the name "CompassDB" by connecting to the local development server in Microsoft SQL Server Management studio 
4. After the database is created, right click the database and select new query 
5. Run the setup script CompassDB_setup.sql located inside the scripts folder by copy pasting its contents using the execute button 
6. After running the script, the database should have 3 tables with the names - Survey, Questions and Options and should have some sample data present in them.

Launch Application 
1. After completing the above steps, compile and run the application using the IIS Express launch button located in Visual studio.
2. A new browser window should open and should display the home screen of the application 


