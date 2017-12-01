# Learning Support System 

## Motivation

This is the final project for the course [Practical Teamwork](https://softuni.bg/trainings/1799/practical-teamwork-sept-2017) in [SoftUni.bg](https://softuni.bg/about).

## The Team :)

* [Mirela Damyanova](https://github.com/mdamyanova)
* [Svilen Yanovski](https://github.com/SvilenYanovski)
* [Boyan Medarski](https://github.com)
* [Dimitar Petrov](https://github.com)
* [Kiril Koev](https://github.com)
* [Martin Petkov](https://github.com/Supbads)
* [Tony Dimitrov](https://github.com)

## Task Management Tool

[Trello Board](https://trello.com/b/clfcvrzl/domashnik)

## Project Description

The project simulates a support system for a learning site. Learning site offers online courses and materials where students can get assigned to. The **Learning Support System** covers the students' course assignments, homeworks, scores, etc.

The projects consist of at least 2 separate apps:

* Back-End service build with ASP.NET and MSSQL, offering a [RESTFUL API](https://en.wikipedia.org/wiki/Representational_state_transfer) with [HATEOAS](https://en.wikipedia.org/wiki/HATEOAS) constraint.
* Front-End client build with Angular2+

### Back-End Service Description

* Used technologies: [ASP.NET MVC](https://www.asp.net/), [Entity Framework(MSSQL)](https://msdn.microsoft.com/en-us/library/aa937723(v=vs.113).aspx), [Web Sockets](https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API) (optional).
* Database approach: [Code First](http://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
* Database structure: Main tables `STUDENTS`, `COURSES`, `ASSIGNMENT`. Students are assigned to Courses and have grades. A Course has Students and Homeworks. A Homework has Assigned Student's ID and Checked Student ID, and also a due date. 
* Database schemma: [Gliffy Entity-Relationship Diagram](https://go.gliffy.com/go/publish/12396343)
* Functionalities: The service provides options for checking the due homeworks, uploading a homeworks as zip or text, automatical test of the homework(optional), download zip for manual check of random homeworks and a good layouts for listing of the students information regarding the course/homeworks status. Additional services may cover live chat with mentors, public chatrooms for discussions, notifications for messages and scores received, feedback bord for the homeworks.

### Front-End Client [Frontend Repository](https://github.com/The-great-7/Frontend)

## License 

[MIT](https://opensource.org/licenses/MIT)
