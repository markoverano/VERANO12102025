# Video Store Application

A video streaming and upload application with Angular frontend and .NET Core backend.

## Prerequisites

- Node.js 18+
- .NET 9 SDK
- SQL Server (local or Docker)
- FFmpeg (for thumbnail generation)
- Docker & Docker Compose (optional)

## Quick Start with Docker

1. Configure environment variables in `.env`:
   ```
   SA_PASSWORD=YourSecurePassword123!
   DB_NAME=VideoStore
   ```

2. Run the application:
   ```bash
   docker-compose up --build
   ```

3. Access the app at http://localhost:4200

The connection string is built automatically from `.env` variables. No secrets are stored in config files.

## Manual Setup

### Backend

```bash
cd backend
dotnet restore
dotnet run
```

Runs on http://localhost:5164

Update connection string in `appsettings.json` if needed:
```json
"ConnectionStrings": {
  "DefaultConnection": "{YOUR CONNECTION STRING}"
}
```

### Frontend

```bash
cd video-store-frontend
npm install
npm start
```

Runs on http://localhost:4200

## Running Tests

### Backend Tests

```bash
cd backend.Tests
dotnet test
```

### Frontend Tests

```bash
cd video-store-frontend
npm test
```

## Project Structure

```
├── backend/                 # .NET Core API
├── backend.Tests/           # Backend unit tests
├── video-store-frontend/    # Angular frontend
├── docker-compose.yml       # Docker orchestration
└── .env                     # Docker environment variables
```
