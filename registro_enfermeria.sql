-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 04-10-2024 a las 21:12:41
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
-- Estructura de tabla para la tabla `atencion`
--

CREATE TABLE `atencion` (
  `Id_atencion` int(11) NOT NULL,
  `Id_usuario` int(11) NOT NULL,
  `Id_paciente` int(11) NOT NULL,
  `Id_derivacion` int(11) DEFAULT NULL,
  `Tipo_atencion` varchar(100) DEFAULT NULL,
  `Fecha_atencion` date NOT NULL,
  `Hora_atencion` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `derivacion`
--

CREATE TABLE `derivacion` (
  `Id_derivacion` int(11) NOT NULL,
  `Tipo_traslado` varchar(100) DEFAULT NULL,
  `Destino` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `efector`
--

CREATE TABLE `efector` (
  `Id_efector` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Direccion` varchar(255) DEFAULT NULL,
  `Localidad` varchar(100) DEFAULT NULL,
  `Programa` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `paciente`
--

CREATE TABLE `paciente` (
  `Id_paciente` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `DNI` varchar(20) NOT NULL,
  `Telefono` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `prestacion`
--

CREATE TABLE `prestacion` (
  `Id_prestacion` int(11) NOT NULL,
  `Id_tipo_prestacion` int(11) NOT NULL,
  `Prestacion` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registro_atencion`
--

CREATE TABLE `registro_atencion` (
  `Id_registro_atencion` int(11) NOT NULL,
  `Id_atencion` int(11) NOT NULL,
  `Id_prestacion` int(11) NOT NULL,
  `Observaciones` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_prestacion`
--

CREATE TABLE `tipo_prestacion` (
  `Id_tipo_prestacion` int(11) NOT NULL,
  `Tipo_prestacion` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Id_usuario` int(11) NOT NULL,
  `Id_efector` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `DNI` varchar(20) NOT NULL,
  `Correo` varchar(100) NOT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  `Hash_Password` varchar(255) NOT NULL,
  `Rol` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `atencion`
--
ALTER TABLE `atencion`
  ADD PRIMARY KEY (`Id_atencion`),
  ADD KEY `FK_Atencion_Usuarios` (`Id_usuario`),
  ADD KEY `FK_Atencion_Paciente` (`Id_paciente`),
  ADD KEY `FK_Atencion_Derivacion` (`Id_derivacion`);

--
-- Indices de la tabla `derivacion`
--
ALTER TABLE `derivacion`
  ADD PRIMARY KEY (`Id_derivacion`);

--
-- Indices de la tabla `efector`
--
ALTER TABLE `efector`
  ADD PRIMARY KEY (`Id_efector`);

--
-- Indices de la tabla `paciente`
--
ALTER TABLE `paciente`
  ADD PRIMARY KEY (`Id_paciente`),
  ADD UNIQUE KEY `DNI` (`DNI`);

--
-- Indices de la tabla `prestacion`
--
ALTER TABLE `prestacion`
  ADD PRIMARY KEY (`Id_prestacion`),
  ADD KEY `FK_Prestacion_TipoPrestacion` (`Id_tipo_prestacion`);

--
-- Indices de la tabla `registro_atencion`
--
ALTER TABLE `registro_atencion`
  ADD PRIMARY KEY (`Id_registro_atencion`),
  ADD KEY `FK_RegistroAtencion_Atencion` (`Id_atencion`),
  ADD KEY `FK_RegistroAtencion_Prestacion` (`Id_prestacion`);

--
-- Indices de la tabla `tipo_prestacion`
--
ALTER TABLE `tipo_prestacion`
  ADD PRIMARY KEY (`Id_tipo_prestacion`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id_usuario`),
  ADD UNIQUE KEY `DNI` (`DNI`),
  ADD KEY `FK_Usuarios_Efector` (`Id_efector`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `atencion`
--
ALTER TABLE `atencion`
  MODIFY `Id_atencion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `derivacion`
--
ALTER TABLE `derivacion`
  MODIFY `Id_derivacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `efector`
--
ALTER TABLE `efector`
  MODIFY `Id_efector` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `paciente`
--
ALTER TABLE `paciente`
  MODIFY `Id_paciente` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `prestacion`
--
ALTER TABLE `prestacion`
  MODIFY `Id_prestacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `registro_atencion`
--
ALTER TABLE `registro_atencion`
  MODIFY `Id_registro_atencion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tipo_prestacion`
--
ALTER TABLE `tipo_prestacion`
  MODIFY `Id_tipo_prestacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id_usuario` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `atencion`
--
ALTER TABLE `atencion`
  ADD CONSTRAINT `FK_Atencion_Derivacion` FOREIGN KEY (`Id_derivacion`) REFERENCES `derivacion` (`Id_derivacion`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_Atencion_Paciente` FOREIGN KEY (`Id_paciente`) REFERENCES `paciente` (`Id_paciente`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Atencion_Usuarios` FOREIGN KEY (`Id_usuario`) REFERENCES `usuarios` (`Id_usuario`) ON DELETE CASCADE;

--
-- Filtros para la tabla `prestacion`
--
ALTER TABLE `prestacion`
  ADD CONSTRAINT `FK_Prestacion_TipoPrestacion` FOREIGN KEY (`Id_tipo_prestacion`) REFERENCES `tipo_prestacion` (`Id_tipo_prestacion`) ON DELETE CASCADE;

--
-- Filtros para la tabla `registro_atencion`
--
ALTER TABLE `registro_atencion`
  ADD CONSTRAINT `FK_RegistroAtencion_Atencion` FOREIGN KEY (`Id_atencion`) REFERENCES `atencion` (`Id_atencion`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_RegistroAtencion_Prestacion` FOREIGN KEY (`Id_prestacion`) REFERENCES `prestacion` (`Id_prestacion`) ON DELETE CASCADE;

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `FK_Usuarios_Efector` FOREIGN KEY (`Id_efector`) REFERENCES `efector` (`Id_efector`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
