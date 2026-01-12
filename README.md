# IviPerfumeFinder

IviPerfumeFinder is a sample full-stack project with a .NET 8 Web API backend and a React frontend. The API includes JWT authentication, EF Core with SQLite, seed data and Swagger. The frontend is a small React app that consumes the API.

Setup (backend)
1. Restore packages: dotnet restore PerfumeFinder.sln
2. Apply migrations / create DB: dotnet tool install --global dotnet-ef --version 8.0.0 (if not installed)
3. Run migrations: dotnet ef database update --project PerfumeFinder.Api
   - This will create a local SQLite file `ivi_perfume.db` in the API project folder on first run.
4. Run API: dotnet run --project PerfumeFinder.Api

Default test user: username: test, password: password

Setup (frontend)
1. cd perfume-finder-frontend
2. npm install
3. npm start

Notes
- The project targets .NET 8.0
- JWT settings are stored in PerfumeFinder.Api/appsettings.json
- The API will create a SQLite DB file `ivi_perfume.db` in the API project folder on first run

This repository was seeded with sample data (perfumes, notes, a test user).
