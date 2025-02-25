# SmallNotesApp

## 📌 About the Project
SmallNotesApp is a simple note-taking application built with **Angular** (frontend) and **ASP.NET Web API** (backend). The app allows users to **create, view, update, and delete notes** while storing them in a **SQL Server database**.

### ✨ Features
- 📝 Create, view, update, and delete notes.
- 🔗 RESTful API for backend communication.
- 🗄️ Uses **SQL Server** for database storage.
- 📜 Logging via **Serilog** for both frontend and backend.
- 🌐 Built with **Angular v19** and **ASP.NET Core Web API**.

---

### 🛠 Prerequisites
Make sure you have the following installed:
- **Angular CLI** - Install via `npm install -g @angular/cli`
- **.NET 7+ SDK** - [Download](https://dotnet.microsoft.com/)
- **SQL Server** (or **SQL Server Management Studio**) - [Download](https://aka.ms/ssmsfullsetup)

---

## 📦 Setup and Installation

### 1️⃣ **Backend (ASP.NET Core Web API)**

#### ✅ Clone the Repository
git clone https://github.com/yourusername/SmallNotesApp.git


✅ Configure Database Connection
Open appsettings.json in the backend project.
Update the connection string under "ConnectionStrings":


✅Apply migrations and update the database:

dotnet ef migrations add InitialCreate
dotnet ef database update

✅ Run the Backend Server
dotnet run


✅ Navigate to the Frontend Directory
cd frontend
✅ Install Dependencies
npm install
✅ Run the Frontend App
ng serve



🛠 API Endpoints
Method	Endpoint	Description
GET	/api/notes	Get all notes
GET	/api/notes/{id}	Get a single note
POST	/api/notes	Create a note
PUT	/api/notes/{id}	Update a note
DELETE	/api/notes/{id}	Delete a note



📝 Logging
Both the frontend (Angular) and backend (ASP.NET Web API) use Serilog for logging. Logs are stored in logs/ for debugging purposes.



