SimpleCrud - PhoneBook
========================

![image](./accessories/phonebook.png)


- [About](#about)
- [Solution structure](#solution-structure)
  - [Core layer](#core-layer)
  - [Infrastructure layer](#infrastructure-layer)
  - [Application layer](#application-layer)
  - [Web layer](#web-layer)
- [Tests](#tests)
  - [Unit tests](#unit-tests) 
- [Work with application](#work-with-application)

## About

**The Simple Crud**  is software application with phone book functionality is a tool that allows you to store, manage and search for contacts. Such software can be used for both personal and business purposes. Here are some key features it can offer:
1. Contact Storage: Ability to add and edit contact information such as name, surname, phone number, email address, physical address and other data.
2. Search and filter: Quickly search for contacts using various criteria, such as name, surname, company or phone number.
3. Export: Integration with other applications and devices.
4. Ability to add notes to contacts.

Such software can make contact management much easier and improve communication efficiency.


## Solution structure

### Core Layer

Database model with a phone list table is included.

### Infrastructure Layer

This layer contains implemented database accesses, configurations and repositories.

### Application Layer

In this case, this layer contains little, only DTOS for now.

### Web Layer

The application uses Angular and TypeScript, to learn more about these technologies, take a look at the following resources:

-   [Angular Documentation](https://angular.dev/overview) - learn about Angular features.
-   [Learn TypeScript](https://www.typescriptlang.org/)
-   [PrimeNG](https://primeng.org/)


## Tests

### Unit tests

Tests for the PhoneBook model are added, using [NUnit](https://nunit.org/) and [Fluent Assertions](https://fluentassertions.com/)

## Work with application

tbd
