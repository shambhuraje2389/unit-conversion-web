## Unit Conversion Application.

## Feature

- User can convert length unit.
- User can convert Height unit.
- User can convert Temparature unit.
- User can see the converison history.
- User can get toaster notification for validation,conversion sucess, fetching histry logs.

## Techanologies

Backend tech stack

- C#
- .Net core Web API (Swagger documents)
- Entity framework Core
- MS SQL

Frontend tech stack

- React
- TypeScript
- Vite
- Bootstrap

Unit conversion application have two main apps.

## UnitConversion.API (Backend)

This application developed in .NET 8.0. This is backend API of unit conversion application.We implemented Swagger documentation. We can access swagger document using 'swagger/index.html' path.

#### Run UnitConversion.API

We can run this project from Visual studio => set as start up project. run from Visual studio.

## unitconversion.ui (Frontend)

This application developed in React + TypeScript + Vite + Bootstrap.This is frontend of unit conversion application.

#### Run unitconversion.ui

We can run this project from Visual studio => set as start up project. run from Visual studio.  
 Or

```sh
    npm install
    npm run dev
```

#### Run UnitConversion.API & unitconversion.ui

To run above application, you can set mutiple stateup projects in solution => property & run from Visual studio.

## MS-SQL DB Setup

To set up MS-SQL DB on ,run following commands from Package Manager console before that Database should present on SQL Server.

```sh
    add-migration Initial_Migration
    Update-Database
```
