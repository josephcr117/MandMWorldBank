# MandMWorldBank

## What the project does

**MandMWorldBank** is a banking system built with ASP.NET Core MVC and Entity Framework Core. This banking system allows users to register, login, check their balance, transfer funds and view their transaction history.

## Features

- **User Registration**: A user can create their username and password and can indicate their initial balance.
- **User Login**: Users can then login to their accounts.
- **Balance Check**: First thing that appears would be the amount they have of their remaining balance.
- **Transfers**: Transfers can happen only to registered users.
- **Transaction History**: From the very beginning of having an account the user can track where their funds have gone to.

## Technology used

- **Backend**: ASP.NET Core MVC
- **Database**: SQL Server with Entity Framework Core
- **Frontend**: HTML, CSS and Bootstrap.
- **Authentication**: Session-based login
- **IDE**: Visual Studio 2022

## Getting Started

to get started:

1. Clone the repository
2. Set up the database - Tools -> NuGet Package Manager -> Package Manager Console and run this command to create the database locally
Add-Migration InitialCreate
Update-Database
4. Run the application

## Demo and Screenshots of DB

### Demo
The Demo is in the github repository named **MandMWorldBank Demo**

### Screenshots
Screenshots of the Database are named:
- **Users DB**: This is to see that the users created with the register button are actually being saved somewhere
- **Transaction History DB**: In this screenshot we can see all of the transfers that have been made between accounts and it will show to the corresponding account, either if money was transfered from or to a registered user.
