# Assignment #3

## C&#35;

Fork this repository and implement the code required for the assignments below.

### Kanban Board

[![Simple-kanban-board-](https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Simple-kanban-board-.jpg/512px-Simple-kanban-board-.jpg)](https://commons.wikimedia.org/wiki/File:Simple-kanban-board-.jpg "Jeff.lasovski [CC BY-SA 3.0 (https://creativecommons.org/licenses/by-sa/3.0)], via Wikimedia Commons")

You are required to implement a model using Entity Framework Core for a simple kanban board for tracking work progress.

1. Install the required `Microsoft.EntityFrameworkCore` package.

1. Setup and configure your database host of choice.

1. Implement the following entities (*POCOs*) in the `Entities` folder.

    - Task
        - Id : int
        - Title : string(100), required
        - AssignedTo : optional reference to *User* entity
        - Description : string(max), optional
        - State : enum (New, Active, Resolved, Closed, Removed), required
        - Tags : many-to-many reference to *Tag* entity
    - User
        - Id : int
        - Name : string(100), required
        - Email : string(100), required, unique
        - Tasks : list of *Task* entities belonging to *User*
    - Tag
        - Id : int
        - Name : string(50), required, unique
        - Tasks : many-to-many reference to *Task* entity

1. Implement the `KanbanContext` required for the model above in the `Entities` folder.

1. Implement and test the `TasksRepository` class.

#### Notes

Override the `OnModelCreating` method on the `KanbanContext` and use it to seed your database with data so you can test and implement the `TasksRepository` class. See: <https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding> and <https://mockaroo.com/>.

Ensure that the `State` property of the `Task` entity is stored as a `string`. See: <https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions>.



## Software Engineering

### Exercise 1.a

Research what a Kanban board is.  Possibly starting from [here](https://www.atlassian.com/agile/kanban/boards), acquire sufficient application domain knowledge to write two as-is scenarios that represent the main usage of a physical Kanban board within a software engineering team.  Note: make sure to cite your references in the submission document.  

### Exercise 1.b

As a design activity (i.e., before writing the code): draw a class diagram representing your design of the entities for the C# part.  The purpose of the diagram should be to `sketch` the main relationships between the entities and their multiplicity.  

### Exercise 1.c

As a maintainance activity (i.e., after having written the code): draw a class diagram representing your implementation of the entities for the C# part.  The purpose of the diagram should be to `document` the main relationships between the entities and their multiplicity.  

### Exercise 1.d

As a maintainance activity (i.e., after having written the code): draw a state machine diagram representing your implementation of the task entity.  The purpose of the diagram should be to `document` the diffent states the entity can go through and the transitions that trigget the changes.  

### Exercise 1.e

Reflect on what were the differences in the process followed for 1.b and 1.c.  Note: use clear bullet points and avoid verbose text.  The purpose is to briefly capture your reflections (i.e., "1.b was performed as a pair in front of a blackboard to support discussions on how to proceed and which alternative would be better.  1.c ended up being produced only by one person and reviewed by the other for QA").

### Exercise 2

1. The acronym FURPS+ stands for: F_____________; U_____________; R_____________; P_____________; S_____________; +_____________.
1. The requirements engineering process is an iterative process that includes requirements ______________, ______________, and ______________.
1. Software engineering is a collection of ______________, ______________, and ______________ that help with the production of a ______________ software system developed ______________ before a ______________ while change occurs.
1. Requirements need to be complete, ______________, ______________, and ______________.
1. Important properties of requirements are realism, ______________, and ______________.
1. The output of the ______________ activity is the ______________, which include both the non-functional requirements and the functional model.

### Exercise 3

1. What level of details should UML models have?
2. What is the difference between structure diagrams and behavior diagrams in UML?  Provide two examples per category.



## Submitting the assignment

To submit the assignment you need to create a .pdf document using LaTeX containing the answers to the questions and a link to a public repository containing your fork of the completed code.

Members of the triplets should submit the same PDF file to pass the assignments. Make sure all group names and ID are clearly marked on the front page.

