CREATE DATABASE SITIO_1;
USE SITIO_1

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [Informacion_Vendedor].[Vendedor]

CREATE TABLE [VENDEDOR1]
(
 [IDVENDEDOR] BIGINT NOT NULL ,
 [NOMBRE]     VARCHAR(50) NOT NULL ,
 [CELULAR]    VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Vendedor] PRIMARY KEY ([IDVENDEDOR])
);
GO
-- CONVERTIR VENDEDOR A USUARIO
CREATE TABLE [USUARIO1](
 [IDUSUARIO]	bigint IDENTITY (1, 1) NOT NULL ,
 [NOMBRE]       varchar(50) NOT NULL ,
 [TIPO_USUARIO] varchar(50) NOT NULL ,
 [CONTRASEÑA]   varchar(50) NOT NULL ,
 [CELULAR]   varchar(50) NOT NULL ,
);

-- ************************************** [Informacion_Cliente].[Cliente]

CREATE TABLE [CLIENTE1]
(
 [IDCLIENTE]       BIGINT IDENTITY (1, 1) NOT NULL ,
 [NOMBRE]          VARCHAR(50) NOT NULL ,
 [APELLIDOP]       VARCHAR(50) NOT NULL ,
 [APELLIDOM]       VARCHAR(50) NOT NULL ,
 [FECHANAC] VARCHAR(50) NOT NULL ,
 [NUMCONTACTO]	   VARCHAR(50) NOT NULL,	

 CONSTRAINT [PK_Supplier] PRIMARY KEY ([IDCLIENTE]),
);

SELECT IDCLIENTE FROM CLIENTE1 
WHERE NOMBRE='ALFREDO'
AND APELLIDOP =''
AND APELLIDOM= ''
AND NUMCONTACTO= ''

truncate table CLIENTE1

SELECT IDCLIENTE FROM CLIENTE1 WHERE NOMBRE=ggggggggggg
AND APELLIDOP=ggggggggggggg
AND APELLIDOM=ggggggggggg
AND NUMCONTACTO=5555555555





-- ************************************** [Informacion_Cliente].[Linea]

CREATE TABLE [LINEA1]
(
 [IDLINEA]       BIGINT NOT NULL ,
 [IDCLIENTE]     BIGINT NOT NULL ,
/* [numeroCelular] VARCHAR(10) NOT NULL ,
 [numeroCuenta]  VARCHAR(20) NOT NULL ,
 [numLinea]      BIGINT NOT NULL ,
 [fechaCorte]    DATE NOT NULL ,
 [fechaPago]     DATE NOT NULL ,
 [fechaChequeo]  DATE NOT NULL ,
 [estatus]       VARCHAR(50) NOT NULL ,
 [adeudo]        VARCHAR(50) NOT NULL ,*/

 CONSTRAINT [PK_OrderItem] PRIMARY KEY ([IDLINEA]),
 CONSTRAINT [FK_143] FOREIGN KEY ([IDCLIENTE])
  REFERENCES [CLIENTE1]([IDCLIENTE])
);
GO


--SKIP Index: [fkIdx_143]




-- ************************************** [Informacion_Cliente].[Domicilio]

CREATE TABLE [DOMICILIO1]
(
 [IDDOMICILIO] BIGINT IDENTITY (1, 1) NOT NULL ,
 [IDCLIENTE]   BIGINT NOT NULL ,
 [DIRACTUAL]   BIT,
 [CALLE]       VARCHAR(50) NOT NULL ,
 [NUMINT]      VARCHAR(10) NOT NULL ,
 [NUMEXT]      VARCHAR(10) ,
 [CP]		   VARCHAR(10) NOT NULL, 
 [COLONIA]     VARCHAR(50) NOT NULL ,
 [MUNICIPIO]   VARCHAR(100) NOT NULL ,

 CONSTRAINT [PK_Order] PRIMARY KEY ([IDDOMICILIO]),
 CONSTRAINT [FK_135] FOREIGN KEY ([IDCLIENTE])
  REFERENCES [CLIENTE1]([IDCLIENTE])
);

SELECT IDDOMICILIO
FROM DOMICILIO1 AS D, CLIENTE1 AS C
WHERE C.IDCLIENTE= D.IDCLIENTE
AND D.CALLE = 'ASDASDASD'
AND D.COLONIA= 'ASDASDSAD'
AND D.MUNICIPIO= 'ASDASDSA'

--SKIP Index: [fkIdx_135]




-- ************************************** [Informacion_Sistema].[Activacion]

CREATE TABLE [ACTIVACION1]
(
 [IDACTIVACION]    BIGINT NOT NULL ,
 [IDLINEA]         BIGINT NOT NULL ,
 [FOLIOTALM]       VARCHAR(50) NOT NULL ,
 [FOLIORUNNING]    VARCHAR(50) NOT NULL ,
 [FOLIOSISACT]     VARCHAR(50) NOT NULL ,
 [FECHAACTIVACION] VARCHAR(50) NULL ,

 CONSTRAINT [PK_Activacion] PRIMARY KEY ([IDACTIVACION]),
 CONSTRAINT [FK_151] FOREIGN KEY ([IDLINEA])
  REFERENCES [LINEA1]([IDLINEA])
);
GO


--SKIP Index: [fkIdx_151]




-- ************************************** [Informacion_Sistema].[Evaluador]

CREATE TABLE [RES_CLIENTE1]
(
 [IDEVAR]    INT IDENTITY (1, 1) NOT NULL ,
 [IDVENDEDOR]     BIGINT NOT NULL ,
 [IDCLIENTE]      BIGINT NOT NULL ,
 [IDDOMICILIO]    BIGINT NOT NULL ,

 [FOLIOEVAR]	  VARCHAR(50) NOT NULL ,
 [FECHAEVAR]	  VARCHAR(50) NOT NULL ,
 [ASESOR]         VARCHAR(50) NOT NULL ,
 [RESULTADO]      VARCHAR(50) NOT NULL ,
 [OBSERVACIONES]  VARCHAR(200) NOT NULL ,
 [RFC_EVAR]  VARCHAR(50) NOT NULL 
 );
 

 CONSTRAINT [PK_Customer] PRIMARY KEY ([IDEVAR]),

 CONSTRAINT [FK_159] FOREIGN KEY ([IDDOMICILIO])
  REFERENCES [DOMICILIO1]([IDDOMICILIO]),

 CONSTRAINT [FK_169] FOREIGN KEY ([IDVENDEDOR])
  REFERENCES [VENDEDOR1]([IDVENDEDOR]),

 CONSTRAINT [FK_173] FOREIGN KEY ([IDCLIENTE])
  REFERENCES [CLIENTE1]([IDCLIENTE])
);
GO
CREATE RULE RES_CLIENTE AS @RES_CLIENTE IN ('DIFERIDA', 'BUENO', 'REGULAR',
'EXCELENTE' ,'ADEUDO')
EXEC sp_bindrule RES_CLIENTE, 'RES_CLIENTE1.RESULTADO'

INSERT	INTO (nombre, apellidoP, apellidoM, fechaNacimiento, celular) 
		VALUES ()

INSERT INTO CLIENTE1(nombre, apellidoP, apellidoM, fechaNacimiento) 
VALUES('JUAN','MENDEZ','MUÑOZ','04/11/2018');

truncate CLIENTE1

INSERT INTO DOMICILIO1(IDCLIENTE,DIRACTUAL,CALLE,NUMINT,NUMEXT,CP,COLONIA,MUNICIPIO) 
VALUES(1 ,CONVERT(BIT,'1') ,'asdasd' ,'a' ,'a' ,'23223' ,'asdasd' ,'asdasd')

TRUNCATE TABLE DOMICILIO1
TRUNCATE TABLE CLIENTE1

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************


-- ************************************** [Usuario]

CREATE TABLE [USUARIO]
(
 [idUsuario]    bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]       varchar(50) NOT NULL ,
 [tipo_usuario] varchar(50) NOT NULL ,
 [contraseña]   varchar(50) NOT NULL ,
 [numCelular]   varchar(50) NOT NULL ,

 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([idUsuario] ASC)
);
GO

CREATE RULE TIPOUSUARIO AS @TIPOUSUARIO IN('VENDEDOR', 'ADMINISTRADOR')
EXEC sp_bindrule TIPOUSUARIO, 'USUARIO.tipo_usuario'

INSERT INTO USUARIO (nombre,tipo_usuario,contraseña,numCelular)
VALUES('admin', 'ADMINISTRADOR', 'root', '4443880569')








-- ************************************** [Informacion_Vendedor].[Vendedor]

CREATE TABLE [Informacion_Vendedor].[Vendedor]
(
 [idVendedor] bigint IDENTITY (1, 1) NOT NULL ,
 [nombre]     varchar(50) NOT NULL ,
 [celular]    varchar(50) NOT NULL ,
 [idUsuario]  bigint NOT NULL ,

 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED ([idVendedor] ASC),
 CONSTRAINT [FK_219] FOREIGN KEY ([idUsuario])  REFERENCES [Usuario]([idUsuario])
);
GO


--SKIP Index: [fkIdx_219]







-- ************************************** [Administradores]

CREATE TABLE [Administradores]
(
 [idAdministradores] bigint IDENTITY (1, 1) NOT NULL ,
 [nomAdmin]          varchar(50) NOT NULL ,
 [idUsuario]         bigint NOT NULL ,

 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED ([idAdministradores] ASC),
 CONSTRAINT [FK_216] FOREIGN KEY ([idUsuario])  REFERENCES [Usuario]([idUsuario])
);
GO


--SKIP Index: [fkIdx_216]







