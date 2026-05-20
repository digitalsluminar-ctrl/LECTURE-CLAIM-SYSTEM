#Lecture-Claim-System

Overview
The Lecture Claim Management System is a web-based application built with C# and ASP.NET Core MVC. It was developed to streamline and automate the process of submitting, tracking, and approving payment claims for academic lecturers.

This project demonstrates a clear understanding of the MVC architecture, role-based workflows, automated calculations, local file handling, and modern CI/CD practices within a .NET environment.

💻 Tech Stack
Backend: C#, ASP.NET Core MVC, .NET 8

Frontend: Razor Views (.cshtml), HTML5, CSS3, Bootstrap 5

Data Storage: In-Memory Static Repository (Prototype configuration for rapid testing)

DevOps: GitHub Actions (Automated CI Pipeline)

IDE: Visual Studio 2022

🚀 Key Features
Role-Based Dashboards: Distinct views and controller logic for Lecturers, Coordinators, and HR personnel.

Automated Calculations: The system automatically calculates the TotalAmount based on user-inputted HoursWorked and HourlyRate, removing the risk of manual calculation errors.

Secure Document Uploads: Lecturers can attach supporting documents (e.g., timesheets or PDF evidence). The system utilizes IFormFile to generate unique GUID-based filenames and securely routes them to the wwwroot/uploads directory.

Status Tracking: Claims dynamically move through a lifecycle (Pending ➡️ Approved/Rejected), with visual badge indicators on the frontend.

HR Reporting: Dedicated HR views that filter the data repository using LINQ to exclusively display approved claims for final processing and total payout summaries.

⚙️ Continuous Integration (CI/CD)
This repository is configured with a GitHub Actions workflow (dotnet.yml). Every push to the main or master branch triggers an automated build environment on a Windows runner to restore dependencies and verify that the application compiles successfully (dotnet build --configuration Release).

🛠️ Architecture & Logic Highlights
Controllers: Built using strongly-typed models to pass data from the ClaimRepository to the Razor Views. Action methods are cleanly separated for HTTP GET and POST requests.

Data Models: Utilizes Data Annotations ([Required], [Range]) to enforce backend validation for hourly rates and hours worked before data is committed.

Repository Pattern: Currently utilizes a static ClaimRepository list to simulate database CRUD operations, ensuring the application is lightweight and easy to run straight from the repository without complex SQL Server configurations.

🏃‍♂️ How to Run Locally
Clone this repository to your local machine.

Open the solution file (.sln) in Visual Studio 2022.

Ensure the .NET Core SDK is installed.

Press F5 or click Run to build the project and launch it in your default web browser.

Note: Any uploaded documents during testing will be stored locally in the wwwroot/uploads folder generated at runtime.
