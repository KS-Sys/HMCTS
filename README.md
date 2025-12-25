DTS Developer Technical Test - Junior Software Developer

For this challange i started off by desinging a UML diagram so i could reference the console project.
The main project started off from console as a test harness and the back end of the modules being in a modules folder.

Once the project was running up to standard I migrated the modules to a class library .logic.
I also created a front end API for the sql database to be interacted with.

The project has the old console and new api. unit tests are included in the solution.

I have added a HTML webpage for the project to be interfaced with. It was mostly generated with AI and I only changed a few things.

project written in c# for the back end, front end and unit tests.
ASP.NET used in front end and used swagger UI to interact with the api.
html used for webpage.

// 25/12/2025
The project allows basic crud operations to be carried out on the mysql database and was updated out of own interest.

[GET] returns the current data on the server.
[POST] allows the user to insert new data on the server.
[DELETE] allows the user to delete data on the server.
[PUT] allows the user to update current data on the server.
