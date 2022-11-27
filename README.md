# Final Project CAS in Objectoriented Programming


TimeChecker app with .NET WPF and ASP.NET to track and save time spendings. Desktop UI with WPF, SQLite Database for Testing and ASP.NET Frontend for managing database data saved through the desktop app.


## How to start
To be able to use the TimeChecker Solution, the following steps have to be taken during the first use
must be done during the first use:

1. create and migrate SQL database:
In order for records to be written to the database, it must be created.
Enter the following commands in the Package Manager Console:

1.1 Add-migrations (your name)

![setUp1](https://user-images.githubusercontent.com/93710089/204137935-d0638113-b422-46c8-8242-aabb4c9bff2f.JPG)

1.2 update-database

![setUp2](https://user-images.githubusercontent.com/93710089/204137940-647a07ee-1553-4b58-9a00-a7faa5e6216a.JPG)

The following tables must now be present: "Employees" and "Timeentry".


2. create login account WebApp:
In order to view the data from the database, the user must register and log in to the WebApp.
and log in. However, only the admin user has the right to edit and delete records.
and delete them.
Credentials for an Admin:
Email: admin@bluewin.ch
Passwort: Test1.

![setUp3](https://user-images.githubusercontent.com/93710089/204137977-987398b6-921d-4a48-b642-b407b813e129.JPG)

Create a TimeChecker WPF app user:
The app requires at least one user
(A "User" corresponds to an "Employee" record in the database). Before the WPF app can be used
can be used for the first time, a user must first be created via the WebApp.
must be created
3.1 Start WebApp, open "Employee" view
3.2 Use "+Create Employee" to create a new employee.

![image](https://user-images.githubusercontent.com/93710089/204138004-880881e4-be5e-479b-b42e-34d4d4f45cfb.png)

As soon as at least one employee exists in the database, the TimeChecker WPF app can be used.
can be used.


## Team
A big shout out to my teammate:
<ul>
<li>Jose Panov https://www.linkedin.com/in/jose-panov-227727216//</li>
</ul>
