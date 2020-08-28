# People

This project is being developed as a trainment in the proccess of creating validations for .Net core applications. It simulates a working application and the situation were the developer is asked to make an improvement, with a story that tells him to add some validations in an already working POST endpoint.

## Usage

Read and understand the existing code then do the following tasks.

- Add the FluentValidation package to the project.
- Integrate FluentValidation with the web api (https://docs.fluentvalidation.net/en/latest/aspnet.html).
- Treat the validation errors to be in the structure of a List of ErrorViewModel (https://www.c-sharpcorner.com/blogs/customizing-model-validation-response-resulting-as-http-400-in-net-core).
- Start writing the validations described in the [Stories](#Stories) section. (All validators should be tested, preferably using helpers https://docs.fluentvalidation.net/en/latest/testing.html)
- As a final test run the postman collection ([Running postman tests](#running-the-tests))

## Stories

### 1. Add person validations

Add the following validations to the POST endpoint

| Field                 | Validation                              | Fail message                            |
| --------------------- | --------------------------------------- | --------------------------------------- |
| Name.FirstName        | Mandatory and without empty spaces      | First name should not be empty.         |
| Name.LastName         | Mandatory and without empty spaces      | Last name should not be empty.          |
| Birth                 | Should be in the past                   | You weren't born yet.                   |
| Email                 | Mandatory                               | Email should not be empty.              |
| Email                 | Email format when filled                | Email format is invalid.                |
| Hobby                 | Is contained in the HobbyEnumeration    | Select one of the provided hobbies.     |
| Parent.Name.FirstName | Mandatory and without empty spaces      | First name should not be empty.         |
| Parent.Name.LastName  | Mandatory and without empty spaces      | Last name should not be empty.          |
| Parent.Relation       | Is contained in the RelationEnumeration | Select one of the provided relations.   |
| Cpf.Number            | Mandatory                               | Cpf should not be empty.                |
| Cpf.Number            | Formatted with mask 999.999.999-00      | Cpf format is invalid.                  |
| Cpf.Number            | Digit validation                        | Cpf is invalid.                         |
| Cpf.Emission          | Should be in the past                   | Cpf emission should be in the past.     |
| Cpf.Expiration        | Should be in the future                 | Cpf expiration should be in the future. |

### 2. Change validations

Add validations to both endpoints:

| Field            | Validation                                      | Fail message                                   |
| ---------------- | ----------------------------------------------- | ---------------------------------------------- |
| Parent           | Should have at least one                        | You need a parent.                             |
| Parent           | Should have a maximum of two                    | Too much parents.                              |
| Parent           | If cloned then need to have no parents          | Clones don't have parents.                     |
| EducationalLevel | Is contained in the EducationalLevelEnumeration | Select one of the provided educational levels. |
| Revenue          | Positive                                        | Revenue shouldn't be negative.                 |

| Field | Validation                                              | Fail message               |
| ----- | ------------------------------------------------------- | -------------------------- |
| Email | Mandatory when age is lesser then 60                    | Email should not be empty. |
| Name  | Combined names should have a maximum of 100 characteres | Name is too long.          |
| Hobby | Should not be Sports when Profession is Developer       | I doubt it.                |

Add validations only for PUT route (https://docs.fluentvalidation.net/en/latest/rulesets.html, https://docs.fluentvalidation.net/en/latest/webapi.html#validator-customization):

| Field            | Validation                            | Fail message                               |
| ---------------- | ------------------------------------- | ------------------------------------------ |
| Status           | Is contained in the StatusEnumeration | Select one of the provided status.         |
| EducationalLevel | Can't regress any level               | Can't regress any level in your education. |

## Running the application

Run command inside the web server project folder:

```
$ dotnet run
```

Access the Api documentation at https://localhost:5001/api/docs and the UI at https://localhost:5001.

## Running the tests

Run command on the root folder or inside a test project folder:

```
$ dotnet test
```

To run the tests on postman you can use the postman interface to run all requests or use the following commands on root folder:

```
$ npm install -g newman
$ newman run PeopleValidations.postman_collection.json --insecure
```

## Built with

- [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) - _Software Developmet Kit (SDK)_
- [Blazor](http://blazor.net/) - _Build client web apps with C#_
- [Fluent Validation](https://fluentvalidation.net/) - _A popular .NET library for building strongly-typed validation rules_
- [xUnit.net](https://xunit.net/) - _Unit Test Framework_
- [Fluent Assertions](https://fluentassertions.com/) - _Unit Test Assertions Extension Methods_
- [Moq](https://github.com/moq/moq4) - _The most popular mocking library for .NET_
- [Cloud Firestore](https://googleapis.github.io/google-cloud-dotnet/docs/Google.Cloud.Firestore/) - _Flexible, scalable database for mobile, web, and server development from Firebase and Google Cloud Platform_

## Collaborators

- Cristian Boiam - https://github.com/cboiam/
- Giulia Stefani - https://github.com/giuliastefani/
