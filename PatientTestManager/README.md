#  PatientTestManager

## 📋 Prerequisites

To successfully set up and run this project, you need the following tools installed:

* **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** or later
* **SQL Server** (2019 or later)
* **SQL Server Management Studio (SSMS)** or equivalent database client
* **Visual Studio 2022** (recommended) or Visual Studio Code


Follow these steps in order to configure the database and run the application locally.

### 1. Clone Repository & Configure Connection String

The database connection string must be set up before applying migrations.

1.  **Clone the Repository:**
    ```bash
    git clone [Your Repository URL]
    cd PatientTestManager
    ```
2.  **Configure Connection String:**
    * Open the configuration file (usually `appsettings.json` or `App.config`) located in the **startup project's root**.
    * Update the `DefaultConnection` string to point to your local SQL Server instance and use the desired database name (`PatientTestManager`).

    > **Example Connection String (SQL Server Authentication):**
    >
    > `"DefaultConnection": "Server=YOUR_SERVER_NAME;Database=PatientTestManager;User Id=PatientAppUser;Password=YourSecurePassword;TrustServerCertificate=True;"`

### 2. Database Setup (Via SSMS)

#### Step 1: Create the Database

1.  Open **SSMS** and connect to your SQL Server instance.
2.  Right-click on **Databases** → **New Database**.
3.  Enter the database name: `PatientTestManager`.
4.  Click **OK**.

#### Step 2: Create SQL Login and Database User

Create a dedicated SQL Login that the application will use for authentication.

1.  In SSMS, under **Security** → **Logins**, right-click and select **New Login...**
2.  Set the **Login name** (e.g., `PatientAppUser`).
3.  Select **SQL Server authentication** and enter a strong password.
4.  Navigate to the **User Mapping** page.
5.  Check the box for the `PatientTestManager` database.
6.  In the **Database role membership** list for `PatientTestManager`, assign the **`db_owner`** role to allow Entity Framework Core migrations to create and modify the schema.

### 3. Apply Entity Framework Core Migrations

This step applies the necessary database schema using the configured connection string.

1.  Open your terminal or PowerShell.
2.  Navigate to the data access project, which contains the EF migrations:
    ```bash
    cd PatientTestManager.Data
    ```
    *(Note: This project must have the `Microsoft.EntityFrameworkCore.Design` package installed.)*
3.  Run the command to update the database:
    ```bash
    dotnet ef database update
    ```

#### Step 4: Execute Database Scripts

1.  After the tables are created, execute any necessary stored procedures.
2.  Navigate to the project's scripts folder: `PatientTestManager.Data/Scripts`.
3.  Use SSMS to run the SQL files (e.g., `dbo.GenerateReport.sql`) against the `PatientTestManager` database.

### 4. Build and Run Application

1.  Return to the **solution root directory**.
2.  Build the solution:
    ```bash
    dotnet build
    ```
3.  Run the application:
    ```bash
    dotnet run --project PatientTestManager
    ```
---
