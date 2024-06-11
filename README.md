# ProductionManagement

## Description
Production Managment Sysyem using mircoService. its the production Service that carry (Product Planning - Product - Production Operation - Product Tracking - Product Stop Records) 

Here you can See All Data and Create , Update , Delete and Search for All these Entites

The Search in Product , Product Planning , Product Tracking , Product Stop Records is By ProductName 

while in  Production Operation is by Operation Type

### Prerequistes
[.Net 8.0]

[SQL Server]

## Installation 
In Production.Api 

                      => "Microsoft.EntityFrameworkCore.Design" Version="8.0.6"

In Production.Repository 

                        => "Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.6"

                        => "Microsoft.EntityFrameworkCore.Tools" Version="8.0.6"

In Production.Services 
  
                        => "AutoMapper" Version="13.0.1"

## Notes
You don't have to 'Update-Database'. I already make command that make Apply All Migtations and Update DataBase if it is not exist  


## Important
Dont Forget to change {BaseUrl} in appsetting Based on your project url
