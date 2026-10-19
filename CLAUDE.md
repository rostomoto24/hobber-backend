# Hobber backend (repo still named TeachMe)

.NET 8 clean-architecture API for Hobber, a marketplace for hobby courses. Product context, decisions and status live one level up in `../docs/`; read `../docs/STATUS.md` and `../docs/DECISIONS.md` first, then `../docs/backlog/backend.md` and the newest entries in `../docs/status/*.md` once those exist.

## Ownership

The Backend role owns everything in this repo. Outside it, only append to `../docs/status/backend.md` and tick items in `../docs/backlog/backend.md`. The API contract `../docs/api/openapi.yaml` is owned by the Architect: propose changes in your status entry, do not edit it.

## Solution layout

| Project | Role | Depends on |
|---|---|---|
| `TeachMe.Domain` | Entities (`User`, `Course`, `Category`, `Enrollment`, …) and enums; static rule helpers on `Course` | nothing |
| `TeachMe.Application` | One handler class per use case (`Auth/`, `Me/`, `Courses/`, …), `Result`/`Error`, `Validator`, DTOs in `Contracts/`, abstractions (`IAppDbContext`, `ITokenService`, …) | Domain, EF Core abstractions |
| `TeachMe.Infrastructure` | `JwtTokenService`, `IdentityPasswordHasher`, `LoggingEmailSender`, `SystemClock` | Application |
| `TeachMe.Persistance` | `TeachMeDbContext` (implements `IAppDbContext`), `Configurations/`, `Migrations/`, `Seeding/DevSeeder` | Domain, Application |
| `TeachMe.API` | Controllers, `Infrastructure/CurrentUser`, `ResultExtensions` (Result → RFC 7807), `Program.cs` | all of the above |
| `TeachMe.Tests` | xUnit integration tests via `HobberApiFactory` (SQLite in-memory + `DevSeeder`), one fixture per test class | API |

Dependency direction: API -> Application -> Domain. Persistance and Infrastructure implement interfaces that Application defines. Controllers never touch `DbContext`; they call a handler and pass its `Result` to `ToActionResult`.

## Commands

```
dotnet build TeachMe.sln                       # green, 0 warnings
dotnet test TeachMe.sln                        # 22 integration tests, ~2 s
dotnet run --project TeachMe.API               # https://localhost:51014 , http://localhost:51015
                                               # Development: migrates + seeds LocalDB, Swagger UI at /swagger
dotnet ef migrations add <Name> -p TeachMe.Persistance -s TeachMe.API -o Migrations
dotnet ef database update -p TeachMe.Persistance -s TeachMe.API
# export the contract after endpoint changes (app running):
curl -s http://localhost:51015/swagger/v1/swagger.json -o ../docs/api/openapi.json
```

Database for development is **SQL Server LocalDB**, instance `MSSQLLocalDB`. The correct connection string is:

```
Server=(localdb)\MSSQLLocalDB;Database=HobberDb;Trusted_Connection=True;TrustServerCertificate=True;
```

Configuration keys: `Jwt:{Issuer,Audience,Key,AccessTokenMinutes,RefreshTokenDays}` (dev key in `appsettings.Development.json`; production must set `Jwt__Key` with 32+ bytes or startup throws), `Database:MigrateAndSeedOnStartup` (true only in Development).

Demo logins after seeding: `salome@hobber.dev` (student) and `ana@hobber.dev` (tutor), password `Hobber123`.

## Conventions in this code base

- A use case = one `*Handler` class with `HandleAsync`, returning `Result<T>` or `Result`. Validation through `Validator` yields `Error.Validation(fields)`; other failures use `Error.Conflict/NotFound/Forbidden/Unauthorized(code, message)` with a stable snake_case `code` (listed in `../docs/api/endpoints.md`).
- Enums are projected as enums and converted to strings in memory (`Mapping.ToSummaryListAsync`); EF cannot translate `enum.ToString()`.
- Dates are `DateTime` UTC (SQLite in tests cannot order `DateTimeOffset`).
- New endpoint = handler + registration in `Application/DependencyInjection.cs` + controller action with `ProducesResponseType` + integration test + re-export `openapi.json` + row in `../docs/api/endpoints.md`.

## Known gaps

1. Rename to `Hobber.*` pending decision D2.
2. Last-seat enrolment race not prevented; no auth rate limiting; e-mail is a log stub (Phase 5).
3. Social login, notifications list, calendar feed, tutor course CRUD not built.

## Working rules

- One backlog item per branch: `feat/<phase>-<slug>`, `fix/<slug>`. Open a PR when tests pass; the owner merges.
- Every endpoint ships with request validation, an integration test for the success path and each documented error, and a unit test for any domain rule it touches.
- The served Swagger document must match `../docs/api/openapi.yaml`; a test diffs them in CI once the contract exists.
- An EF migration accompanies every schema change; confirm `dotnet ef database update` works on LocalDB.
- Dev-only seed data (categories, interests, a few tutors and courses) so Frontend and QA have realistic data.
- When a task is done, append to `../docs/status/backend.md`: date, task, endpoints, how to verify (commands, sample requests), notes for Frontend and QA.

## History

| Date | Event |
|---|---|
| 2026-05-07 | Repo created, skeleton generated via Codex (PR #1), connection string set to `localhost` |
| 2026-10-19 | Audit: builds green, nothing else changed since May. This file added. |
| 2026-10-19 | Identity, onboarding and discovery API: 9 entities, 17 endpoints, migration, seeder, 22 tests, CI. Branch `feat/2-identity-discovery-api`, PR opened. |
