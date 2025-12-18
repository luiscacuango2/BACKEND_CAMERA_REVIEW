# Backend para Opiniones de Cámara

Este proyecto es un backend desarrollado en .NET para un sistema de reseñas de cámaras fotográficas. Permite a editores publicar reseñas y a usuarios leer el contenido de las mismas.

## Arquitectura

El sistema está diseñado con una arquitectura de microservicios:

- **AuthenticationService**: Servicio de autenticación independiente para editores, utilizando JWT y SQLite.
- **CameraReview**: Biblioteca de clases con modelos de dominio (productos, cámaras, lentes, reseñas).
- **ReviewPublisherFunctionApp**: Función de Azure para publicar reseñas vía Service Bus.
- **CameraReviewContentProviderService**: Servicio placeholder para entrega de contenido.
- **CameraReviewUnitTests**: Pruebas unitarias con MSTest y NSubstitute.

## Tecnologías

- .NET 8.0 / .NET Core 3.1
- ASP.NET Core
- Entity Framework Core
- JWT Bearer Authentication
- Azure Functions
- Service Bus
- SQLite

## Instalación

1. Clona el repositorio:
   ```
   git clone https://github.com/luiscacuango2/BACKEND_CAMERA_REVIEW.git
   cd BACKEND_CAMERA_REVIEW
   ```

2. Restaura las dependencias:
   ```
   dotnet restore
   ```

3. Construye la solución:
   ```
   dotnet build
   ```

## Uso

### Ejecutar el Servicio de Autenticación

```
cd AuthenticationService
dotnet run
```

Accede a Swagger en `http://localhost:5000/swagger`.

### Ejecutar Pruebas

```
dotnet test
```

### Ejecutar la Función de Azure

Instala Azure Functions Core Tools y ejecuta:
```
cd ReviewPublisherFunctionApp
func host start
```

## Contribución

Si deseas contribuir, por favor abre un issue o envía un pull request.

## Licencia

Este proyecto está bajo la Licencia MIT. Ver [LICENSE](LICENSE) para más detalles.
