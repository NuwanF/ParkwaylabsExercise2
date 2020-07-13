# Parkwaylabs Exercise 02

## Setup
Download the project and two projects are added under the ParkwaylabsExercise2 sollution
Change database connection strings in ParkwaylabsExercise2->appsettings.json file and ParkwaylabsExercise2_Test->appsettings.test.json file
Run below script in Package Manager Console to generate database with data
```bash
"update-database"
```
Run ParkwaylabsExercise2 project and you will find a Swagger UI, where you will find the required endpoints
Run test in Test Explora and you will find the result of the test cases

## Content
In Swagger UI, 
GetDeveloperByTechnology endpoint refers to the first task
GetExperiencedTechLeadByTechnology refers to the second task
GetExperiencedTechLeadByDeveloperTechnology refers to the third task

In Test Explora, some sample test cases are added against all three endpoints

## Implementation and Best Practices
Generic repository pattern is used to minimize the repetition and have single base repository work for all type of data
Unit of Work is used to maintain a single transaction that involves multiple CRUD operations
Code first approach is used to generate database
A three-tire architecture including Repository Layer, Business Logic Layer and Controller Layer is used to structure the project
Dependency Injection is used to maintain loose coupling between each layer and inject low level classes in to high level classes






