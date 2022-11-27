# Final Project CAS in Objectoriented Programming


TimeChecker app with .NET WPF and ASP.NET to track and save time spendings. Desktop UI with WPF, SQLite Database for Testing and ASP.NET Frontend for managing database data saved through the desktop app.


## How to start

**Important**: Clone the "Dev_Test" branch - had problems between this branch and master I need to fix!! Sorry for inconvenience
**Start Up Projects**: TimeChecker & TimeCheckerWpf5.0

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




## TimeChecker Desktop and Webapp

![solution1](https://user-images.githubusercontent.com/93710089/204139536-c13de197-f2ac-4a4c-baa1-694cec1b3dde.JPG)

## Web App Employees

![web_employees](https://user-images.githubusercontent.com/93710089/204139548-e50af0ac-7ab8-43ed-8a7e-5e244ede0f28.JPG)

## Web App Admin

![web_admin](https://user-images.githubusercontent.com/93710089/204139559-2d94d548-0ecd-471b-be58-93ef798a9992.JPG)

## Desktop Time Checker Login

![Desktop Login](https://user-images.githubusercontent.com/93710089/204139574-cd85b434-04ea-498b-a8cb-6fbd0bc101a4.JPG)

## Desktop Time Checker Checkin, Start Break, Stop Break, Check Out

![Desktop Checked](https://user-images.githubusercontent.com/93710089/204139605-dbb37046-4984-423c-b64e-36a7e2eb47eb.JPG)

![Checkout](https://user-images.githubusercontent.com/93710089/204139599-658188af-a01d-446e-a841-d3fc333d0568.JPG)

## Desktop Time Checker, elapsed times overview

![Esalpsed Times](https://user-images.githubusercontent.com/93710089/204139629-5f461506-df86-4e37-94a9-46afbd914c83.JPG)

## Desktop Time Checker, login and process with other user

![Second Login](https://user-images.githubusercontent.com/93710089/204139646-fd550255-27a1-414f-97f5-26a984ca87ee.JPG)

![Other User Data](https://user-images.githubusercontent.com/93710089/204139655-ff6f7fc9-b9da-4c80-aaee-ed716c04c966.JPG)

![OtherUserElapsedTimes](https://user-images.githubusercontent.com/93710089/204139663-7852b614-7d3c-459e-9d7c-668b6275a0ab.JPG)



## Team
A big shout out to my teammate:
<ul>
<li>Jose Panov https://www.linkedin.com/in/jose-panov-227727216/</li>
</ul>
