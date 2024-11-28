# Car Rental Web API

Welcome to the **Car Rental Web API** project. This API allows users to rent cars, manage users, and get notifications via email. The application is built using **ASP.NET Core Web API**, **Entity Framework Core (EF)**, **JWT Authentication**, and **SendGrid** for email notifications.

---

## Table of Contents

- [Overview](#overview)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Project Structure](#project-structure)
- [Setup and Installation](#setup-and-installation)
  - [Prerequisites](#prerequisites)
  - [Installation Steps](#installation-steps)
  - [Database Setup](#database-setup)
  
---

## Overview

The **Car Rental Web API** is designed to enable the management of car rentals for customers. The API allows for the following:

1. **User Registration and Authentication** (via JWT)
2. **Car Listings** with details like make, model, year, and price.
3. **Car Rental Transactions**, including renting a car and tracking rental status.
4. **Email Notifications** sent to users upon successful rental via **SendGrid**.
5. **Admin Features** like viewing all cars, adding new cars, and managing rentals.

This API is part of a **Car Rental System** that can be expanded further with additional features like payment processing and advanced user management.

---

## Technologies Used

- **ASP.NET Core Web API**: For building the backend API.
- **Entity Framework Core**: For database management and ORM (Object-Relational Mapping).
- **SQL Server**: The database used for storing user, car, and rental data.
- **JWT Authentication**: For secure user authentication and authorization.
- **SendGrid**: For sending email notifications related to rentals.
- **Swagger**: For auto-generating API documentation (optional for testing).

---

## Features

- **User Management**: Register, authenticate, and manage users.
- **Car Management**: CRUD operations for cars.
- **Rental Management**: Rent cars, view rental history, and return cars.
- **Notifications**: Send email notifications on successful rental through **SendGrid**.


---

## Setup and Installation

### Prerequisites

Before setting up the project, make sure you have the following installed:

- **.NET SDK** (preferably version 6.0 or later)
- **SQL Server** (for local database setup)
- **Visual Studio** or **Visual Studio Code**
- **Postman** (optional, for testing the API)
- **SendGrid API Key** (for email notifications)

### Installation Steps

1. **Clone the Repository**

   Clone the project repository to your local machine:

   ```bash
   git clone https://github.com/AmanKumar2324/Car_Rental_System_API.git
   cd Car_Rental_System_API

2. **Restore NuGet Packages**
3. **Set Up Database Connection**
4. **Apply Entity Framework Migrations**
5. **Add SendGrid API Key**
6. **Run the Application**
7. **Test the API**


---

## Conclusion

The Car Rental Web API provides a complete backend solution for managing car rentals, with support for user authentication, car management, rental transactions, and notifications. You can easily expand this solution by adding more features like payment integration, user reviews, etc.




