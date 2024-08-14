# Hacker News Api

The next document describes the project to test the Hacker News API.

https://github.com/HackerNews/API

## Description

This repository contains a Visual Studio solution for the following projects:
 - HackerNewsApi
 - HackerNewsApiTest
 
 The API project was created following good practices for the CLEAN architecture concept.
## How to run the application

Requirements:
.NET 3.1 SDK installed

- Clone the repository from GitHub
- Open the solution file *HackerNewsApi.sln* with Visual Studio or Visual Studio Code
- Run the project *HackerNewsApi.csproj*
- Once the project compiles and starts it will show a screen to call the Endpoint *BestStories*, this endpoint requires the *limit* parameter to get the *n* numbers of stories from the Hacker News API.
- (Optional) Run the project *HackerNewsApiTest* to review the unit tests of this project.

## Assumptions

 - Hacker News API is a public API that we can call without using any credentials
 - The structure of the items will be the one found in the Hacker News API documentation

## Enhancements or changes
 - Update the framework and use .NET 8 as the it is an LTS (Long-Term Support) version.
 - Apply and enhance the code to handle better the exceptions.
 - Modify the response to include pagination and status of the request.
 - Apply a change to persist the data following the cache good practices to improve the performance of the calls
 - Modify the test project to run integration tests because the current project tests the service functionality only and it is mocking the internal process and results.

## Authors

- Enrique Espinoza [@mor3lias](https://github.com/morelias)
