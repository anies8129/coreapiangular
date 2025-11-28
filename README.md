NET Core Web API for CRUD Operations
Insert | Edit | Display All | Display by ID | Angular Integration

This project is a RESTful Web API built using ASP.NET Core that provides essential CRUD operations — Create, Read, Update, and Get by ID.
The API is designed specifically to be consumed by an Angular frontend, making it ideal for full-stack development projects.

🚀 Project Overview

The API exposes endpoints for managing data stored in SQL Server.
It includes features for:

Inserting new records

Editing existing records

Displaying all records

Displaying a single record using ID

The project demonstrates clean API architecture, Entity Framework Core integration, and smooth connectivity with Angular.

🛠 Tech Stack
Component	Technology
Backend API	ASP.NET Core Web API (v6/7/8)
Database	SQL Server
ORM	Entity Framework Core
Frontend	Angular (consuming this API)
Architecture	RESTful API
📌 API Features (CRUD)
➕ 1. Insert Data

POST method

Adds a new record to SQL Server

Uses EF Core / DTO Models

✏️ 2. Edit / Update Data

PUT method

Modify existing data by ID

Validation included

📄 3. Display All Records

GET endpoint

Returns full list of items

Used by Angular to show tables/lists

🔍 4. Display Record by ID

GET method with parameter

Returns a specific item

Used by Angular for Edit page / View page
