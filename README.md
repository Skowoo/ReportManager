# ReportManager
Simple web application to manage bug reports. Created as semestral project for ASP.NET programing class. The main functionalities are CRUD operations for a simple relational data set stored in SQL database and customized simple case of AspNetCore Identity managment.
Application Database model consists of 4 relative entities of which Report is the main one. Search and sorting is implemented for RecordEntry.

### Used packages:
* AspNetCore.Identity 8.0.0
* AspNetCore.EntityFrameworkCore 8.0.0

### Deployment:
During startup application should deploy database automatically using default connection string: 
```
Server=(localdb)\\mssqllocaldb;Database=ReportManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true
```
Automatic deployment method also seeds created database with:
* Sample data set:
  * 5 example Categories
  * 5 Example Projects
  * 5 Example Persons
  * 100 Example reports with randomly assigned projects, reports and persons
* Two Roles:
  * Administrator with full access to Create, modify and delete all data
  * User which can only create new report or see existing ones.
* Two users:
  * Admin:
    * Login: Admin
    * Password: Admin
    * Role: Administrator
  * User:
    * Login: User
    * Password: User
    * Role: User
  
