/* ============================================================
   Parcial #3 - Parte Práctica - Ejercicio 3
   Base de datos para Login con BCrypt
   Estudiante: Wilson Wu | Ingeniería en Sistemas y Computación
   Servidor: .\SQLEXPRESS
   ============================================================ */

IF DB_ID('Parcial3_Login') IS NULL
    CREATE DATABASE Parcial3_Login;
GO

USE Parcial3_Login;
GO

/* ---------- Tabla de usuarios ---------- */
IF OBJECT_ID('dbo.IntentosLogin') IS NOT NULL DROP TABLE dbo.IntentosLogin;
IF OBJECT_ID('dbo.Usuarios') IS NOT NULL DROP TABLE dbo.Usuarios;
GO

CREATE TABLE dbo.Usuarios
(
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario   NVARCHAR(50)  NOT NULL UNIQUE,
    NombreCompleto  NVARCHAR(100) NOT NULL,
    PasswordHash    NVARCHAR(100) NOT NULL,          -- hash BCrypt (60 caracteres), nunca la clave en texto plano
    FechaCreacion   DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

/* ---------- Tabla de intentos (exitosos y fallidos) ---------- */
CREATE TABLE dbo.IntentosLogin
(
    Id             INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId      INT           NULL REFERENCES dbo.Usuarios(Id),  -- NULL si el usuario no existe
    NombreUsuario  NVARCHAR(50)  NOT NULL,                           -- usuario escrito en el login
    Exitoso        BIT           NOT NULL,                           -- 1 = exitoso, 0 = fallido
    Fecha          DATETIME      NOT NULL DEFAULT GETDATE(),
    Detalle        NVARCHAR(100) NULL,
    Equipo         NVARCHAR(100) NULL
);
GO

CREATE INDEX IX_IntentosLogin_Fecha ON dbo.IntentosLogin (Fecha);
GO

/* ---------- Usuario inicial ----------
   Usuario:    wwu
   Contraseña: Parcial3*
   El hash se generó con BCrypt.Net.BCrypt.HashPassword("Parcial3*", 11)
*/
INSERT INTO dbo.Usuarios (NombreUsuario, NombreCompleto, PasswordHash)
VALUES ('wwu', 'Wilson Wu', '$2a$11$6dDDyIehF0uRSoJzePB8ouqTCJr/QVxP9ybZ2cSdt614Q8IYxTt4K');
GO

/* ---------- Consultas para análisis posterior ---------- */
-- SELECT * FROM dbo.Usuarios;
-- SELECT * FROM dbo.IntentosLogin ORDER BY Fecha DESC;
-- SELECT NombreUsuario,
--        SUM(CASE WHEN Exitoso = 1 THEN 1 ELSE 0 END) AS Exitosos,
--        SUM(CASE WHEN Exitoso = 0 THEN 1 ELSE 0 END) AS Fallidos
-- FROM dbo.IntentosLogin GROUP BY NombreUsuario;
