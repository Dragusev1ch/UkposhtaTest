# UkrposhtaTest

## Overview
UkrposhtaTest is a project designed for managing employee, department, company, and position data within a company. It is structured primarily around data access layers (DAL), entity models, service layers, and user interaction through menus.

## Project Structure
- **Entity Models:** Define the data structures used across the project. Includes models like `Employee`, `Department`, `CompanyInfo`, and `Position`.
- **Data Access Layer:** Contains classes for CRUD operations on the database for each entity model. Examples include `EmployeeDataAccess`, `DepartmentDataAccess`, etc.
- **Services:** Layer that provides business logic, such as sorting and exporting employee data. 
- **Presentation Layer:** Console-based menus to interact with the user, allowing them to perform various operations like adding, updating, or deleting records.

## Key Features
- **Employee Management:** Add, retrieve, update, and delete employee records.
- **Department and Position Management:** Manage department and position details.
- **Company Information Management:** Handle company-related information.
- **Data Sorting and Exporting:** Sort employees based on different criteria and export the data to a text file.

## Usage
1. **Setting Up:** Configure the database connection string in `Program.cs`.
2. **Running the Application:** Launch the application. This will open the main menu where you can navigate to different sub-menus.
3. **Performing Operations:** Select the desired operation from the menu and follow the on-screen prompts to add, view, update, or delete records.

---

Note: The project is designed to be user-friendly with clear console prompts guiding through each step.
