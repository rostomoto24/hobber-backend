# Hobber backend

.NET 8 clean-architecture API for Hobber, a marketplace for hobby courses. Product context, decisions and status live one level up in `../docs/`; read `../docs/STATUS.md` and `../docs/DECISIONS.md` first, then `../docs/backlog/backend.md` and the newest entries in `../docs/status/*.md` once those exist.

## Ownership

The Backend role owns everything in this repo. Outside it, only append to `../docs/status/backend.md` and tick items in `../docs/backlog/backend.md`. The API contract `../docs/api/openapi.yaml` is owned by the Architect: propose changes in your status entry, do not edit it.

## Solution layout

| Project | Role | Depends on |
|---|---|---|
| `Hobber.Domain` | Entities (`User`, `Course`, `Category`, `Enrollment`, …) and enums; static rule helpers on `Course` | nothing |
| `Hobber.Application` | One handler class per use case (`Auth/`, `Me/`, `Courses/`, …), `Result`/`Error`, `Validator`, DTOs in `Contracts/`, abstractions (`IAppDbContext`, `ITokenService`, …) | Domain, EF Core abstractions |
| `Hobber.Infrastructure` | `JwtTokenService`, `IdentityPasswordHasher`, `LoggingEmailSender`, `SystemClock`, `SocialIdentityVerifier` (Google ID tokens via `Google.Apis.Auth`, Facebook via Graph API) | Application |
| `Hobber.Persistance` | `HobberDbContext` (implements `IAppDbContext`), `Configurations/`, `Migrations/`, `Seeding/SeedData` (HasData, fixed ids; emitted into the migrations) | Domain, Application |
| `Hobber.API` | Controllers, `Infrastructure/CurrentUser`, `ResultExtensions` (Result → RFC 7807), `Program.cs` | all of the above |
| `Hobber.Tests` | xUnit integration tests via `HobberApiFactory` (SQLite in-memory + `DevSeeder`), one fixture per test class | API |

Dependency direction: API -> Application -> Domain. Persistance and Infrastructure implement interfaces that Application defines. Controllers never touch `DbContext`; they call a handler and pass its `Result` to `ToActionResult`.

## Commands

```
dotnet build Hobber.sln                       # green, 0 warnings
dotnet test Hobber.sln                        # 29 integration tests, ~3 s
dotnet run --project Hobber.API               # https://localhost:51014 , http://localhost:51015
                                               # Development: applies migrations (which carry the seed data), Swagger UI at /swagger
dotnet ef migrations add <Name> -p Hobber.Persistance -s Hobber.API -o Migrations
dotnet ef database update -p Hobber.Persistance -s Hobber.API
dotnet ef database drop -f -p Hobber.Persistance -s Hobber.API   # reset the local database, then update again
sqlcmd -S "(localdb)\MSSQLLocalDB" -d HobberDb -Q "SELECT COUNT(*) FROM Courses"
# export the contract after endpoint changes (app running):
curl -s http://localhost:51015/swagger/v1/swagger.json -o ../docs/api/openapi.json
```

Database for development is **SQL Server LocalDB**, instance `MSSQLLocalDB`. The correct connection string is:

```
Server=(localdb)\MSSQLLocalDB;Database=HobberDb;Trusted_Connection=True;TrustServerCertificate=True;
```

Configuration keys: `Jwt:{Issuer,Audience,Key,AccessTokenMinutes,RefreshTokenDays}` (dev key in `appsettings.Development.json`; production must set `Jwt__Key` with 32+ bytes or startup throws), `Database:MigrateOnStartup` (true only in Development), `Authentication:{Google:{ClientIds[]},Facebook:{AppId,AppSecret}}` for social login. Social values are secrets: `dotnet user-secrets set ...` in `Hobber.API` (see `../docs/api/endpoints.md`), never appsettings. Tests swap `ISocialIdentityVerifier` for `FakeSocialIdentityVerifier`.

Demo logins (seeded by the migrations): `salome@hobber.dev` (student) and `ana@hobber.dev` (tutor), password `Hobber123`. Changing seed rows = edit `SeedData.cs` and add a migration; HasData diffs by primary key, so never reuse an id for different content.

## Conventions in this code base

- A use case = one `*Handler` class with `HandleAsync`, returning `Result<T>` or `Result`. Validation through `Validator` yields `Error.Validation(fields)`; other failures use `Error.Conflict/NotFound/Forbidden/Unauthorized(code, message)` with a stable snake_case `code` (listed in `../docs/api/endpoints.md`).
- Enums are projected as enums and converted to strings in memory (`Mapping.ToSummaryListAsync`); EF cannot translate `enum.ToString()`.
- Dates are `DateTime` UTC (SQLite in tests cannot order `DateTimeOffset`).
- New endpoint = handler + registration in `Application/DependencyInjection.cs` + controller action with `ProducesResponseType` + integration test + re-export `openapi.json` + row in `../docs/api/endpoints.md`.

## Known gaps

1. Last-seat enrolment race not prevented; no auth rate limiting; e-mail is a log stub (Phase 5).
2. Notifications list, calendar feed, tutor course CRUD not built. Social login is built but unverified against real Google/Facebook until credentials exist.

## Working rules

- One backlog item per branch: `feat/<phase>-<slug>`, `fix/<slug>`. Open a PR when tests pass; the owner merges.
- Every endpoint ships with request validation, an integration test for the success path and each documented error, and a unit test for any domain rule it touches.
- The served Swagger document must match `../docs/api/openapi.yaml`; a test diffs them in CI once the contract exists.
- An EF migration accompanies every schema change; confirm `dotnet ef database update` works on LocalDB.
- Seed data lives in `SeedData` (HasData) and therefore in migrations; the tests rely on it too.
- When a task is done, append to `../docs/status/backend.md`: date, task, endpoints, how to verify (commands, sample requests), notes for Frontend and QA.

## History

| Date | Event |
|---|---|
| 2026-05-07 | Repo created, skeleton generated via Codex (PR #1), connection string set to `localhost` |
| 2026-10-19 | Audit: builds green, nothing else changed since May. This file added. |
| 2026-10-19 | Identity, onboarding and discovery API: 9 entities, 17 endpoints, migration, seeder, 22 tests, CI. Branch `feat/2-identity-discovery-api`, PR opened. |
| 2026-10-20 | Renamed TeachMe → Hobber (solution, projects, namespaces, DbContext, CI); GitHub repo renamed `hobber-backend`. Build-check rule added after a stray API process caused `MSB3027` lock errors. |
| 2026-10-20 | Google/Facebook login: `ExternalLogin`, `POST /api/auth/social`, `GET /api/auth/providers`, user secrets for credentials, 6 tests. |
| 2026-10-20 | Seed data moved from a runtime seeder into HasData + migration `SeedDemoData`; LocalDB recreated from migrations. |
