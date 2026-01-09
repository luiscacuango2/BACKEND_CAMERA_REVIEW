![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![Azure Functions](https://img.shields.io/badge/Azure_Functions-0062AD?style=for-the-badge&logo=azure-functions&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=json-web-tokens)

# **BACKEND_CAMERA_REVIEW**

Este sistema es un ecosistema de microservicios robusto desarrollado en **.NET 8** enfocado en la gestión, publicación y consumo de reseñas técnicas de cámaras fotográficas. Utiliza una arquitectura orientada a eventos para desacoplar la publicación de contenidos.

---

## **Arquitectura del Sistema**

El proyecto se divide en componentes especializados para garantizar escalabilidad:

* **`AuthenticationService`**: Microservicio encargado de la seguridad mediante **JWT** y almacenamiento en **SQLite**.
* **`CameraReview`**: El "Core" del sistema. Biblioteca de clases que contiene los modelos de dominio (Cámaras, Lentes, Productos).
* **`ReviewPublisherFunctionApp`**: *Serverless Logic*. Una Azure Function que procesa la publicación de reseñas de forma asíncrona mediante **Azure Service Bus**.
* **`CameraReviewUnitTests`**: Suite de pruebas de alta fidelidad utilizando **MSTest** y **NSubstitute** para el mockeo de dependencias.

---

## **Stack Tecnológico**

| Capa | Tecnología |
| :--- | :--- |
| **Lenguaje** | C# 12 / .NET 8.0 |
| **Framework Web** | ASP.NET Core Web API |
| **Serverless** | Azure Functions v4 |
| **Mensajería** | Azure Service Bus |
| **Persistencia** | Entity Framework Core & SQLite |
| **Testing** | MSTest & NSubstitute |

---

## **Instalación y Configuración**

### **Requisitos Previos**
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Azure Functions Core Tools](https://github.com/Azure/azure-functions-core-tools)
* VS Code o Visual Studio 1.107.1

### **Pasos para iniciar**

1. **Clonar y restaurar:**
   ```bash
   git clone https://github.com/luiscacuango2/BACKEND_CAMERA_REVIEW.git
   ```

2. Restaura las dependencias:
   ```
   dotnet restore
   ```

3. Construye la solución:
   ```
   dotnet build
   ```
4. Ejecutar Pruebas de Calidad:
   ```
   dotnet test
   ```

## Ejecución de Módulos

### Servicio de Autenticación

   ```
   cd AuthenticationService
   dotnet run
   ```

Accede a la documentación interactiva en: `http://localhost:5000/swagger`.

### Azure Functions (Publicador)

   ```
   cd ReviewPublisherFunctionApp
   func host start
   ```


### **Contribución y Calidad**

¡Las contribuciones son lo que hacen a la comunidad increíble!

Revisa nuestra **Guía de Contribución** en [CONTRIBUTING.md](CONTRIBUTING.md) para conocer los detalles sobre nuestro código de conducta y el proceso para enviarnos pull requests.

## Licencia

Este proyecto está bajo la Licencia MIT. Ver [LICENSE](LICENSE) para más detalles.
