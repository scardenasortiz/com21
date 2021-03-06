USE [com21db]
GO
/****** Object:  Table [dbo].[tbl_c_slide]    Script Date: 01/14/2013 00:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_slide](
	[Id_Slide] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Ruta] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_slide] PRIMARY KEY CLUSTERED 
(
	[Id_Slide] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_provincia]    Script Date: 01/14/2013 00:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_provincia](
	[Id_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[Provincia] [nvarchar](max) NULL,
	[Id_Pais] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_provincia] PRIMARY KEY CLUSTERED 
(
	[Id_Provincia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_pais]    Script Date: 01/14/2013 00:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_pais](
	[Id_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Aplicar] [bit] NULL,
 CONSTRAINT [PK_tbl_c_pais] PRIMARY KEY CLUSTERED 
(
	[Id_Pais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_pais] ON
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (1, N'Ecuador', CAST(0x0000A12401214915 AS DateTime), CAST(0x0000A12401214915 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (2, N'Brazil', CAST(0x0000A13A01856E16 AS DateTime), CAST(0x0000A13A01856E16 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (3, N'Perú', CAST(0x0000A13A0185AA79 AS DateTime), CAST(0x0000A13A0185AA79 AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_c_pais] OFF
/****** Object:  Table [dbo].[tbl_c_info_empresa]    Script Date: 01/14/2013 00:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_info_empresa](
	[Id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Informacion] [nvarchar](max) NULL,
	[Id_pagina] [int] NULL,
	[Pagina] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_info_empresa] PRIMARY KEY CLUSTERED 
(
	[Id_Empresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_clientes]    Script Date: 01/14/2013 00:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_clientes](
	[Id_Clientes] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[Usuario] [nvarchar](max) NULL,
	[Clave] [nvarchar](32) NULL,
	[Id_Sexo] [int] NULL,
	[Sexo] [nvarchar](max) NULL,
	[Correo] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Id_Ciudad] [int] NULL,
	[Id_Provincia] [int] NULL,
	[Id_Pais] [int] NULL,
	[Telefono] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
	[Correo_Secundario] [nvarchar](max) NULL,
	[Cedula] [nvarchar](50) NULL,
	[FechaNacimiento] [nvarchar](50) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_clientes] PRIMARY KEY CLUSTERED 
(
	[Id_Clientes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_ciudad]    Script Date: 01/14/2013 00:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_ciudad](
	[Id_Ciudad] [int] IDENTITY(1,1) NOT NULL,
	[Ciudad] [nvarchar](max) NULL,
	[Id_Provincia] [int] NULL,
	[Provincia] [nvarchar](max) NULL,
	[Id_Pais] [int] NULL,
	[Pais] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_ciudad] PRIMARY KEY CLUSTERED 
(
	[Id_Ciudad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_administrador]    Script Date: 01/14/2013 00:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_administrador](
	[Id_Administrador] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](100) NULL,
	[Clave] [nvarchar](32) NULL,
	[Nombres] [nvarchar](100) NULL,
	[Apellidos] [nvarchar](100) NULL,
	[Correo] [nvarchar](100) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbbl_c_administrador] PRIMARY KEY CLUSTERED 
(
	[Id_Administrador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_administrador] ON
INSERT [dbo].[tbl_c_administrador] ([Id_Administrador], [Usuario], [Clave], [Nombres], [Apellidos], [Correo], [FechaIngreso], [FechaModificacion], [Estado]) VALUES (1, N'scardenas', N'scardenas123', N'Steven Omar', N'Cardenas Ortiz', N'so_cardenas@hotmail.com', CAST(0x0000A125018439FE AS DateTime), CAST(0x0000A125018439FE AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_c_administrador] OFF
/****** Object:  StoredProcedure [dbo].[sp_C_valida_administrador]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_C_valida_administrador](@Usuario varchar(100), @Clave varchar(32))
AS
select * from tbl_c_administrador where Usuario = @Usuario and Clave = @Clave
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Provincias]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_Provincias](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_provincia(Provincia,Id_Pais)
SELECT 
		x.value('@Provincia','nvarchar(max)'),
        x.value('@Id_Pais','int')
FROM @xmlDatos.nodes('/Ad_Pronvincias') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Pais]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Pais](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_pais(Pais,Aplicar)
SELECT 
		x.value('@Pais','nvarchar(max)'),
        x.value('@Aplicar','bit')
FROM @xmlDatos.nodes('/Ad_Pais') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Pais
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Ciudad]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_Ciudad](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_ciudad(Ciudad,Id_Provincia,Provincia,Id_Pais,Pais)
SELECT 
        x.value('@Ciudad','nvarchar(max)'),
        x.value('@Id_Provincia','int'),
		x.value('@Provincia','nvarchar(max)'),
        x.value('@Id_Pais','int'),
        x.value('@Pais','nvarchar(max)')
FROM @xmlDatos.nodes('/Ad_Ciudades') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_ProvinciaId]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_ProvinciaId](@Id_Provincia int)
AS
BEGIN TRAN
update tbl_c_provincia
set Estado = 2
where Id_Provincia = @Id_Provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Ciudades]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Ciudades](@Id_Ciudad int)
AS
BEGIN TRAN
update tbl_c_ciudad
set Estado = 2
where Id_Ciudad = @Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_ProvinciaId]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_ProvinciaId](@Id_Provincia int)
AS
BEGIN TRAN
select Id_Provincia,Provincia,Id_Pais,FechaIngreso from tbl_c_provincia where Id_Provincia = @Id_Provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Provincia]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Provincia]
AS
BEGIN TRAN
select Id_Provincia,Provincia,Id_Pais,FechaIngreso from tbl_c_provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Pais]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Pais]
AS
BEGIN TRAN
select Id_Pais,Pais,Aplicar,FechaIngreso from tbl_c_pais
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_CiudadId]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_CiudadId](@Id_Ciudad int)
AS
BEGIN TRAN
select Id_Ciudad,Ciudad,Id_Provincia,Provincia,Id_Pais,Pais,FechaIngreso from tbl_c_ciudad where Estado = 1 and Id_Ciudad = @Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Ciudad]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Ciudad]
AS
BEGIN TRAN
select Id_Ciudad,Ciudad,Id_Provincia,Provincia,Id_Pais,Pais,FechaIngreso from tbl_c_ciudad where Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Provincias]    Script Date: 01/14/2013 00:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_Provincias](@xmlDatos xml,@Id_Provincia int)
AS
Begin Tran
		Update tbl_c_provincia
		set
			Provincia=x.value('@Provincia','nvarchar(max)'),
			Id_Pais=x.value('@Id_Pais','int')
			FROM @xmlDatos.nodes('/Ad_Provincias') R(x)
		where Id_Provincia = @Id_Provincia
Commit Tran
GO
/****** Object:  Default [DF_tbl_c_slide_FechaIngreso]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_slide] ADD  CONSTRAINT [DF_tbl_c_slide_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_slide_FechaModificacion]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_slide] ADD  CONSTRAINT [DF_tbl_c_slide_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_slide_Estado]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_slide] ADD  CONSTRAINT [DF_tbl_c_slide_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_provincia_FechaIngreso]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_provincia] ADD  CONSTRAINT [DF_tbl_c_provincia_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_provincia_FechaModificacion]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_provincia] ADD  CONSTRAINT [DF_tbl_c_provincia_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_provincia_Estado]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_provincia] ADD  CONSTRAINT [DF_tbl_c_provincia_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_pais_FechaIngreso]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_pais] ADD  CONSTRAINT [DF_tbl_c_pais_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_pais_FechaModificacion]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_pais] ADD  CONSTRAINT [DF_tbl_c_pais_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_pais_Estado]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_pais] ADD  CONSTRAINT [DF_tbl_c_pais_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_info_empresa_FechaIngreso]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_info_empresa] ADD  CONSTRAINT [DF_tbl_c_info_empresa_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_info_empresa_FechaModificacion]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_info_empresa] ADD  CONSTRAINT [DF_tbl_c_info_empresa_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_info_empresa_Estado]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_info_empresa] ADD  CONSTRAINT [DF_tbl_c_info_empresa_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_clientes_Id_Ciudad]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Id_Ciudad]  DEFAULT ((0)) FOR [Id_Ciudad]
GO
/****** Object:  Default [DF_tbl_c_clientes_Id_Provincia]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Id_Provincia]  DEFAULT ((0)) FOR [Id_Provincia]
GO
/****** Object:  Default [DF_tbl_c_clientes_Id_Pais]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Id_Pais]  DEFAULT ((0)) FOR [Id_Pais]
GO
/****** Object:  Default [DF_tbl_c_clientes_FechaIngreso]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_clientes_FechaModificacion]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_clientes_Estado]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_ciudad_FechaIngreso]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_ciudad] ADD  CONSTRAINT [DF_tbl_c_ciudad_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_ciudad_FechaModificacion]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_ciudad] ADD  CONSTRAINT [DF_tbl_c_ciudad_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_ciudad_Estado]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_ciudad] ADD  CONSTRAINT [DF_tbl_c_ciudad_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbbl_c_administrador_FechaIngreso]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_administrador] ADD  CONSTRAINT [DF_tbbl_c_administrador_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbbl_c_administrador_FechaModificacion]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_administrador] ADD  CONSTRAINT [DF_tbbl_c_administrador_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbbl_c_administrador_Estado]    Script Date: 01/14/2013 00:21:52 ******/
ALTER TABLE [dbo].[tbl_c_administrador] ADD  CONSTRAINT [DF_tbbl_c_administrador_Estado]  DEFAULT ((1)) FOR [Estado]
GO
