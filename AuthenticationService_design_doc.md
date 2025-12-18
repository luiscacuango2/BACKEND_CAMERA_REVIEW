# Documento de Diseño del Servicio de Autenticación
---
## Objetivo
Este documento detalla el diseño de un servicio de autenticación completamente aislado para el sistema "CameraReviews". El objetivo principal es abstraer el proceso de autenticación como un servicio separado, permitiendo la escalabilidad del sistema y del negocio. Este servicio manejará la autenticación de usuarios (editores y visitantes), la gestión de tokens y la validación de permisos, sin depender de otros componentes del sistema principal.

## Alcance
- Soporte para autenticación basada en credenciales (usuario/contraseña).
- Generación y validación de tokens JWT para sesiones seguras.
- Gestión de roles y permisos (ej. editores vs. visitantes).
- Integración con el sistema principal a través de APIs REST.
- Escalabilidad horizontal mediante contenedores y orquestación.

## Fuera de Alcance
- Registro de nuevos usuarios (se asume que se maneja en otro servicio o módulo).
- Gestión de perfiles de usuario detallados.
- Autenticación multifactor (puede agregarse en futuras iteraciones).
- Integración directa con proveedores externos como Google OAuth (limitado a credenciales propias).

---

## Arquitectura General
El servicio de autenticación se implementa como un microservicio independiente, desplegado en contenedores para facilitar la escalabilidad. Utiliza una arquitectura basada en capas:

- **Capa de Presentación**: APIs REST expuestas para login, logout y validación.
- **Capa de Lógica de Negocio**: Manejo de autenticación, generación de tokens y validación de permisos.
- **Capa de Persistencia**: Base de datos dedicada para almacenar usuarios, hashes de contraseñas y tokens revocados.
- **Capa de Seguridad**: Encriptación, validación de tokens y protección contra ataques comunes (ej. brute force).

### Diagrama de Arquitectura
```
[Cliente] --> [API Gateway] --> [Servicio de Autenticación]
                              |
                              --> [Base de Datos de Usuarios]
```

- **API Gateway**: Punto de entrada único, maneja el enrutamiento y puede incluir rate limiting.
- **Servicio de Autenticación**: Microservicio en .NET Core (o lenguaje agnóstico), con endpoints REST.
- **Base de Datos**: PostgreSQL o MongoDB para persistencia, aislada del resto del sistema.

### Tecnologías Sugeridas (Agnósticas)
- **Lenguaje**: C#/.NET Core, Java Spring Boot, Node.js, o Python Flask (dependiendo del stack del proyecto).
- **Base de Datos**: PostgreSQL para datos relacionales o MongoDB para NoSQL.
- **Contenedores**: Docker para empaquetado.
- **Orquestación**: Kubernetes para escalabilidad.
- **Seguridad**: JWT para tokens, bcrypt para hashes de contraseñas, HTTPS obligatorio.

---

## Diagrama de Secuencias: Proceso de Login
```
Cliente -> Servicio de Auth: POST /auth/login (usuario, contraseña)
Servicio de Auth -> Base de Datos: Verificar credenciales
Base de Datos -> Servicio de Auth: Usuario válido
Servicio de Auth -> Servicio de Auth: Generar JWT con claims (usuario, roles)
Servicio de Auth -> Cliente: Retornar JWT
```

1. El cliente envía credenciales.
2. El servicio valida contra la base de datos (usando hash seguro).
3. Si válido, genera un JWT con expiración (ej. 1 hora) y claims (ID de usuario, roles).
4. Retorna el token al cliente.

## Diagrama de Secuencias: Validación de Token
```
Cliente -> API Gateway: Solicitud con Authorization: Bearer <JWT>
API Gateway -> Servicio de Auth: POST /auth/validate (JWT)
Servicio de Auth -> Servicio de Auth: Decodificar y verificar JWT
Servicio de Auth -> Base de Datos: Verificar si token revocado
Servicio de Auth -> API Gateway: Retornar claims o error
API Gateway -> Sistema Principal: Permitir acceso si válido
```

1. El cliente incluye el JWT en headers.
2. El gateway valida con el servicio de auth.
3. Si válido, permite el acceso; si no, retorna 401 Unauthorized.

## Diagrama de Secuencias: Logout
```
Cliente -> Servicio de Auth: POST /auth/logout (JWT)
Servicio de Auth -> Base de Datos: Marcar token como revocado
Servicio de Auth -> Cliente: Confirmación
```

1. El cliente solicita logout.
2. El servicio marca el token como revocado en la base de datos.
3. El cliente debe descartar el token.

---

## Implementación Detallada
### Endpoints de la API
- **POST /auth/login**: Recibe {username, password}, retorna {token, expires_in}.
- **POST /auth/logout**: Recibe Authorization header, marca token como revocado.
- **POST /auth/validate**: Recibe JWT, retorna claims si válido.
- **POST /auth/refresh**: Opcional, para renovar tokens expirados.

### Gestión de Seguridad
- **Encriptación de Contraseñas**: Usar bcrypt o Argon2 para hashes.
- **Tokens JWT**: Firmados con clave privada (RSA), expiración corta.
- **Protección contra Ataques**: Rate limiting en login, blacklist de tokens revocados.
- **Roles y Permisos**: Claims en JWT incluyen roles (ej. "editor", "visitor").

### Escalabilidad y Eficiencia
- **Contenedores**: Cada instancia del servicio es stateless, escalable horizontalmente.
- **Cache**: Redis para tokens revocados o sesiones activas.
- **Monitoreo**: Logs centralizados, métricas de rendimiento.
- **Alta Disponibilidad**: Múltiples instancias detrás de un load balancer.

### Consideraciones de Costos
- **Infraestructura**: Usar servicios cloud agnósticos (ej. VMs, Kubernetes en AWS/GCP/Azure).
- **Optimización**: Minimizar llamadas a base de datos con cache.

---

## Próximos Pasos
1. Implementar el microservicio con las APIs descritas.
2. Configurar la base de datos y migraciones.
3. Integrar con el API Gateway del sistema principal.
4. Probar con casos de uso de autenticación.
5. Desplegar en un entorno de staging para validación.

Este diseño asegura que el servicio de autenticación sea modular, seguro y escalable, permitiendo al sistema crecer sin acoplamientos innecesarios.</content>
<parameter name="filePath">/home/luigi/Documentos/ProyectosSpring/curso_backend_platzi/AuthenticationService_design_doc.md