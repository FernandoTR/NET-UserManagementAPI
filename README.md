# UserManagementAPI

## 📌 Propósito

La **UserManagementAPI** es una API RESTful desarrollada para **Curso de Backend Microsoft**.

Esta API permite **crear**, **consultar**, **actualizar** y **eliminar** registros de usuarios, cumpliendo con requisitos corporativos de **auditoría**, **seguridad** y **manejo uniforme de errores**, mediante la integración de **middleware personalizado**.

---

## 🚀 Características principales

- CRUD completo para gestión de usuarios
- Middleware personalizado para:
  - Logging de solicitudes y respuestas
  - Manejo global de errores con respuestas JSON
  - Autenticación por token
- Validaciones mediante Data Annotations
- API documentada con Swagger (modo desarrollo)

---

## 🔗 Endpoints

| Método | Ruta                 | Descripción                          |
|--------|----------------------|--------------------------------------|
| GET    | `/api/users`         | Obtener todos los usuarios           |
| GET    | `/api/users/{id}`    | Obtener un usuario por ID            |
| POST   | `/api/users`         | Crear un nuevo usuario               |
| PUT    | `/api/users/{id}`    | Actualizar datos de un usuario       |
| DELETE | `/api/users/{id}`    | Eliminar un usuario por ID           |

### 📥 Ejemplo de JSON para POST / PUT

```json
{
  "firstName": "Fernando",
  "lastName": "Ramírez",
  "email": "fernando.ramirez@techhive.com",
  "department": "TI"
}
```
## 📁 Estructura del Proyecto
UserManagementAPI/
│
├── Controllers/
│   └── UsersController.cs         // Endpoints REST de usuario
│
├── Middleware/
│   ├── ErrorHandlingMiddleware.cs         // Manejo global de errores
│   ├── RequestResponseLoggingMiddleware.cs // Logging de peticiones y respuestas
│   └── TokenAuthenticationMiddleware.cs    // Autenticación por token
│
├── Models/
│   └── User.cs                    // Modelo de datos con validaciones
│
├── appsettings.json              // Configuración de token
└── Program.cs                    // Configuración del pipeline


## 🧱 Middleware Implementado
1. 🔐 TokenAuthenticationMiddleware
Extrae y valida el token desde el header Authorization

Retorna 401 Unauthorized si el token es inválido o ausente

2. ❌ ErrorHandlingMiddleware
Captura todas las excepciones no controladas

Devuelve una respuesta JSON estándar:

json
Copiar
Editar
{ "error": "Internal server error." }
3. 📝 RequestResponseLoggingMiddleware
Registra método HTTP, ruta solicitada y código de estado de la respuesta

Útil para trazabilidad y auditoría

