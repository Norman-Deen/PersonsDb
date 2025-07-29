# 📚 PersonsDb Console App

**PersonsDb** is a simple .NET console application that manages a list of persons stored in a database.  
It follows a clean structure with separate layers for data access, services, and business logic, making it an ideal learning project for mastering basic CRUD operations with Entity Framework Core.

---

## 🛠 Features

- 👤 View all persons
- ➕ Add new entries
- 📝 Update person info
- ❌ Delete a person
- 🔍 Filter and search by criteria
- 💾 EF Core with migration support

---

## 🧱 Project Structure

```

PersonsDb/
└── ConsoleApp/
├── Program.cs               # Main entry point with menu system
├── AppSettings.json         # Configuration settings
├── Data/                    # DbContext and configuration
├── Entities/                # Person models
├── IRepository/             # Interfaces for repositories
├── Repository/              # Data access implementations
├── Services/                # Business logic services
├── Migrations/              # EF Core migrations

````

---

## 🚀 Getting Started

1. **Install .NET SDK**  
   [.NET SDK 6+](https://dotnet.microsoft.com/download)

2. **Run the app**

```bash
cd PersonsDb/ConsoleApp
dotnet run
````

The console will launch with an interactive menu.

---

## 💡 Notes

* You can adjust your connection string in `AppSettings.json`.
* Ensure that your local database is accessible before running migrations or seeding data.

---

## 📄 License

This project is for educational or demo purposes.
Feel free to copy or modify it for your own learning.

Created by Nour — .NET Developer & Software Engineering Student at EC Utbildning

