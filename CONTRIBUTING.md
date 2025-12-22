# **Guía de Contribución a BACKEND_CAMERA_REVIEW**

¡Hola! Gracias por considerar contribuir a **BACKEND_CAMERA_REVIEW**. Este proyecto es un backend robusto desarrollado en **C#** para la gestión y revisión de sistemas de cámaras.

Esta guía te ayudará a configurar tu entorno y seguir nuestros estándares de calidad.

---

## **Índice**
1. [Código de Conducta](#-código-de-conducta)
2. [¿Cómo puedo contribuir?](#-cómo-puedo-contribuir)
3. [Guías de Estilo y Commits](#-guías-de-estilo)
4. [Configuración del Entorno (VS Code)](#-configuración-del-entorno)

---

## **Código de Conducta**
Al participar, se espera que mantengas un tono profesional y respetuoso. Reporta cualquier comportamiento inaceptable a **Luis Cacuango** - [luiscacuango2084@gmail.com](mailto:luiscacuango2084@gmail.com).

---

## **¿Cómo puedo contribuir?**

### **Reportar Errores (Bugs)**
Si encuentras un error, abre un **Issue** incluyendo:
1. **Título descriptivo:** (Ej: "Excepción NullReference en el controlador de Review").
2. **Pasos para reproducir.**
3. **Stack Trace:** Copia el error detallado de la terminal de .NET.
4. **Entorno:** Versión de .NET SDK instalada.

### **Tu Primer Pull Request (PR)**
1. **Fork** del repositorio.
2. Crea una **rama** descriptiva: `git checkout -b feature/nueva-funcionalidad`.
3. Asegúrate de que el proyecto compile y los tests pasen: `dotnet test`.
4. Abre el **Pull Request** hacia la rama `main`.

---

## **Guías de Estilo**

### **Estándares de Código C#**
* **Convenciones:** Seguimos las [C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) oficiales de Microsoft (PascalCase para métodos/clases, camelCase para variables locales).
* **Pruebas:** Utilizamos **xUnit** o **NUnit**. Cada nueva lógica debe incluir su prueba unitaria.
* **Limpieza:** Antes de subir código, usa el comando de formateo:
  ```bash
  dotnet format
  ```
### **Mensajes de Commit (Conventional Commits)**
Usamos este estándar para mantener un historial limpio y profesional:

feat(camera): agregar integración con sensor de movimiento
fix(api): corregir error de validación en el modelo CameraDTO
docs: actualizar guía de instalación para VS Code
test: añadir pruebas unitarias para el servicio de Review

---

## **Configuración del Entorno (VS Code)**
Para desarrollar en este proyecto usando Visual Studio Code:
1. **Requisitos:**
   - .NET SDK (Versión 8.0 o superior).
   - Extensión C# Dev Kit para VS Code.
   - Docker (opcional, para base de datos).
2. **Restaurar dependencias:**
   ```bash
   dotnet restore
   ```
3. **Variables de Entorno**: Configura tus claves o cadenas de conexión en el archivo appsettings.Development.json. Nunca subas credenciales reales al repositorio
4. **Ejecutar Tests:**
   ```bash
   dotnet test
   ```
5. **Iniciar la API:**
   ```
   dotnet run --project [NombreDelProyecto].csproj
   ```

