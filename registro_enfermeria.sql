-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 10-10-2024 a las 21:09:20
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `registro_enfermeria`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `atenciones`
--

CREATE TABLE `atenciones` (
  `Id_atencion` int(11) NOT NULL,
  `Id_usuario` int(11) NOT NULL,
  `Id_paciente` int(11) NOT NULL,
  `Id_derivacion` int(11) DEFAULT NULL,
  `Tipo_atencion` longtext DEFAULT NULL,
  `Fecha_atencion` datetime(6) NOT NULL,
  `Hora_atencion` time(6) NOT NULL,
  `Borrado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `derivaciones`
--

CREATE TABLE `derivaciones` (
  `Id_derivacion` int(11) NOT NULL,
  `Tipo_traslado` longtext DEFAULT NULL,
  `Destino` longtext DEFAULT NULL,
  `Borrado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `efectores`
--

CREATE TABLE `efectores` (
  `Id_efector` int(11) NOT NULL,
  `Nombre` longtext DEFAULT NULL,
  `Direccion` longtext DEFAULT NULL,
  `Localidad` longtext DEFAULT NULL,
  `Programa` longtext DEFAULT NULL,
  `Borrado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pacientes`
--

CREATE TABLE `pacientes` (
  `Id_paciente` int(11) NOT NULL,
  `Nombre` longtext DEFAULT NULL,
  `Apellido` longtext DEFAULT NULL,
  `DNI` longtext DEFAULT NULL,
  `Telefono` longtext DEFAULT NULL,
  `Borrado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `prestaciones`
--

CREATE TABLE `prestaciones` (
  `Id_prestacion` int(11) NOT NULL,
  `Id_tipo_prestacion` int(11) NOT NULL,
  `PrestacionNombre` longtext DEFAULT NULL,
  `Borrado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `prestaciones`
--

INSERT INTO `prestaciones` (`Id_prestacion`, `Id_tipo_prestacion`, `PrestacionNombre`, `Borrado`) VALUES
(1, 1, 'Venoclisis', 0),
(2, 1, 'V. Endovenosa', 0),
(3, 1, 'V. Intramuscular', 0),
(4, 1, 'V. Subcutánea', 0),
(5, 2, 'Via Oral', 0),
(6, 2, 'V. Sublingual', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registrosatencion`
--

CREATE TABLE `registrosatencion` (
  `Id_registro_atencion` int(11) NOT NULL,
  `Id_atencion` int(11) NOT NULL,
  `Id_prestacion` int(11) NOT NULL,
  `Observaciones` longtext DEFAULT NULL,
  `Borrado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tiposprestacion`
--

CREATE TABLE `tiposprestacion` (
  `Id_tipo_prestacion` int(11) NOT NULL,
  `Tipo_prestacion` longtext DEFAULT NULL,
  `Borrado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tiposprestacion`
--

INSERT INTO `tiposprestacion` (`Id_tipo_prestacion`, `Tipo_prestacion`, `Borrado`) VALUES
(1, 'Parenteral', 0),
(2, 'Enteral', 0),
(3, 'Mucosas y Piel', 0),
(4, 'Curaciones', 0),
(5, 'Lavajes', 0),
(6, 'Sondaje', 0),
(7, 'Antropometria', 0),
(8, 'Controles', 0),
(9, 'Internacion', 0),
(10, 'Triagge', 0),
(11, 'Salidas de Ambulancia (Propia)', 0),
(12, 'Salidas de Ambulancia (Sempro)', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Id_usuario` int(11) NOT NULL,
  `Id_efector` int(11) NOT NULL,
  `Nombre` longtext DEFAULT NULL,
  `Apellido` longtext DEFAULT NULL,
  `DNI` longtext DEFAULT NULL,
  `Correo` longtext DEFAULT NULL,
  `Telefono` longtext DEFAULT NULL,
  `Hash_Password` longtext DEFAULT NULL,
  `Rol` longtext DEFAULT NULL,
  `Borrado` tinyint(1) NOT NULL,
  `EfectorId_efector` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241010175201_Inicial', '8.0.10');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `atenciones`
--
ALTER TABLE `atenciones`
  ADD PRIMARY KEY (`Id_atencion`),
  ADD KEY `IX_Atenciones_Id_derivacion` (`Id_derivacion`),
  ADD KEY `IX_Atenciones_Id_paciente` (`Id_paciente`),
  ADD KEY `IX_Atenciones_Id_usuario` (`Id_usuario`);

--
-- Indices de la tabla `derivaciones`
--
ALTER TABLE `derivaciones`
  ADD PRIMARY KEY (`Id_derivacion`);

--
-- Indices de la tabla `efectores`
--
ALTER TABLE `efectores`
  ADD PRIMARY KEY (`Id_efector`);

--
-- Indices de la tabla `pacientes`
--
ALTER TABLE `pacientes`
  ADD PRIMARY KEY (`Id_paciente`);

--
-- Indices de la tabla `prestaciones`
--
ALTER TABLE `prestaciones`
  ADD PRIMARY KEY (`Id_prestacion`),
  ADD KEY `IX_Prestaciones_Id_tipo_prestacion` (`Id_tipo_prestacion`);

--
-- Indices de la tabla `registrosatencion`
--
ALTER TABLE `registrosatencion`
  ADD PRIMARY KEY (`Id_registro_atencion`),
  ADD KEY `IX_RegistrosAtencion_Id_atencion` (`Id_atencion`),
  ADD KEY `IX_RegistrosAtencion_Id_prestacion` (`Id_prestacion`);

--
-- Indices de la tabla `tiposprestacion`
--
ALTER TABLE `tiposprestacion`
  ADD PRIMARY KEY (`Id_tipo_prestacion`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id_usuario`),
  ADD KEY `IX_Usuarios_EfectorId_efector` (`EfectorId_efector`);

--
-- Indices de la tabla `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `atenciones`
--
ALTER TABLE `atenciones`
  MODIFY `Id_atencion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `derivaciones`
--
ALTER TABLE `derivaciones`
  MODIFY `Id_derivacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `efectores`
--
ALTER TABLE `efectores`
  MODIFY `Id_efector` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `pacientes`
--
ALTER TABLE `pacientes`
  MODIFY `Id_paciente` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `prestaciones`
--
ALTER TABLE `prestaciones`
  MODIFY `Id_prestacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `registrosatencion`
--
ALTER TABLE `registrosatencion`
  MODIFY `Id_registro_atencion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tiposprestacion`
--
ALTER TABLE `tiposprestacion`
  MODIFY `Id_tipo_prestacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id_usuario` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `atenciones`
--
ALTER TABLE `atenciones`
  ADD CONSTRAINT `FK_Atenciones_Derivaciones_Id_derivacion` FOREIGN KEY (`Id_derivacion`) REFERENCES `derivaciones` (`Id_derivacion`),
  ADD CONSTRAINT `FK_Atenciones_Pacientes_Id_paciente` FOREIGN KEY (`Id_paciente`) REFERENCES `pacientes` (`Id_paciente`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Atenciones_Usuarios_Id_usuario` FOREIGN KEY (`Id_usuario`) REFERENCES `usuarios` (`Id_usuario`) ON DELETE CASCADE;

--
-- Filtros para la tabla `prestaciones`
--
ALTER TABLE `prestaciones`
  ADD CONSTRAINT `FK_Prestaciones_TiposPrestacion_Id_tipo_prestacion` FOREIGN KEY (`Id_tipo_prestacion`) REFERENCES `tiposprestacion` (`Id_tipo_prestacion`) ON DELETE CASCADE;

--
-- Filtros para la tabla `registrosatencion`
--
ALTER TABLE `registrosatencion`
  ADD CONSTRAINT `FK_RegistrosAtencion_Atenciones_Id_atencion` FOREIGN KEY (`Id_atencion`) REFERENCES `atenciones` (`Id_atencion`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_RegistrosAtencion_Prestaciones_Id_prestacion` FOREIGN KEY (`Id_prestacion`) REFERENCES `prestaciones` (`Id_prestacion`) ON DELETE CASCADE;

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `FK_Usuarios_Efectores_EfectorId_efector` FOREIGN KEY (`EfectorId_efector`) REFERENCES `efectores` (`Id_efector`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
