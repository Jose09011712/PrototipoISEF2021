-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-06-2021 a las 21:21:05
-- Versión del servidor: 10.4.17-MariaDB
-- Versión de PHP: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dbcvierp2`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ExistenciaProducto` (IN `IdEmpresa` INT, IN `IdSucursal` INT, IN `IdBodega` INT, IN `Producto` INT)  BEGIN
	select cantidad_existencia from existencia where fkIdEmpresa=IdEmpresa and fkIdSucursal=IdSucursal and fkIdBodega=IdBodega and fkIdPro=Producto;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Login` (IN `UserLogin` VARCHAR(45), IN `PassLogin` VARCHAR(45))  BEGIN
select usuario_login, contraseña_login from login where usuario_login=UserLogin and contraseña_login=PassLogin and  estado_login = 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_MovimientoInventario` (IN `idMovmiento` INT, IN `idEmpresaOrigen` INT, IN `idSucursalOrigen` INT, IN `idBodegaOrigen` INT, IN `idEmpresaDestino` INT, IN `idSucursalDestino` INT, IN `idBodegaDestino` INT, IN `idProducto` INT, IN `CantidadMover` INT, IN `Razon` VARCHAR(100), IN `idUsuario` INT, IN `Accion` INT)  BEGIN
if (select cantidad_existencia from existencia where fkIdEmpresa=idEmpresaOrigen and fkIdSucursal=idSucursalOrigen and fkIdBodega=idBodegaOrigen and fkIdPro=idProducto) > CantidadMover and Accion = 1 then
	update existencia set cantidad_existencia = cantidad_existencia - CantidadMover where fkIdEmpresa=idEmpresaOrigen and fkIdSucursal=idSucursalOrigen and fkIdBodega=idBodegaOrigen and fkIdPro=idProducto;
    update existencia set cantidad_existencia = cantidad_existencia + CantidadMover where fkIdEmpresa=idEmpresaDestino and fkIdSucursal=idSucursalDestino and fkIdBodega=idBodegaDestino and fkIdPro=idProducto;
    INSERT INTO `dbcvierp2`.`movimientoinventario` (`fkidproducto`, `fkbodegaorigen`, `fkbodegadestino`, `cantidad`, `razon`, `fkencargado`) VALUES (idProducto, idBodegaOrigen, idBodegaDestino, CantidadMover, Razon, idUsuario);

else
	update existencia set cantidad_existencia = cantidad_existencia + CantidadMover where fkIdEmpresa=idEmpresaOrigen and fkIdSucursal=idSucursalOrigen and fkIdBodega=idBodegaOrigen and fkIdPro=idProducto;
    update existencia set cantidad_existencia = cantidad_existencia - CantidadMover where fkIdEmpresa=idEmpresaDestino and fkIdSucursal=idSucursalDestino and fkIdBodega=idBodegaDestino and fkIdPro=idProducto;
    DELETE FROM `movimientoinventario` WHERE (`pkmovimiento` = idMovmiento);
end if;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apartado`
--

CREATE TABLE `apartado` (
  `pkIdApartado` int(10) NOT NULL,
  `fkIdEmpresa` int(10) NOT NULL,
  `fkIdSucursal` int(10) NOT NULL,
  `fkIdCliente` int(10) NOT NULL,
  `fechaApartado` varchar(15) NOT NULL,
  `totalApartado` float(10,2) NOT NULL,
  `estadoApartado` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apartadodetalle`
--

CREATE TABLE `apartadodetalle` (
  `pkApartadoDetalle` int(10) NOT NULL,
  `fkIdApartado` int(10) NOT NULL,
  `fkIdProducto` int(10) NOT NULL,
  `cantidadApartada` int(10) NOT NULL,
  `costoApartado` float(10,2) NOT NULL,
  `precioApartado` float(10,2) NOT NULL,
  `fkIdBodega` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aplicacion`
--

CREATE TABLE `aplicacion` (
  `pk_id_aplicacion` int(10) NOT NULL,
  `fk_id_modulo` int(10) NOT NULL,
  `nombre_aplicacion` varchar(40) NOT NULL,
  `descripcion_aplicacion` varchar(45) NOT NULL,
  `archivoCHM` varchar(250) DEFAULT NULL,
  `archivoHTML` varchar(250) DEFAULT NULL,
  `estado_aplicacion` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aplicacion`
--

INSERT INTO `aplicacion` (`pk_id_aplicacion`, `fk_id_modulo`, `nombre_aplicacion`, `descripcion_aplicacion`, `archivoCHM`, `archivoHTML`, `estado_aplicacion`) VALUES
(1, 1, 'Login', 'Ventana de Ingreso', NULL, NULL, 1),
(2, 1, 'Mantenimiento Usuario', 'Mantenimientos de usuario', NULL, NULL, 1),
(3, 1, 'Mantenimiento Aplicacion', 'ABC de las Aplicaciones', NULL, NULL, 1),
(4, 1, 'Mantenimiento Perfil', 'ABC de perfiles', NULL, NULL, 1),
(5, 1, 'Asignacion de Aplicaciones a Perfil', 'Asignacion Aplicacion y perfil', NULL, NULL, 1),
(6, 1, 'Asignacaion de Aplicaciones', 'Asignacion especificas a un usuario', NULL, NULL, 1),
(7, 1, 'Consulta Aplicacion', 'Mantenimiento de Aplicaciones', NULL, NULL, 1),
(8, 1, 'Agregar Modulo', 'Mantenimientos de Modulos', NULL, NULL, 1),
(9, 1, 'Consultar Perfil', 'Consultas de perfiles disponibles', NULL, NULL, 1),
(10, 1, 'Permisos', 'Asignar permisos a perfiles y aplicaciones', NULL, NULL, 1),
(11, 1, 'Cambio de Contraseña', 'Cambia las contraseñas', NULL, NULL, 1),
(12, 1, 'Reporte De Bitacora', 'Reporte de bitacora', NULL, NULL, 1),
(301, 4, 'Mantenimiento Linea', 'Mantenimiento de Linea', NULL, NULL, 1),
(302, 4, 'Mantenimineto Marca', 'Mantenimiento Marca', NULL, NULL, 1),
(303, 4, 'Mantenimiento Producto', 'Mantenimiento Producto', NULL, NULL, 1),
(304, 4, 'Mantenimiento Bodegas', 'Mantenimiento Bodegas', NULL, NULL, 1),
(305, 4, 'Existencias', 'Verificar las existencias en bodega', NULL, NULL, 1),
(306, 4, 'Verificar Cita', 'Proceso para la verifiacacion de Citas', NULL, NULL, 1),
(307, 4, 'Modificar Cita', 'Proceso para la modificacion de citas', NULL, NULL, 1),
(308, 4, 'Proceso Verificacion de datos', 'Para nuevos y renovacion de pasaporte', NULL, NULL, 1),
(309, 4, 'Proceso Primer pasaporte', 'Proceso para renovar o nuevo pasaporte', NULL, NULL, 1),
(310, 4, 'Impresion de pasaporte', 'Impresion de pasaporte', NULL, NULL, 1),
(311, 4, 'Reporte De Citas', 'Reporte De Citas', NULL, NULL, 1),
(312, 4, 'Reporte De Pasaportes', 'Reporte De Pasaportes', NULL, NULL, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aplicacion_perfil`
--

CREATE TABLE `aplicacion_perfil` (
  `pk_id_aplicacion_perfil` int(10) NOT NULL,
  `fk_idaplicacion_aplicacion_perfil` int(10) DEFAULT NULL,
  `fk_idperfil_aplicacion_perfil` int(10) DEFAULT NULL,
  `fk_idpermiso_aplicacion_perfil` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aplicacion_perfil`
--

INSERT INTO `aplicacion_perfil` (`pk_id_aplicacion_perfil`, `fk_idaplicacion_aplicacion_perfil`, `fk_idperfil_aplicacion_perfil`, `fk_idpermiso_aplicacion_perfil`) VALUES
(1, 1, 1, 1),
(2, 2, 1, 2),
(3, 3, 1, 3),
(4, 4, 1, 4),
(5, 5, 1, 5),
(6, 6, 1, 6),
(7, 7, 1, 7),
(8, 8, 1, 8),
(9, 9, 1, 9),
(10, 10, 1, 10),
(11, 11, 1, 11),
(12, 12, 1, 12);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aplicacion_usuario`
--

CREATE TABLE `aplicacion_usuario` (
  `pk_id_aplicacion_usuario` int(10) NOT NULL,
  `fk_idlogin_aplicacion_usuario` int(10) DEFAULT NULL,
  `fk_idaplicacion_aplicacion_usuario` int(10) DEFAULT NULL,
  `fk_idpermiso_aplicacion_usuario` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aplicacion_usuario`
--

INSERT INTO `aplicacion_usuario` (`pk_id_aplicacion_usuario`, `fk_idlogin_aplicacion_usuario`, `fk_idaplicacion_aplicacion_usuario`, `fk_idpermiso_aplicacion_usuario`) VALUES
(1, 1, 1, 13),
(2, 1, 2, 14),
(3, 1, 3, 15),
(4, 1, 4, 16),
(5, 1, 5, 17),
(6, 1, 6, 18),
(7, 1, 7, 19),
(8, 1, 8, 20),
(9, 1, 9, 21),
(10, 1, 10, 22),
(11, 1, 11, 23),
(12, 1, 12, 24),
(13, 1, 301, 25),
(14, 1, 302, 26),
(15, 1, 303, 27),
(16, 1, 304, 28),
(17, 1, 305, 29),
(18, 1, 306, 30),
(19, 1, 307, 31),
(20, 1, 308, 32),
(21, 1, 309, 33),
(22, 1, 310, 34),
(23, 1, 311, 35),
(24, 1, 312, 36);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bitacora`
--

CREATE TABLE `bitacora` (
  `pk_id_bitacora` int(10) NOT NULL,
  `fk_idusuario_bitacora` int(10) DEFAULT NULL,
  `fk_idaplicacion_bitacora` int(10) DEFAULT NULL,
  `fechahora_bitacora` varchar(50) DEFAULT NULL,
  `direccionhost_bitacora` varchar(20) DEFAULT NULL,
  `nombrehost_bitacora` varchar(20) DEFAULT NULL,
  `accion_bitacora` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bitacora`
--

INSERT INTO `bitacora` (`pk_id_bitacora`, `fk_idusuario_bitacora`, `fk_idaplicacion_bitacora`, `fechahora_bitacora`, `direccionhost_bitacora`, `nombrehost_bitacora`, `accion_bitacora`) VALUES
(1, 1, 1, '02/06/2021 10:30:21', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(2, 1, 1, '02/06/2021 10:50:04', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(3, 1, 1, '02/06/2021 10:51:48', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(4, 1, 1, '02/06/2021 10:53:08', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(5, 1, 1, '02/06/2021 10:54:22', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(6, 1, 1, '02/06/2021 10:58:01', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(7, 1, 1, '02/06/2021 11:00:32', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(8, 1, 1, '02/06/2021 11:02:04', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(9, 1, 1, '02/06/2021 11:04:42', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(10, 1, 1, '02/06/2021 11:08:48', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(11, 1, 1, '02/06/2021 11:18:42', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(12, 1, 1, '02/06/2021 11:20:18', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(13, 1, 1, '02/06/2021 11:21:47', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(14, 1, 1, '02/06/2021 11:24:34', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(15, 1, 1, '02/06/2021 11:33:27', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(16, 1, 1, '02/06/2021 11:35:50', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(17, 1, 1, '02/06/2021 11:47:26', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(18, 1, 1, '02/06/2021 11:48:00', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(19, 1, 1, '02/06/2021 11:49:56', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(20, 1, 1, '02/06/2021 11:50:35', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(21, 1, 1, '02/06/2021 11:52:09', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(22, 1, 1, '02/06/2021 11:53:20', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(23, 1, 1, '02/06/2021 11:56:04', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(24, 1, 1, '02/06/2021 11:57:46', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(25, 1, 1, '02/06/2021 11:59:01', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(26, 1, 1, '02/06/2021 12:15:29', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(27, 1, 1, '02/06/2021 12:20:33', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso'),
(28, 1, 1, '02/06/2021 12:29:46', 'fdb4:f58e:1300:1d00:', 'DESKTOP-7VFVMJ5', 'Logeo Exitoso');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bodega`
--

CREATE TABLE `bodega` (
  `pkIdBodega` int(10) NOT NULL,
  `fkIdEmpresa` int(10) DEFAULT NULL,
  `fkIdSucursal` int(10) DEFAULT NULL,
  `fkIdDepar` int(10) DEFAULT NULL,
  `fkIdMuni` int(10) NOT NULL,
  `descripcionBodega` varchar(250) NOT NULL,
  `direccionBodega` varchar(45) NOT NULL,
  `telefonoBodega` int(8) NOT NULL,
  `estadoBodega` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bodega`
--

INSERT INTO `bodega` (`pkIdBodega`, `fkIdEmpresa`, `fkIdSucursal`, `fkIdDepar`, `fkIdMuni`, `descripcionBodega`, `direccionBodega`, `telefonoBodega`, `estadoBodega`) VALUES
(1, 1, 1, 1, 1, 'DESCRIPCION1', 'DIRECCION1', 12345678, 1),
(2, 2, 1, 1, 1, 'DESCRIPCION2', 'DIRECCION2', 12345678, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `pkIdCliente` int(5) NOT NULL,
  `nombreCliente` varchar(30) DEFAULT NULL,
  `apellidoCliente` varchar(30) DEFAULT NULL,
  `direccionCliente` varchar(60) DEFAULT NULL,
  `fkIdDepar` int(10) DEFAULT NULL,
  `fkIdMuni` int(10) DEFAULT NULL,
  `codigoPostal` varchar(5) DEFAULT NULL,
  `nitCliente` varchar(20) DEFAULT NULL,
  `telCliente` varchar(50) DEFAULT NULL,
  `estadoCliente` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`pkIdCliente`, `nombreCliente`, `apellidoCliente`, `direccionCliente`, `fkIdDepar`, `fkIdMuni`, `codigoPostal`, `nitCliente`, `telCliente`, `estadoCliente`) VALUES
(1, 'Jose ', 'Lopez', 'Guatemala', 1, 1, '001', '123456', '123456789', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cobro`
--

CREATE TABLE `cobro` (
  `pkNoRegistroCobro` int(10) NOT NULL,
  `fkIdRegistroCuenta` int(10) NOT NULL,
  `fkIdEmpleado` int(10) NOT NULL,
  `descripcionCobro` int(10) NOT NULL,
  `fechaPago` varchar(15) NOT NULL,
  `fkIdMetodoPago` int(10) NOT NULL,
  `montoAbonado` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compradetalle`
--

CREATE TABLE `compradetalle` (
  `fkNoDocumentoEnca` int(10) NOT NULL,
  `fkIdPro` int(10) NOT NULL,
  `cantidadCompraDe` int(10) NOT NULL,
  `costoCompraDe` double(8,2) NOT NULL,
  `estado` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compraencabezado`
--

CREATE TABLE `compraencabezado` (
  `pkNoDocumentoEnca` int(10) NOT NULL,
  `fkIdProv` int(10) NOT NULL,
  `fkIdEmpleado` int(10) NOT NULL,
  `fkIdEmpresa` int(10) NOT NULL,
  `fkIdSucursal` int(10) NOT NULL,
  `fkIdBodegadestino` int(10) NOT NULL,
  `fechaCompra` varchar(15) DEFAULT NULL,
  `totalCompra` double(12,2) NOT NULL,
  `fktipocompra` int(10) NOT NULL,
  `fkmetodoPago` int(10) DEFAULT NULL,
  `estadoCompra` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `compraencabezado`
--

INSERT INTO `compraencabezado` (`pkNoDocumentoEnca`, `fkIdProv`, `fkIdEmpleado`, `fkIdEmpresa`, `fkIdSucursal`, `fkIdBodegadestino`, `fechaCompra`, `totalCompra`, `fktipocompra`, `fkmetodoPago`, `estadoCompra`) VALUES
(1, 1, 1, 1, 1, 1, '04052021', 10.00, 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cotizadetalle`
--

CREATE TABLE `cotizadetalle` (
  `pkIdCotizaDetalle` int(10) NOT NULL,
  `fkDocumentoCotizaEnca` int(10) DEFAULT NULL,
  `fkIdPro` int(10) DEFAULT NULL,
  `cantidadCotizar` int(10) DEFAULT NULL,
  `precioCotiza` float(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cotizaencabezado`
--

CREATE TABLE `cotizaencabezado` (
  `pkDocumentoCotizaEnca` int(10) NOT NULL,
  `fkIdCliente` int(10) NOT NULL,
  `fkIdEmpresa` int(10) NOT NULL,
  `fkIdSucursal` int(10) NOT NULL,
  `fkIdEmpleado` int(10) NOT NULL,
  `fechaRequerida` varchar(15) NOT NULL,
  `fechaEnvio` varchar(15) NOT NULL,
  `vigenciaCotizacion` varchar(15) NOT NULL,
  `totalCotizacion` float(10,2) NOT NULL,
  `estadoCotizacion` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas`
--

CREATE TABLE `cuentas` (
  `pkIdRegistroCuentas` int(10) NOT NULL,
  `fkIdEmpresa` int(10) NOT NULL,
  `fkIdSucursal` int(10) NOT NULL,
  `NoDocumento` int(10) NOT NULL,
  `tipoCuenta` int(2) NOT NULL,
  `fkIdEmpleado` int(10) NOT NULL,
  `fechaRealizada` varchar(15) NOT NULL,
  `tiempoDeCredito` int(5) NOT NULL,
  `montoPagado` float(10,2) NOT NULL,
  `montoPendiente` float(10,2) NOT NULL,
  `montoTotal` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `departamento`
--

CREATE TABLE `departamento` (
  `pkIdDepar` int(10) NOT NULL,
  `nombreDepar` varchar(30) DEFAULT NULL,
  `descripcionDepar` varchar(45) DEFAULT NULL,
  `estadoDepar` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `departamento`
--

INSERT INTO `departamento` (`pkIdDepar`, `nombreDepar`, `descripcionDepar`, `estadoDepar`) VALUES
(1, 'DEPARTA1', 'DESCRIPCION1', 1),
(2, 'DEPART2', 'DESCRIP2', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detallepedido`
--

CREATE TABLE `detallepedido` (
  `pkIdDetallePedido` int(10) NOT NULL,
  `fkIdPedido` int(10) NOT NULL,
  `fkIdProducto` int(10) NOT NULL,
  `cantidadDetalle` int(10) NOT NULL,
  `costoDetalle` float(10,2) NOT NULL,
  `precioDetalle` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_bitacora`
--

CREATE TABLE `detalle_bitacora` (
  `pk_id_detalle_bitacora` int(10) NOT NULL,
  `fk_idbitacora_detalle_bitacora` int(10) DEFAULT NULL,
  `querryantigua_detalle_bitacora` varchar(50) DEFAULT NULL,
  `querrynueva_detalle_bitacora` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `pkIdEmpleado` int(10) NOT NULL,
  `idManager` int(10) DEFAULT NULL,
  `fkIdEmpresa` int(10) DEFAULT NULL,
  `fkIdSucursal` int(10) DEFAULT NULL,
  `fkIdPuesto` int(10) DEFAULT NULL,
  `nombreEmpleado` varchar(30) DEFAULT NULL,
  `apellidoEmpleado` varchar(30) DEFAULT NULL,
  `cuiEmpleado` varchar(15) DEFAULT NULL,
  `telefonoEmpleado` varchar(15) DEFAULT NULL,
  `emailEmpleado` varchar(30) DEFAULT NULL,
  `estadoEmpleado` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`pkIdEmpleado`, `idManager`, `fkIdEmpresa`, `fkIdSucursal`, `fkIdPuesto`, `nombreEmpleado`, `apellidoEmpleado`, `cuiEmpleado`, `telefonoEmpleado`, `emailEmpleado`, `estadoEmpleado`) VALUES
(1, 1, 1, 1, 1, 'Julio', 'Morataya', '1010', '898491', 'hola@gmail.com', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa`
--

CREATE TABLE `empresa` (
  `pkIdEmpresa` int(10) NOT NULL,
  `nombreEmpresa` varchar(100) DEFAULT NULL,
  `fkIdPais` int(10) DEFAULT NULL,
  `direccionDeLugar` varchar(50) DEFAULT NULL,
  `fkIdDepar` int(10) DEFAULT NULL,
  `fkIdMuni` int(10) DEFAULT NULL,
  `estadoEmpresa` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `empresa`
--

INSERT INTO `empresa` (`pkIdEmpresa`, `nombreEmpresa`, `fkIdPais`, `direccionDeLugar`, `fkIdDepar`, `fkIdMuni`, `estadoEmpresa`) VALUES
(1, 'EMPRESA1', 1, 'DIRECCION1', 1, 1, 1),
(2, 'EMPRESA2', 1, 'DIRECCION2', 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `existencia`
--

CREATE TABLE `existencia` (
  `pkIdExis` int(10) NOT NULL,
  `fkIdEmpresa` int(10) NOT NULL,
  `fkIdSucursal` int(10) DEFAULT NULL,
  `fkIdBodega` int(10) NOT NULL,
  `fkIdPro` int(10) NOT NULL,
  `cantidad_existencia` int(10) NOT NULL,
  `existencia_minima` int(10) NOT NULL,
  `existencia_maxima` int(10) NOT NULL,
  `estado_existencia` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `existencia`
--

INSERT INTO `existencia` (`pkIdExis`, `fkIdEmpresa`, `fkIdSucursal`, `fkIdBodega`, `fkIdPro`, `cantidad_existencia`, `existencia_minima`, `existencia_maxima`, `estado_existencia`) VALUES
(1, 1, 1, 1, 1, 100, 50, 200, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lineaproducto`
--

CREATE TABLE `lineaproducto` (
  `pkIdLineaPro` int(10) NOT NULL,
  `fkIdEmpresa` int(10) DEFAULT NULL,
  `nombreLineaPro` varchar(25) NOT NULL,
  `descripcionLineaPro` varchar(50) NOT NULL,
  `estadoLineaPro` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `lineaproducto`
--

INSERT INTO `lineaproducto` (`pkIdLineaPro`, `fkIdEmpresa`, `nombreLineaPro`, `descripcionLineaPro`, `estadoLineaPro`) VALUES
(1, 1, 'LINEA1', 'DESCRIPCION1', 1),
(2, 2, 'LINEA2', 'DESCRIPCION2', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `login`
--

CREATE TABLE `login` (
  `pk_id_login` int(10) NOT NULL,
  `usuario_login` varchar(45) DEFAULT NULL,
  `contraseña_login` varchar(45) DEFAULT NULL,
  `nombreCompleto_login` varchar(100) DEFAULT NULL,
  `estado_login` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `login`
--

INSERT INTO `login` (`pk_id_login`, `usuario_login`, `contraseña_login`, `nombreCompleto_login`, `estado_login`) VALUES
(1, 'sistema', 'bi0PL96rbxVRPKJQsLJJAg==', 'Usuario de prueba', 1),
(2, 'admin', 'T+4Ai6O3CR0kJYxCgXy2jA==', 'Administrador', 1),
(3, 'morataya', '5g2jpUc7tYd0Q0iop9+lfA==', 'Julio Morataya', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `marcaproducto`
--

CREATE TABLE `marcaproducto` (
  `pkIdMarcaPro` int(10) NOT NULL,
  `fkIdEmpresa` int(10) DEFAULT NULL,
  `nombreMarcaPro` varchar(35) NOT NULL,
  `descripcionMarcaPro` varchar(60) NOT NULL,
  `estadoMarcaPro` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `marcaproducto`
--

INSERT INTO `marcaproducto` (`pkIdMarcaPro`, `fkIdEmpresa`, `nombreMarcaPro`, `descripcionMarcaPro`, `estadoMarcaPro`) VALUES
(1, 1, 'NOMBRE1', 'DESCRIPCION1', 1),
(2, 2, 'NOMBRE2', 'DESCRIPCION2', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `metodopago`
--

CREATE TABLE `metodopago` (
  `pkIdMetodoPago` int(10) NOT NULL,
  `descripcionMetodo` varchar(150) NOT NULL,
  `estadoMetodo` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `metodopago`
--

INSERT INTO `metodopago` (`pkIdMetodoPago`, `descripcionMetodo`, `estadoMetodo`) VALUES
(1, 'EFECTIVO', 1),
(2, 'CHEQUE', 1),
(3, 'TARJETA', 1),
(4, 'CREDITO', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `modulo`
--

CREATE TABLE `modulo` (
  `pk_id_modulo` int(10) NOT NULL,
  `nombre_modulo` varchar(30) NOT NULL,
  `descripcion_modulo` varchar(50) NOT NULL,
  `estado_modulo` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `modulo`
--

INSERT INTO `modulo` (`pk_id_modulo`, `nombre_modulo`, `descripcion_modulo`, `estado_modulo`) VALUES
(1, 'Seguridad', 'Aplicaciones de seguridad', 1),
(2, 'Consultas', 'Consultas Inteligentes', 1),
(3, 'Reporteador', 'Aplicaciones de Reporteador', 1),
(4, 'Inventarios', 'Sistema de Gestion Inventarios', 1),
(5, 'Compras', 'Sistema De Gestion Compras', 1),
(6, 'Ventas', 'Sistema de Gestion Ventas', 1),
(7, 'Cobros', 'Sistema De Gestion Cobros', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `movimientoinventariodetalle`
--

CREATE TABLE `movimientoinventariodetalle` (
  `fkmovimiento` int(10) NOT NULL,
  `fkidproducto` int(10) NOT NULL,
  `cantidad` int(50) NOT NULL,
  `estado` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `movimientoinventarioencabezado`
--

CREATE TABLE `movimientoinventarioencabezado` (
  `pkmovimientoe` int(10) NOT NULL,
  `fkempresa` int(10) NOT NULL,
  `fksucursal` int(10) DEFAULT NULL,
  `fkbodegaorigen` int(10) DEFAULT NULL,
  `fkbodegadestino` int(10) DEFAULT NULL,
  `fkrazon` int(10) NOT NULL,
  `fkproveedor` int(10) DEFAULT NULL,
  `fkcliente` int(10) DEFAULT NULL,
  `fkencargado` int(10) DEFAULT NULL,
  `fecha` varchar(15) DEFAULT NULL,
  `estado` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `municipio`
--

CREATE TABLE `municipio` (
  `pkIdMuni` int(10) NOT NULL,
  `fkIdDepar` int(10) NOT NULL,
  `nombreMuni` varchar(30) NOT NULL,
  `descripcionMuni` varchar(45) NOT NULL,
  `estadoMuni` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `municipio`
--

INSERT INTO `municipio` (`pkIdMuni`, `fkIdDepar`, `nombreMuni`, `descripcionMuni`, `estadoMuni`) VALUES
(1, 1, 'MUNICIPIO1', 'DESCRI1', 1),
(2, 1, 'MUNICIPIO2', 'DESCRI2', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pais`
--

CREATE TABLE `pais` (
  `pkIdPais` int(10) NOT NULL,
  `nombrePais` varchar(40) NOT NULL,
  `capitalPais` varchar(40) NOT NULL,
  `estadoPais` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `pais`
--

INSERT INTO `pais` (`pkIdPais`, `nombrePais`, `capitalPais`, `estadoPais`) VALUES
(1, 'GUATEMALA', 'GUATEMALA', 1),
(2, 'MEXICO ', 'DF', 1),
(3, 'SALVADOR', 'SAN SALVADOR', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedido`
--

CREATE TABLE `pedido` (
  `pkIdPedido` int(10) NOT NULL,
  `fkIdEmpresa` int(10) NOT NULL,
  `fkIdSucursal` int(10) NOT NULL,
  `fkIdCliente` int(10) NOT NULL,
  `fechaRequerida` varchar(15) NOT NULL,
  `fechaEnvio` varchar(15) NOT NULL,
  `totalPedido` float(10,2) NOT NULL,
  `estadoPedido` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `perfil`
--

CREATE TABLE `perfil` (
  `pk_id_perfil` int(10) NOT NULL,
  `nombre_perfil` varchar(50) DEFAULT NULL,
  `descripcion_perfil` varchar(100) DEFAULT NULL,
  `estado_perfil` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `perfil`
--

INSERT INTO `perfil` (`pk_id_perfil`, `nombre_perfil`, `descripcion_perfil`, `estado_perfil`) VALUES
(1, 'Admin', 'Administracion del programa', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `perfil_usuario`
--

CREATE TABLE `perfil_usuario` (
  `pk_id_perfil_usuario` int(10) NOT NULL,
  `fk_idusuario_perfil_usuario` int(10) DEFAULT NULL,
  `fk_idperfil_perfil_usuario` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `perfil_usuario`
--

INSERT INTO `perfil_usuario` (`pk_id_perfil_usuario`, `fk_idusuario_perfil_usuario`, `fk_idperfil_perfil_usuario`) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `permiso`
--

CREATE TABLE `permiso` (
  `pk_id_permiso` int(10) NOT NULL,
  `insertar_permiso` tinyint(1) DEFAULT NULL,
  `modificar_permiso` tinyint(1) DEFAULT NULL,
  `eliminar_permiso` tinyint(1) DEFAULT NULL,
  `consultar_permiso` tinyint(1) DEFAULT NULL,
  `imprimir_permiso` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `permiso`
--

INSERT INTO `permiso` (`pk_id_permiso`, `insertar_permiso`, `modificar_permiso`, `eliminar_permiso`, `consultar_permiso`, `imprimir_permiso`) VALUES
(1, 1, 1, 1, 1, 1),
(2, 1, 1, 1, 1, 1),
(3, 1, 1, 1, 0, 0),
(4, 1, 1, 1, 1, 1),
(5, 1, 1, 1, 1, 1),
(6, 1, 1, 1, 1, 1),
(7, 1, 1, 1, 1, 1),
(8, 1, 0, 1, 1, 1),
(9, 1, 1, 1, 1, 1),
(10, 1, 1, 1, 1, 1),
(11, 1, 1, 1, 1, 1),
(12, 1, 1, 1, 1, 1),
(13, 1, 1, 1, 1, 1),
(14, 1, 1, 1, 1, 1),
(15, 1, 1, 1, 1, 1),
(16, 1, 1, 1, 1, 1),
(17, 1, 1, 1, 1, 1),
(18, 1, 1, 1, 1, 1),
(19, 1, 1, 1, 1, 1),
(20, 1, 1, 1, 1, 1),
(21, 1, 1, 1, 1, 1),
(22, 1, 1, 1, 1, 1),
(23, 1, 1, 1, 1, 1),
(24, 1, 1, 1, 1, 1),
(25, 1, 1, 1, 1, 1),
(26, 1, 1, 1, 1, 1),
(27, 1, 1, 1, 1, 1),
(28, 1, 1, 1, 1, 1),
(29, 1, 1, 1, 1, 1),
(30, 1, 1, 1, 1, 1),
(31, 1, 1, 1, 1, 1),
(32, 1, 1, 1, 1, 1),
(33, 1, 1, 1, 1, 1),
(34, 1, 1, 1, 1, 1),
(35, 1, 1, 1, 1, 1),
(36, 1, 1, 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personalbodega`
--

CREATE TABLE `personalbodega` (
  `pkIdpersonal` int(10) NOT NULL,
  `fkIdEmpresa` int(10) DEFAULT NULL,
  `fkIdSucursal` int(10) DEFAULT NULL,
  `fkIdEmpleado` int(10) NOT NULL,
  `fkIdBodega` int(10) NOT NULL,
  `fkIdCargo` int(10) NOT NULL,
  `estadoPerBodega` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE `producto` (
  `pkIdProducto` int(10) NOT NULL,
  `fkProv` int(10) NOT NULL,
  `fkIdEmpresa` int(10) DEFAULT NULL,
  `fkIdLineaPro` int(10) NOT NULL,
  `fkIdMarcaPro` int(10) NOT NULL,
  `nombrePro` varchar(50) NOT NULL,
  `precioPro` double(12,2) NOT NULL,
  `descripcionPro` varchar(45) NOT NULL,
  `estadoPro` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`pkIdProducto`, `fkProv`, `fkIdEmpresa`, `fkIdLineaPro`, `fkIdMarcaPro`, `nombrePro`, `precioPro`, `descripcionPro`, `estadoPro`) VALUES
(1, 1, 1, 1, 1, 'JAMON', 85.00, 'RICO', 1),
(2, 1, 1, 1, 1, 'QUESO', 50.00, 'RICO', 1),
(3, 1, 1, 1, 1, 'PAN', 2.00, 'RICO ', 1),
(4, 1, 1, 1, 1, 'AGUA', 10.00, 'RICO', 1),
(5, 1, 1, 1, 1, 'TORTILLA', 5.00, 'RICO', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `pkIdProv` int(10) NOT NULL,
  `fkIdPais` int(10) NOT NULL,
  `direccionProv` varchar(50) NOT NULL,
  `nitProv` varchar(20) NOT NULL,
  `telProv` int(8) NOT NULL,
  `correoProv` varchar(30) NOT NULL,
  `estadoProv` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`pkIdProv`, `fkIdPais`, `direccionProv`, `nitProv`, `telProv`, `correoProv`, `estadoProv`) VALUES
(1, 1, 'JULIO', '6516513', 84621, 'hola@gmail.com', 1),
(2, 2, 'BRIAN', '7465', 3216544, 'hola2@gamil.com', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `puesto`
--

CREATE TABLE `puesto` (
  `pkIdPuesto` int(10) NOT NULL,
  `nombrePuesto` varchar(50) NOT NULL,
  `descripcionPuesto` varchar(250) NOT NULL,
  `estadoPuesto` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `puesto`
--

INSERT INTO `puesto` (`pkIdPuesto`, `nombrePuesto`, `descripcionPuesto`, `estadoPuesto`) VALUES
(1, 'GERENTE', 'BUENO', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `razonmovimiento`
--

CREATE TABLE `razonmovimiento` (
  `pkrazon` int(10) NOT NULL,
  `nombrerazon` varchar(50) DEFAULT NULL,
  `descripcionrazon` varchar(75) DEFAULT NULL,
  `estadorazon` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `razonmovimiento`
--

INSERT INTO `razonmovimiento` (`pkrazon`, `nombrerazon`, `descripcionrazon`, `estadorazon`) VALUES
(1, 'Compras', 'Compra A Proveedores', 1),
(2, 'Ventas', 'Venta a Clientes', 1),
(3, 'Devolucion Sobre Compras', 'Devolucion Sobre Compras', 1),
(4, 'Devolucion sobre Ventas', 'Devolucion sobre Ventas', 1),
(5, 'Movimiento De Inventarios', 'Movimiento De Bodega a Bodega', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reporte`
--

CREATE TABLE `reporte` (
  `pk_id_reporte` int(10) NOT NULL,
  `nombre_reporte` varchar(40) NOT NULL,
  `ruta_reporte` varchar(100) NOT NULL,
  `estado_reporte` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reporte_aplicativo`
--

CREATE TABLE `reporte_aplicativo` (
  `fk_id_reporte` int(10) NOT NULL,
  `fk_id_aplicacion` int(10) NOT NULL,
  `fk_id_modulo` int(10) NOT NULL,
  `estado_reporte_aplicativo` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reporte_modulo`
--

CREATE TABLE `reporte_modulo` (
  `fk_id_reporte` int(10) NOT NULL,
  `fk_id_modulo` int(10) NOT NULL,
  `estado_reporte_modulo` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `saldohistoricocompra`
--

CREATE TABLE `saldohistoricocompra` (
  `pksaldohistoricocompra` int(10) NOT NULL,
  `fechamovimientocompra` varchar(15) NOT NULL,
  `fkNoDocumentoEnca` int(10) NOT NULL,
  `fkmetodopago` int(10) DEFAULT NULL,
  `saldoanterior` double(10,2) DEFAULT NULL,
  `abono` double(10,2) DEFAULT NULL,
  `notas` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `saldoscomrpa`
--

CREATE TABLE `saldoscomrpa` (
  `pksaldocompra` int(10) NOT NULL,
  `fkNoDocumentoEnca` int(10) NOT NULL,
  `saldo` double(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursal`
--

CREATE TABLE `sucursal` (
  `pkIdSucursal` int(10) NOT NULL,
  `fkIdEmpresa` int(10) DEFAULT NULL,
  `nombreSucursal` varchar(50) DEFAULT NULL,
  `fkIdPais` int(10) DEFAULT NULL,
  `direccionDeLugar` varchar(50) DEFAULT NULL,
  `fkIdDepar` int(10) DEFAULT NULL,
  `fkIdMuni` int(10) DEFAULT NULL,
  `estadoSucursal` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sucursal`
--

INSERT INTO `sucursal` (`pkIdSucursal`, `fkIdEmpresa`, `nombreSucursal`, `fkIdPais`, `direccionDeLugar`, `fkIdDepar`, `fkIdMuni`, `estadoSucursal`) VALUES
(1, 1, 'SUCURSAL1', 1, 'DIRECCION2', 1, 1, 1),
(2, 1, 'SUCURSAL2', 1, 'DIRECCION2', 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipocompra`
--

CREATE TABLE `tipocompra` (
  `pktipocompra` int(10) NOT NULL,
  `nombretipocompra` varchar(50) DEFAULT NULL,
  `descripciontipocompra` varchar(75) DEFAULT NULL,
  `estado` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tipocompra`
--

INSERT INTO `tipocompra` (`pktipocompra`, `nombretipocompra`, `descripciontipocompra`, `estado`) VALUES
(1, 'SOLICITUD', 'NECESITA APROBACION ', 1),
(2, 'ORDEN ', 'SOLICITUD APROBADA', 1),
(3, 'PROCESO', 'ENVIADA A PROVEEDOR', 1),
(4, 'EN CURSO', 'DESPACHADA POR PROVEEDOR', 1),
(5, 'RECIBIDA', 'ORDEN INGRESADA', 1),
(6, 'SOLICITUD RECHAZADA', 'NO ACEPTADA', 1),
(7, 'ORDEN RECHAZADA', 'RECHAZADA POR INCONFORMIDAD', 1),
(8, 'DEVOLUCION', 'REGRESO DE ORDEN A PROVEEDOR', 1),
(9, 'ALMACENADA', 'ORDEN ALMACENADA EN BODEGA', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventadetalle`
--

CREATE TABLE `ventadetalle` (
  `idEncabezadoVenta` int(10) NOT NULL,
  `idProducto` int(10) NOT NULL,
  `precioUnitario` int(10) DEFAULT NULL,
  `cantidad` int(10) DEFAULT NULL,
  `subtotal` float(12,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ventadetalle`
--

INSERT INTO `ventadetalle` (`idEncabezadoVenta`, `idProducto`, `precioUnitario`, `cantidad`, `subtotal`) VALUES
(1, 1, 85, 10, 850.00),
(1, 2, 50, 10, 500.00),
(2, 1, 85, 10, 850.00),
(2, 2, 50, 100, 5000.00),
(2, 3, 2, 500, 1000.00),
(3, 1, 85, 10, 850.00),
(3, 2, 50, 10, 500.00),
(3, 3, 2, 50, 100.00),
(3, 4, 10, 100, 1000.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventaencabezado`
--

CREATE TABLE `ventaencabezado` (
  `idVentaEncabezado` int(10) NOT NULL,
  `idCliente` int(10) NOT NULL,
  `fechaRequerida` varchar(15) NOT NULL,
  `totalVenta` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ventaencabezado`
--

INSERT INTO `ventaencabezado` (`idVentaEncabezado`, `idCliente`, `fechaRequerida`, `totalVenta`) VALUES
(1, 1, '2021-06-02', 1350.00),
(2, 1, '2021-06-02', 6850.00),
(3, 1, '2021-06-02', 2450.00);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apartado`
--
ALTER TABLE `apartado`
  ADD PRIMARY KEY (`pkIdApartado`),
  ADD KEY `fk_apartado_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_apartado_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_apartado_cliente` (`fkIdCliente`);

--
-- Indices de la tabla `apartadodetalle`
--
ALTER TABLE `apartadodetalle`
  ADD PRIMARY KEY (`pkApartadoDetalle`),
  ADD KEY `fk_adetalle_apartado` (`fkIdApartado`),
  ADD KEY `fk_adetalle_producto` (`fkIdProducto`),
  ADD KEY `fk_adetalle_bodega` (`fkIdBodega`);

--
-- Indices de la tabla `aplicacion`
--
ALTER TABLE `aplicacion`
  ADD PRIMARY KEY (`pk_id_aplicacion`),
  ADD KEY `pk_id_aplicacion` (`pk_id_aplicacion`),
  ADD KEY `fk_aplicacion_modulo` (`fk_id_modulo`);

--
-- Indices de la tabla `aplicacion_perfil`
--
ALTER TABLE `aplicacion_perfil`
  ADD PRIMARY KEY (`pk_id_aplicacion_perfil`),
  ADD KEY `fk_aplicacionperfil_aplicacion` (`fk_idaplicacion_aplicacion_perfil`),
  ADD KEY `fk_aplicacionperfil_perfil` (`fk_idperfil_aplicacion_perfil`),
  ADD KEY `fk_aplicacionperfil_permiso` (`fk_idpermiso_aplicacion_perfil`);

--
-- Indices de la tabla `aplicacion_usuario`
--
ALTER TABLE `aplicacion_usuario`
  ADD PRIMARY KEY (`pk_id_aplicacion_usuario`),
  ADD KEY `fk_aplicacionusuario_login` (`fk_idlogin_aplicacion_usuario`),
  ADD KEY `fk_aplicacionusuario_aplicacion` (`fk_idaplicacion_aplicacion_usuario`),
  ADD KEY `fk_aplicacionusuario_permiso` (`fk_idpermiso_aplicacion_usuario`);

--
-- Indices de la tabla `bitacora`
--
ALTER TABLE `bitacora`
  ADD PRIMARY KEY (`pk_id_bitacora`),
  ADD KEY `fk_login_bitacora` (`fk_idusuario_bitacora`),
  ADD KEY `fk_aplicacion_bitacora` (`fk_idaplicacion_bitacora`);

--
-- Indices de la tabla `bodega`
--
ALTER TABLE `bodega`
  ADD PRIMARY KEY (`pkIdBodega`),
  ADD KEY `fk_bodega_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_bodega_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_bodega_departamento` (`fkIdDepar`),
  ADD KEY `fk_bodega_municipio` (`fkIdMuni`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`pkIdCliente`);

--
-- Indices de la tabla `cobro`
--
ALTER TABLE `cobro`
  ADD PRIMARY KEY (`pkNoRegistroCobro`),
  ADD KEY `fk_cobro_cuentas` (`fkIdRegistroCuenta`),
  ADD KEY `fk_cobro_empleado` (`fkIdEmpleado`),
  ADD KEY `fk_cobro_metodopago` (`fkIdMetodoPago`);

--
-- Indices de la tabla `compradetalle`
--
ALTER TABLE `compradetalle`
  ADD PRIMARY KEY (`fkNoDocumentoEnca`,`fkIdPro`),
  ADD KEY `fk_compra_producto` (`fkIdPro`);

--
-- Indices de la tabla `compraencabezado`
--
ALTER TABLE `compraencabezado`
  ADD PRIMARY KEY (`pkNoDocumentoEnca`),
  ADD KEY `fk_compra_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_compra_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_compra_empleado` (`fkIdEmpleado`),
  ADD KEY `fk_compra_proveedor` (`fkIdProv`),
  ADD KEY `fk_compra_tipocompra` (`fktipocompra`),
  ADD KEY `fk_compra_metodopago` (`fkmetodoPago`),
  ADD KEY `fk_compra_bodega` (`fkIdBodegadestino`);

--
-- Indices de la tabla `cotizadetalle`
--
ALTER TABLE `cotizadetalle`
  ADD PRIMARY KEY (`pkIdCotizaDetalle`),
  ADD KEY `fk_cotiza_encabezado` (`fkDocumentoCotizaEnca`),
  ADD KEY `fk_cotiza_producto` (`fkIdPro`);

--
-- Indices de la tabla `cotizaencabezado`
--
ALTER TABLE `cotizaencabezado`
  ADD PRIMARY KEY (`pkDocumentoCotizaEnca`),
  ADD KEY `fk_cotiza_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_cotiza_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_cotiza_empleado` (`fkIdEmpleado`),
  ADD KEY `fk_cotiza_cliente` (`fkIdCliente`);

--
-- Indices de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD PRIMARY KEY (`pkIdRegistroCuentas`),
  ADD KEY `fk_cuentas_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_cuentas_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_cuentas_empleado` (`fkIdEmpleado`);

--
-- Indices de la tabla `departamento`
--
ALTER TABLE `departamento`
  ADD PRIMARY KEY (`pkIdDepar`);

--
-- Indices de la tabla `detallepedido`
--
ALTER TABLE `detallepedido`
  ADD PRIMARY KEY (`pkIdDetallePedido`),
  ADD KEY `fk_detalle_pedido` (`fkIdPedido`),
  ADD KEY `fk_detalle_producto` (`fkIdProducto`);

--
-- Indices de la tabla `detalle_bitacora`
--
ALTER TABLE `detalle_bitacora`
  ADD PRIMARY KEY (`pk_id_detalle_bitacora`),
  ADD KEY `fk_bitacora_detallebitacora` (`fk_idbitacora_detalle_bitacora`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`pkIdEmpleado`),
  ADD KEY `idManager` (`idManager`),
  ADD KEY `fk_empleado_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_empleado_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_empleado_puesto` (`fkIdPuesto`);

--
-- Indices de la tabla `empresa`
--
ALTER TABLE `empresa`
  ADD PRIMARY KEY (`pkIdEmpresa`),
  ADD KEY `fk_empresa_pais` (`fkIdPais`),
  ADD KEY `fk_empresa_departamento` (`fkIdDepar`),
  ADD KEY `fk_empresa_municipio` (`fkIdMuni`);

--
-- Indices de la tabla `existencia`
--
ALTER TABLE `existencia`
  ADD PRIMARY KEY (`pkIdExis`,`fkIdEmpresa`,`fkIdBodega`,`fkIdPro`),
  ADD KEY `fk_existencia_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_existencia_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_existencia_producto` (`fkIdPro`),
  ADD KEY `fk_existencia_bodega` (`fkIdBodega`);

--
-- Indices de la tabla `lineaproducto`
--
ALTER TABLE `lineaproducto`
  ADD PRIMARY KEY (`pkIdLineaPro`),
  ADD KEY `fk_linea_empresa` (`fkIdEmpresa`);

--
-- Indices de la tabla `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`pk_id_login`);

--
-- Indices de la tabla `marcaproducto`
--
ALTER TABLE `marcaproducto`
  ADD PRIMARY KEY (`pkIdMarcaPro`),
  ADD KEY `fk_marca_empresa` (`fkIdEmpresa`);

--
-- Indices de la tabla `metodopago`
--
ALTER TABLE `metodopago`
  ADD PRIMARY KEY (`pkIdMetodoPago`);

--
-- Indices de la tabla `modulo`
--
ALTER TABLE `modulo`
  ADD PRIMARY KEY (`pk_id_modulo`),
  ADD KEY `pk_id_modulo` (`pk_id_modulo`);

--
-- Indices de la tabla `movimientoinventariodetalle`
--
ALTER TABLE `movimientoinventariodetalle`
  ADD PRIMARY KEY (`fkmovimiento`,`fkidproducto`),
  ADD KEY `fk_detalleproductoo` (`fkidproducto`);

--
-- Indices de la tabla `movimientoinventarioencabezado`
--
ALTER TABLE `movimientoinventarioencabezado`
  ADD PRIMARY KEY (`pkmovimientoe`),
  ADD KEY `fk_bodega_empresaa` (`fkempresa`),
  ADD KEY `fk_bodega_razonn` (`fkrazon`),
  ADD KEY `fk_bodega_origenn` (`fkbodegaorigen`),
  ADD KEY `fk_bodega_destinoo` (`fkbodegadestino`),
  ADD KEY `fk_bodega_encargadoo` (`fkencargado`),
  ADD KEY `fk_bodega_sucursall` (`fksucursal`);

--
-- Indices de la tabla `municipio`
--
ALTER TABLE `municipio`
  ADD PRIMARY KEY (`pkIdMuni`),
  ADD KEY `fk_municipio_departamento` (`fkIdDepar`);

--
-- Indices de la tabla `pais`
--
ALTER TABLE `pais`
  ADD PRIMARY KEY (`pkIdPais`);

--
-- Indices de la tabla `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`pkIdPedido`),
  ADD KEY `fk_pedido_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_pedido_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_pedido_cliente` (`fkIdCliente`);

--
-- Indices de la tabla `perfil`
--
ALTER TABLE `perfil`
  ADD PRIMARY KEY (`pk_id_perfil`);

--
-- Indices de la tabla `perfil_usuario`
--
ALTER TABLE `perfil_usuario`
  ADD PRIMARY KEY (`pk_id_perfil_usuario`),
  ADD KEY `fk_perfil_usuario_login` (`fk_idusuario_perfil_usuario`),
  ADD KEY `fk_perfil_usuario_perfil` (`fk_idperfil_perfil_usuario`);

--
-- Indices de la tabla `permiso`
--
ALTER TABLE `permiso`
  ADD PRIMARY KEY (`pk_id_permiso`);

--
-- Indices de la tabla `personalbodega`
--
ALTER TABLE `personalbodega`
  ADD PRIMARY KEY (`pkIdpersonal`),
  ADD KEY `fk_personal_empleado` (`fkIdEmpleado`),
  ADD KEY `fk_personal_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_personal_sucursal` (`fkIdSucursal`),
  ADD KEY `fk_personal_bodega` (`fkIdBodega`),
  ADD KEY `fk_personal_cargo` (`fkIdCargo`);

--
-- Indices de la tabla `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`pkIdProducto`),
  ADD KEY `fk_producto_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_producto_proveedor` (`fkProv`),
  ADD KEY `fk_producto_lineaProducto` (`fkIdLineaPro`),
  ADD KEY `fk_producto_categoriaProducto` (`fkIdMarcaPro`);

--
-- Indices de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD PRIMARY KEY (`pkIdProv`),
  ADD KEY `fk_proveedor_pais` (`fkIdPais`);

--
-- Indices de la tabla `puesto`
--
ALTER TABLE `puesto`
  ADD PRIMARY KEY (`pkIdPuesto`);

--
-- Indices de la tabla `razonmovimiento`
--
ALTER TABLE `razonmovimiento`
  ADD PRIMARY KEY (`pkrazon`);

--
-- Indices de la tabla `reporte`
--
ALTER TABLE `reporte`
  ADD PRIMARY KEY (`pk_id_reporte`),
  ADD KEY `pk_id_reporte` (`pk_id_reporte`);

--
-- Indices de la tabla `reporte_aplicativo`
--
ALTER TABLE `reporte_aplicativo`
  ADD PRIMARY KEY (`fk_id_reporte`,`fk_id_aplicacion`,`fk_id_modulo`),
  ADD KEY `fk_id_reporte` (`fk_id_reporte`,`fk_id_aplicacion`,`fk_id_modulo`),
  ADD KEY `fk_reporte_aplicativo_modulo` (`fk_id_modulo`),
  ADD KEY `fk_report_aplicativo` (`fk_id_aplicacion`);

--
-- Indices de la tabla `reporte_modulo`
--
ALTER TABLE `reporte_modulo`
  ADD PRIMARY KEY (`fk_id_reporte`,`fk_id_modulo`),
  ADD KEY `fk_id_reporte` (`fk_id_reporte`,`fk_id_modulo`),
  ADD KEY `fk_reporte_de_modulo_reportes` (`fk_id_modulo`);

--
-- Indices de la tabla `saldohistoricocompra`
--
ALTER TABLE `saldohistoricocompra`
  ADD PRIMARY KEY (`pksaldohistoricocompra`),
  ADD KEY `fk_DocumentoEnca` (`fkNoDocumentoEnca`),
  ADD KEY `fk_metodopago` (`fkmetodopago`);

--
-- Indices de la tabla `saldoscomrpa`
--
ALTER TABLE `saldoscomrpa`
  ADD PRIMARY KEY (`pksaldocompra`);

--
-- Indices de la tabla `sucursal`
--
ALTER TABLE `sucursal`
  ADD PRIMARY KEY (`pkIdSucursal`),
  ADD KEY `fk_sucursal_empresa` (`fkIdEmpresa`),
  ADD KEY `fk_sucursal_pais` (`fkIdPais`),
  ADD KEY `fk_sucursal_departamento` (`fkIdDepar`),
  ADD KEY `fk_sucursal_municipio` (`fkIdMuni`);

--
-- Indices de la tabla `tipocompra`
--
ALTER TABLE `tipocompra`
  ADD PRIMARY KEY (`pktipocompra`);

--
-- Indices de la tabla `ventadetalle`
--
ALTER TABLE `ventadetalle`
  ADD PRIMARY KEY (`idEncabezadoVenta`,`idProducto`),
  ADD KEY `idProductoDetalle` (`idProducto`);

--
-- Indices de la tabla `ventaencabezado`
--
ALTER TABLE `ventaencabezado`
  ADD PRIMARY KEY (`idVentaEncabezado`),
  ADD KEY `fk_venta_cliente` (`idCliente`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apartado`
--
ALTER TABLE `apartado`
  MODIFY `pkIdApartado` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `apartadodetalle`
--
ALTER TABLE `apartadodetalle`
  MODIFY `pkApartadoDetalle` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `aplicacion`
--
ALTER TABLE `aplicacion`
  MODIFY `pk_id_aplicacion` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=313;

--
-- AUTO_INCREMENT de la tabla `aplicacion_perfil`
--
ALTER TABLE `aplicacion_perfil`
  MODIFY `pk_id_aplicacion_perfil` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `aplicacion_usuario`
--
ALTER TABLE `aplicacion_usuario`
  MODIFY `pk_id_aplicacion_usuario` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `bitacora`
--
ALTER TABLE `bitacora`
  MODIFY `pk_id_bitacora` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT de la tabla `bodega`
--
ALTER TABLE `bodega`
  MODIFY `pkIdBodega` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `pkIdCliente` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `cobro`
--
ALTER TABLE `cobro`
  MODIFY `pkNoRegistroCobro` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `compraencabezado`
--
ALTER TABLE `compraencabezado`
  MODIFY `pkNoDocumentoEnca` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `cotizadetalle`
--
ALTER TABLE `cotizadetalle`
  MODIFY `pkIdCotizaDetalle` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `cotizaencabezado`
--
ALTER TABLE `cotizaencabezado`
  MODIFY `pkDocumentoCotizaEnca` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  MODIFY `pkIdRegistroCuentas` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `departamento`
--
ALTER TABLE `departamento`
  MODIFY `pkIdDepar` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `detallepedido`
--
ALTER TABLE `detallepedido`
  MODIFY `pkIdDetallePedido` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalle_bitacora`
--
ALTER TABLE `detalle_bitacora`
  MODIFY `pk_id_detalle_bitacora` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `pkIdEmpleado` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `empresa`
--
ALTER TABLE `empresa`
  MODIFY `pkIdEmpresa` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `existencia`
--
ALTER TABLE `existencia`
  MODIFY `pkIdExis` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `lineaproducto`
--
ALTER TABLE `lineaproducto`
  MODIFY `pkIdLineaPro` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `login`
--
ALTER TABLE `login`
  MODIFY `pk_id_login` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `marcaproducto`
--
ALTER TABLE `marcaproducto`
  MODIFY `pkIdMarcaPro` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `metodopago`
--
ALTER TABLE `metodopago`
  MODIFY `pkIdMetodoPago` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `modulo`
--
ALTER TABLE `modulo`
  MODIFY `pk_id_modulo` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `movimientoinventarioencabezado`
--
ALTER TABLE `movimientoinventarioencabezado`
  MODIFY `pkmovimientoe` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `municipio`
--
ALTER TABLE `municipio`
  MODIFY `pkIdMuni` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `pais`
--
ALTER TABLE `pais`
  MODIFY `pkIdPais` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `pedido`
--
ALTER TABLE `pedido`
  MODIFY `pkIdPedido` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `perfil`
--
ALTER TABLE `perfil`
  MODIFY `pk_id_perfil` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `perfil_usuario`
--
ALTER TABLE `perfil_usuario`
  MODIFY `pk_id_perfil_usuario` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `permiso`
--
ALTER TABLE `permiso`
  MODIFY `pk_id_permiso` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT de la tabla `personalbodega`
--
ALTER TABLE `personalbodega`
  MODIFY `pkIdpersonal` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `pkIdProducto` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `pkIdProv` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `puesto`
--
ALTER TABLE `puesto`
  MODIFY `pkIdPuesto` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `razonmovimiento`
--
ALTER TABLE `razonmovimiento`
  MODIFY `pkrazon` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `reporte`
--
ALTER TABLE `reporte`
  MODIFY `pk_id_reporte` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `saldohistoricocompra`
--
ALTER TABLE `saldohistoricocompra`
  MODIFY `pksaldohistoricocompra` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `saldoscomrpa`
--
ALTER TABLE `saldoscomrpa`
  MODIFY `pksaldocompra` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `sucursal`
--
ALTER TABLE `sucursal`
  MODIFY `pkIdSucursal` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `tipocompra`
--
ALTER TABLE `tipocompra`
  MODIFY `pktipocompra` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `ventaencabezado`
--
ALTER TABLE `ventaencabezado`
  MODIFY `idVentaEncabezado` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apartado`
--
ALTER TABLE `apartado`
  ADD CONSTRAINT `fk_apartado_cliente` FOREIGN KEY (`fkIdCliente`) REFERENCES `cliente` (`pkIdCliente`),
  ADD CONSTRAINT `fk_apartado_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_apartado_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `apartadodetalle`
--
ALTER TABLE `apartadodetalle`
  ADD CONSTRAINT `fk_adetalle_apartado` FOREIGN KEY (`fkIdApartado`) REFERENCES `apartado` (`pkIdApartado`),
  ADD CONSTRAINT `fk_adetalle_bodega` FOREIGN KEY (`fkIdBodega`) REFERENCES `bodega` (`pkIdBodega`),
  ADD CONSTRAINT `fk_adetalle_producto` FOREIGN KEY (`fkIdProducto`) REFERENCES `producto` (`pkIdProducto`);

--
-- Filtros para la tabla `aplicacion`
--
ALTER TABLE `aplicacion`
  ADD CONSTRAINT `fk_aplicacion_modulo` FOREIGN KEY (`fk_id_modulo`) REFERENCES `modulo` (`pk_id_modulo`);

--
-- Filtros para la tabla `aplicacion_perfil`
--
ALTER TABLE `aplicacion_perfil`
  ADD CONSTRAINT `fk_aplicacionperfil_aplicacion` FOREIGN KEY (`fk_idaplicacion_aplicacion_perfil`) REFERENCES `aplicacion` (`pk_id_aplicacion`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_aplicacionperfil_perfil` FOREIGN KEY (`fk_idperfil_aplicacion_perfil`) REFERENCES `perfil` (`pk_id_perfil`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_aplicacionperfil_permiso` FOREIGN KEY (`fk_idpermiso_aplicacion_perfil`) REFERENCES `permiso` (`pk_id_permiso`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `aplicacion_usuario`
--
ALTER TABLE `aplicacion_usuario`
  ADD CONSTRAINT `fk_aplicacionusuario_aplicacion` FOREIGN KEY (`fk_idaplicacion_aplicacion_usuario`) REFERENCES `aplicacion` (`pk_id_aplicacion`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_aplicacionusuario_login` FOREIGN KEY (`fk_idlogin_aplicacion_usuario`) REFERENCES `login` (`pk_id_login`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_aplicacionusuario_permiso` FOREIGN KEY (`fk_idpermiso_aplicacion_usuario`) REFERENCES `permiso` (`pk_id_permiso`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `bitacora`
--
ALTER TABLE `bitacora`
  ADD CONSTRAINT `fk_aplicacion_bitacora` FOREIGN KEY (`fk_idaplicacion_bitacora`) REFERENCES `aplicacion` (`pk_id_aplicacion`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_login_bitacora` FOREIGN KEY (`fk_idusuario_bitacora`) REFERENCES `login` (`pk_id_login`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `bodega`
--
ALTER TABLE `bodega`
  ADD CONSTRAINT `fk_bodega_departamento` FOREIGN KEY (`fkIdDepar`) REFERENCES `departamento` (`pkIdDepar`),
  ADD CONSTRAINT `fk_bodega_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_bodega_municipio` FOREIGN KEY (`fkIdMuni`) REFERENCES `municipio` (`pkIdMuni`),
  ADD CONSTRAINT `fk_bodega_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `cobro`
--
ALTER TABLE `cobro`
  ADD CONSTRAINT `fk_cobro_cuentas` FOREIGN KEY (`fkIdRegistroCuenta`) REFERENCES `cuentas` (`pkIdRegistroCuentas`),
  ADD CONSTRAINT `fk_cobro_empleado` FOREIGN KEY (`fkIdEmpleado`) REFERENCES `empleado` (`pkIdEmpleado`),
  ADD CONSTRAINT `fk_cobro_metodopago` FOREIGN KEY (`fkIdMetodoPago`) REFERENCES `metodopago` (`pkIdMetodoPago`);

--
-- Filtros para la tabla `compradetalle`
--
ALTER TABLE `compradetalle`
  ADD CONSTRAINT `fk_compra_detalle_encabezado` FOREIGN KEY (`fkNoDocumentoEnca`) REFERENCES `compraencabezado` (`pkNoDocumentoEnca`),
  ADD CONSTRAINT `fk_compra_producto` FOREIGN KEY (`fkIdPro`) REFERENCES `producto` (`pkIdProducto`);

--
-- Filtros para la tabla `compraencabezado`
--
ALTER TABLE `compraencabezado`
  ADD CONSTRAINT `fk_compra_bodega` FOREIGN KEY (`fkIdBodegadestino`) REFERENCES `bodega` (`pkIdBodega`),
  ADD CONSTRAINT `fk_compra_empleado` FOREIGN KEY (`fkIdEmpleado`) REFERENCES `empleado` (`pkIdEmpleado`),
  ADD CONSTRAINT `fk_compra_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_compra_metodopago` FOREIGN KEY (`fkmetodoPago`) REFERENCES `metodopago` (`pkIdMetodoPago`),
  ADD CONSTRAINT `fk_compra_proveedor` FOREIGN KEY (`fkIdProv`) REFERENCES `proveedor` (`pkIdProv`),
  ADD CONSTRAINT `fk_compra_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`),
  ADD CONSTRAINT `fk_compra_tipocompra` FOREIGN KEY (`fktipocompra`) REFERENCES `tipocompra` (`pktipocompra`);

--
-- Filtros para la tabla `cotizadetalle`
--
ALTER TABLE `cotizadetalle`
  ADD CONSTRAINT `fk_cotiza_encabezado` FOREIGN KEY (`fkDocumentoCotizaEnca`) REFERENCES `cotizaencabezado` (`pkDocumentoCotizaEnca`),
  ADD CONSTRAINT `fk_cotiza_producto` FOREIGN KEY (`fkIdPro`) REFERENCES `producto` (`pkIdProducto`);

--
-- Filtros para la tabla `cotizaencabezado`
--
ALTER TABLE `cotizaencabezado`
  ADD CONSTRAINT `fk_cotiza_cliente` FOREIGN KEY (`fkIdCliente`) REFERENCES `cliente` (`pkIdCliente`),
  ADD CONSTRAINT `fk_cotiza_empleado` FOREIGN KEY (`fkIdEmpleado`) REFERENCES `empleado` (`pkIdEmpleado`),
  ADD CONSTRAINT `fk_cotiza_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_cotiza_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD CONSTRAINT `fk_cuentas_empleado` FOREIGN KEY (`fkIdEmpleado`) REFERENCES `empleado` (`pkIdEmpleado`),
  ADD CONSTRAINT `fk_cuentas_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_cuentas_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `detallepedido`
--
ALTER TABLE `detallepedido`
  ADD CONSTRAINT `fk_detalle_pedido` FOREIGN KEY (`fkIdPedido`) REFERENCES `pedido` (`pkIdPedido`),
  ADD CONSTRAINT `fk_detalle_producto` FOREIGN KEY (`fkIdProducto`) REFERENCES `producto` (`pkIdProducto`);

--
-- Filtros para la tabla `detalle_bitacora`
--
ALTER TABLE `detalle_bitacora`
  ADD CONSTRAINT `fk_bitacora_detallebitacora` FOREIGN KEY (`fk_idbitacora_detalle_bitacora`) REFERENCES `bitacora` (`pk_id_bitacora`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`idManager`) REFERENCES `empleado` (`pkIdEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_empleado_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_empleado_puesto` FOREIGN KEY (`fkIdPuesto`) REFERENCES `puesto` (`pkIdPuesto`),
  ADD CONSTRAINT `fk_empleado_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `empresa`
--
ALTER TABLE `empresa`
  ADD CONSTRAINT `fk_empresa_departamento` FOREIGN KEY (`fkIdDepar`) REFERENCES `departamento` (`pkIdDepar`),
  ADD CONSTRAINT `fk_empresa_municipio` FOREIGN KEY (`fkIdMuni`) REFERENCES `municipio` (`pkIdMuni`),
  ADD CONSTRAINT `fk_empresa_pais` FOREIGN KEY (`fkIdPais`) REFERENCES `pais` (`pkIdPais`);

--
-- Filtros para la tabla `existencia`
--
ALTER TABLE `existencia`
  ADD CONSTRAINT `fk_existencia_bodega` FOREIGN KEY (`fkIdBodega`) REFERENCES `bodega` (`pkIdBodega`),
  ADD CONSTRAINT `fk_existencia_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_existencia_producto` FOREIGN KEY (`fkIdPro`) REFERENCES `producto` (`pkIdProducto`),
  ADD CONSTRAINT `fk_existencia_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `lineaproducto`
--
ALTER TABLE `lineaproducto`
  ADD CONSTRAINT `fk_linea_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`);

--
-- Filtros para la tabla `marcaproducto`
--
ALTER TABLE `marcaproducto`
  ADD CONSTRAINT `fk_marca_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`);

--
-- Filtros para la tabla `movimientoinventariodetalle`
--
ALTER TABLE `movimientoinventariodetalle`
  ADD CONSTRAINT `fk_detallemovimiento` FOREIGN KEY (`fkmovimiento`) REFERENCES `movimientoinventarioencabezado` (`pkmovimientoe`),
  ADD CONSTRAINT `fk_detalleproductoo` FOREIGN KEY (`fkidproducto`) REFERENCES `producto` (`pkIdProducto`);

--
-- Filtros para la tabla `movimientoinventarioencabezado`
--
ALTER TABLE `movimientoinventarioencabezado`
  ADD CONSTRAINT `fk_bodega_destinoo` FOREIGN KEY (`fkbodegadestino`) REFERENCES `bodega` (`pkIdBodega`),
  ADD CONSTRAINT `fk_bodega_empresaa` FOREIGN KEY (`fkempresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_bodega_encargadoo` FOREIGN KEY (`fkencargado`) REFERENCES `login` (`pk_id_login`),
  ADD CONSTRAINT `fk_bodega_origenn` FOREIGN KEY (`fkbodegaorigen`) REFERENCES `bodega` (`pkIdBodega`),
  ADD CONSTRAINT `fk_bodega_razonn` FOREIGN KEY (`fkrazon`) REFERENCES `razonmovimiento` (`pkrazon`),
  ADD CONSTRAINT `fk_bodega_sucursall` FOREIGN KEY (`fksucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `municipio`
--
ALTER TABLE `municipio`
  ADD CONSTRAINT `fk_municipio_departamento` FOREIGN KEY (`fkIdDepar`) REFERENCES `departamento` (`pkIdDepar`);

--
-- Filtros para la tabla `pedido`
--
ALTER TABLE `pedido`
  ADD CONSTRAINT `fk_pedido_cliente` FOREIGN KEY (`fkIdCliente`) REFERENCES `cliente` (`pkIdCliente`),
  ADD CONSTRAINT `fk_pedido_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_pedido_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `perfil_usuario`
--
ALTER TABLE `perfil_usuario`
  ADD CONSTRAINT `fk_perfil_usuario_login` FOREIGN KEY (`fk_idusuario_perfil_usuario`) REFERENCES `login` (`pk_id_login`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_perfil_usuario_perfil` FOREIGN KEY (`fk_idperfil_perfil_usuario`) REFERENCES `perfil` (`pk_id_perfil`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `personalbodega`
--
ALTER TABLE `personalbodega`
  ADD CONSTRAINT `fk_personal_bodega` FOREIGN KEY (`fkIdBodega`) REFERENCES `bodega` (`pkIdBodega`),
  ADD CONSTRAINT `fk_personal_cargo` FOREIGN KEY (`fkIdCargo`) REFERENCES `puesto` (`pkIdPuesto`),
  ADD CONSTRAINT `fk_personal_empleado` FOREIGN KEY (`fkIdEmpleado`) REFERENCES `empleado` (`pkIdEmpleado`),
  ADD CONSTRAINT `fk_personal_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_personal_sucursal` FOREIGN KEY (`fkIdSucursal`) REFERENCES `sucursal` (`pkIdSucursal`);

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `fk_producto_categoriaProducto` FOREIGN KEY (`fkIdMarcaPro`) REFERENCES `marcaproducto` (`pkIdMarcaPro`),
  ADD CONSTRAINT `fk_producto_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_producto_lineaProducto` FOREIGN KEY (`fkIdLineaPro`) REFERENCES `lineaproducto` (`pkIdLineaPro`),
  ADD CONSTRAINT `fk_producto_proveedor` FOREIGN KEY (`fkProv`) REFERENCES `proveedor` (`pkIdProv`);

--
-- Filtros para la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD CONSTRAINT `fk_proveedor_pais` FOREIGN KEY (`fkIdPais`) REFERENCES `pais` (`pkIdPais`);

--
-- Filtros para la tabla `reporte_aplicativo`
--
ALTER TABLE `reporte_aplicativo`
  ADD CONSTRAINT `fk_report_aplicativo` FOREIGN KEY (`fk_id_aplicacion`) REFERENCES `aplicacion` (`pk_id_aplicacion`),
  ADD CONSTRAINT `fk_reporte_aplicativo_modulo` FOREIGN KEY (`fk_id_modulo`) REFERENCES `modulo` (`pk_id_modulo`),
  ADD CONSTRAINT `fk_reporte_aplicativo_reporte` FOREIGN KEY (`fk_id_reporte`) REFERENCES `reporte` (`pk_id_reporte`);

--
-- Filtros para la tabla `reporte_modulo`
--
ALTER TABLE `reporte_modulo`
  ADD CONSTRAINT `fk_reporte_de_modulo` FOREIGN KEY (`fk_id_reporte`) REFERENCES `reporte` (`pk_id_reporte`),
  ADD CONSTRAINT `fk_reporte_de_modulo_reportes` FOREIGN KEY (`fk_id_modulo`) REFERENCES `modulo` (`pk_id_modulo`);

--
-- Filtros para la tabla `saldohistoricocompra`
--
ALTER TABLE `saldohistoricocompra`
  ADD CONSTRAINT `fk_DocumentoEnca` FOREIGN KEY (`fkNoDocumentoEnca`) REFERENCES `compraencabezado` (`pkNoDocumentoEnca`),
  ADD CONSTRAINT `fk_metodopago` FOREIGN KEY (`fkmetodopago`) REFERENCES `metodopago` (`pkIdMetodoPago`);

--
-- Filtros para la tabla `sucursal`
--
ALTER TABLE `sucursal`
  ADD CONSTRAINT `fk_sucursal_departamento` FOREIGN KEY (`fkIdDepar`) REFERENCES `departamento` (`pkIdDepar`),
  ADD CONSTRAINT `fk_sucursal_empresa` FOREIGN KEY (`fkIdEmpresa`) REFERENCES `empresa` (`pkIdEmpresa`),
  ADD CONSTRAINT `fk_sucursal_municipio` FOREIGN KEY (`fkIdMuni`) REFERENCES `municipio` (`pkIdMuni`),
  ADD CONSTRAINT `fk_sucursal_pais` FOREIGN KEY (`fkIdPais`) REFERENCES `pais` (`pkIdPais`);

--
-- Filtros para la tabla `ventadetalle`
--
ALTER TABLE `ventadetalle`
  ADD CONSTRAINT `idEncabezadoDetalle` FOREIGN KEY (`idEncabezadoVenta`) REFERENCES `ventaencabezado` (`idVentaEncabezado`),
  ADD CONSTRAINT `idProductoDetalle` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`pkIdProducto`);

--
-- Filtros para la tabla `ventaencabezado`
--
ALTER TABLE `ventaencabezado`
  ADD CONSTRAINT `fk_venta_cliente` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`pkIdCliente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
