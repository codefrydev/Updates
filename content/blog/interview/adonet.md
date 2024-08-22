---
title: "Ado Net"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-22
dateString: August 2024  
description: "Ado Net To Connect ith Database"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","adonet"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","adonet"]
---

### 1. What is ADO.NET?

ADO.NET (ActiveX Data Objects) is a data access technology in the .NET framework used to interact with data sources, such as databases. It provides a set of classes for connecting to databases, executing commands (queries, updates), and retrieving results into datasets or data readers.

### 2. Differentiate between DataSet and DataReader

- **DataSet:** It's an in-memory cache of data retrieved from the database. It can hold multiple DataTables, relationships, and constraints. It is disconnected, meaning it doesn't need an active connection to the database once data is loaded.
- **DataReader:** It provides a read-only, forward-only stream of data from the database. It's faster and uses less memory compared to DataSet but is less flexible as it doesn't store data locally.

### 3. Explain the steps to connect to a database using ADO.NET

To connect to a database using ADO.NET:

- Create a connection object (`SqlConnection`, `OleDbConnection`, etc.).
- Open the connection using `Open()` method.
- Create a command object (`SqlCommand`, `OleDbCommand`, etc.) specifying the SQL query or stored procedure.
- Execute the command using `ExecuteNonQuery()`, `ExecuteScalar()`, or `ExecuteReader()` methods.
- Close the connection using the `Close()` or `Dispose()` method.

### 4. What are the different components of ADO.NET?

ADO.NET consists of several key components:

- **Connection:** Represents a connection to a data source.
- **Command:** Executes commands (SQL queries or stored procedures) against a database.
- **DataReader:** Retrieves data in a read-only, forward-only manner.
- **DataAdapter:** Populates a DataSet and resolves changes back to the database.
- **DataSet:** In-memory cache holding data in tables and relationships.

### 5. How does ADO.NET prevent SQL injection attacks?

ADO.NET provides parameterized queries through `SqlParameter` objects. Using parameterized queries ensures that input values are treated as parameters rather than concatenated directly into the SQL command. This prevents malicious SQL injection by separating data from SQL commands.

### 6. Explain the difference between SqlCommand and SqlDataAdapter

- **SqlCommand:** Represents a SQL command to be executed against a database. It's used to execute SQL queries, stored procedures, and perform data manipulation operations.
- **SqlDataAdapter:** Acts as a bridge between a DataSet and a data source. It populates the DataSet and resolves changes back to the database using `Fill()` and `Update()` methods.

### 7. What is the purpose of the ExecuteNonQuery() method in ADO.NET?

`ExecuteNonQuery()` method is used to execute SQL commands (such as INSERT, UPDATE, DELETE) that don't return any data, only the number of rows affected by the command.

### 8. How can you handle exceptions in ADO.NET?

Exceptions in ADO.NET can be handled using `try-catch` blocks. Commonly used exception classes are `SqlException`, `OleDbException`, etc. Handling exceptions involves catching specific exceptions that may occur during database operations and taking appropriate actions, such as logging errors or displaying user-friendly messages.
