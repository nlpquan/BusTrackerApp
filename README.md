# Bus Booking Application

This repository contains both the backend (C#) and frontend (React) for the Bus Booking application. Follow the instructions below to set up both the backend and frontend.

## Backend (C#)

### Prerequisites:
1. **SQL Server**: Install and configure SQL Server. You can use SQL Server Management Studio (SSMS) to interact with the database.
2. **.NET Core SDK**: Make sure you have the latest version of .NET Core SDK installed.

### Steps to Run Backend:

1. **Install SQL Server**:
   - Download and install **SQL Server** from [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
   - Install **SQL Server Management Studio (SSMS)** from [here](https://aka.ms/ssmsfullsetup).

2. **Add Database Migration**:
   - Open the **Package Manager Console** in Visual Studio.
   - Run the following command to add the migration:
     ```
     Add-Migration InitialCreate
     ```

3. **Update the Database**:
   - Run the following command to apply the migration and create the database:
     ```
     Update-Database
     ```

4. **Run the Application**:
   - Press the **green play button** (or use `F5`) to run the backend application.
   - The backend API should now be running.

---

## Frontend (React)

### Prerequisites:
1. **Node.js**: Install Node.js if you haven't already. You can download it from [here](https://nodejs.org/).

2. **npm**: npm should be installed along with Node.js.

### Steps to Run Frontend:

1. **Navigate to the React project directory**:
   - Open a terminal or command prompt and `cd` into the `bustracker-react` directory:
     ```bash
     cd bustracker-react
     ```

2. **Install Dependencies**:
   - Run the following command to install the required dependencies:
     ```bash
     npm install
     ```

3. **Install Axios** (for API calls):
   - Install **Axios** to handle HTTP requests:
     ```bash
     npm install axios
     ```

4. **Start the Frontend**:
   - Run the following command to start the React application:
     ```bash
     npm start
     ```
   - This will start the frontend and open it in your browser (usually at `http://localhost:3000`).

---

## Additional Notes:

- The **backend** should be running on a different port (default is `http://localhost:5000`), and the frontend should be able to interact with it via API calls.
- Ensure the **backend API** is up and running before starting the frontend.

---

## Troubleshooting:

- If you encounter errors related to SQL Server or migrations, make sure that SQL Server is properly installed and the connection strings are correctly configured in your `appsettings.json` file.
- For React, if you face any issues related to packages, ensure that all dependencies are correctly installed by running `npm install` and try restarting the development server.

---

Feel free to reach out if you have any issues or questions regarding the setup!
