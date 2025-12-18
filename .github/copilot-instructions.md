# AI Coding Agent Instructions for CameraReviews Backend

## Architecture Overview
This is a microservices-based backend for a camera review system, built with .NET. Key components:
- **AuthenticationService**: Standalone ASP.NET Core API for user auth (editors), using JWT and SQLite.
- **CameraReview**: Class library containing domain models (products, cameras, lenses, reviews) with interface-based design.
- **ReviewPublisherFunctionApp**: Azure Function (v3, .NET Core 3.1) triggered by Service Bus for publishing reviews.
- **CameraReviewContentProviderService**: Placeholder for content delivery service.
- **CameraReviewUnitTests**: MSTest-based unit tests using NSubstitute for mocking.

Data flows: Editors authenticate via AuthService, publish reviews via Function App (Service Bus), content retrieved from domain models.

## Key Patterns and Conventions
- **Domain Modeling**: Use interfaces (e.g., `IProduct`, `ICamera`) extending base interfaces, with concrete implementations (e.g., `Camera`, `ReviewImpl`). Implement `GetContent()` for string representation.
- **Authentication**: BCrypt.Net for password hashing, JWT with symmetric key (1-hour expiry), claims include user ID and role.
- **Testing**: MSTest with NSubstitute for mocks. Test files mirror source structure (e.g., `ProductTest.cs`).
- **Configuration**: Use `appsettings.json` for JWT settings (Issuer, Audience, Key).
- **Dependencies**: Minimal; auth service uses EF Core SQLite, JWT Bearer, BCrypt, Swagger.

## Developer Workflows
- **Build**: `dotnet build CameraReviewsBackend.sln` from root.
- **Test**: `dotnet test` in `CameraReviewUnitTests/` or solution-wide.
- **Run Auth Service**: `cd AuthenticationService && dotnet run` (exposes Swagger at `/swagger`).
- **Run Function App**: Install Azure Functions Core Tools; `cd ReviewPublisherFunctionApp && func host start` (requires Service Bus connection).
- **Debug**: Use VS Code debugger; attach to process for services.

## Integration Points
- Auth service validates tokens for other components.
- Function App listens to Service Bus topic "CameraReviewPublisher" subscription "CameraReviewBackend".
- Domain models in `CameraReview` are shared across services.

Reference: `AuthenticationService_design_doc.md`, `CameraReviewsBackend_design_doc.md` for high-level design.