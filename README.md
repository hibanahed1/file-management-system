# File Management System

A web application for managing files, built with **ASP.NET Core Web API** and **React**.  
Supports uploading, listing, downloading, and deleting files stored as BLOBs in the database.

---

## Features

- Upload files via the frontend (with duplicate file detection).  
- List all uploaded files showing **file name**, **size**, and **creation date**.  
- Download files from the database.  
- Delete files from the database.  
- Truncate long file names in the table with ellipsis (`...`).  

---

## Tech Stack

- **Backend:** ASP.NET Core Web API, Entity Framework Core  
- **Frontend:** React, Axios, Bootstrap  
- **Database:** PostgreSQL  

---

## Project Structure

FileManagementSystem/
├─ src/
│ ├─ FileManagementSystem.API/
│ ├─ FileManagementSystem.Application/
│ ├─ FileManagementSystem.Domain/
│ ├─ FileManagementSystem.Infrastructure/
│ └─ FileManagementSystem.React/
├─ docker-compose.yml
└─ README.md


---

## Environment Variables

- `ConnectionStrings__DefaultConnection`  
- `POSTGRES_USER`  
- `POSTGRES_PASSWORD`  
- `POSTGRES_DB`  

---

## Environment Variables
Create a `.env` file in the project root with the following:

POSTGRES_PASSWORD=your_password_here

---

## API Endpoints

| Method | Endpoint                     | Description                     |
|--------|-----------------------------|---------------------------------|
| POST   | `/api/files/upload`          | Upload a file                   |
| GET    | `/api/files`                 | Get all files                   |
| GET    | `/api/files/download/{id}`   | Download a file by ID           |
| DELETE | `/api/files/delete/{id}`     | Delete a file by ID             |

---

## Frontend

- File upload happens automatically on selection.  
- Displays all files in a table with **File Name**, **Size**, **Created At**, and **Actions**.  
- Supports downloading and deleting files.  
- Long file names are truncated with `...`.

---

## Testing

- Unit tests implemented in the Application project:  
  - Uploading files  
  - Duplicate detection  
  - Downloading files  
  - Deleting files  
  - Fetching all files  

---

## Docker (Optional)

- Docker Compose includes API + PostgreSQL DB.  
- Environment variables can be set in `docker-compose.yml`.

---

## Author

**Hiba Nahed**
